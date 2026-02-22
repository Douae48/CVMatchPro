using linkedin.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace linkedin.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReportsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OffersCvCount()
        {
            // Get offers with count of CVs
            var data = _context.Offres
                .Include(o => o.candidatures)
                .Select(o => new
                {
                    o.Id,
                    o.Titre,
                    CvCount = o.candidatures.Count()
                })
                .ToList();

            return View(data);
        }
    }
}
