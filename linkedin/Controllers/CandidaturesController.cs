using linkedin.Data;
using linkedin.Models;
using Microsoft.AspNetCore.Mvc;

namespace linkedin.Controllers
{
    public class CandidaturesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CandidaturesController(ApplicationDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        [HttpPost]
        public async Task<IActionResult> Upload(int offreId, IFormFile cvFile)
        {
            if (cvFile == null || cvFile.Length == 0)
            {
                TempData["Error"] = "Please select a CV file.";
                return RedirectToAction("Index2", "Offres");
            }

            // Ensure uploads folder exists
            var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Save file with unique name
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(cvFile.FileName);
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await cvFile.CopyToAsync(stream);
            }

            // 1️⃣ Extract text from CV
            string texteCV = CVExtractor.ExtractText(filePath);

            // 2️⃣ Create new CV record
            var cv = new CV
            {
                FilePath = "/uploads/" + fileName,
                UploadedAt = DateTime.Now,
                TexteAnalyse = texteCV // Save extracted text
            };
            _context.CVs.Add(cv);
            await _context.SaveChangesAsync();

            // 3️⃣ Load Offre
            var offre = await _context.Offres.FindAsync(offreId);

            // 4️⃣ Calculate matching score
            var matchingService = new MatchingService();
            double score = matchingService.CalculerScore(texteCV, offre);

            // 5️⃣ Create new Candidature linking CV + Offre + Score
            var candidature = new Candidature
            {
                CVId = cv.CVId,
                OffreId = offreId,
                Score = score // <- add a Score column in Candidature
            };

            _context.candidatures.Add(candidature);
            await _context.SaveChangesAsync();

            TempData["Success"] = $"CV uploaded successfully! Matching Score: {score}%";
            return RedirectToAction("Index2", "Offres");
        }
    }
}