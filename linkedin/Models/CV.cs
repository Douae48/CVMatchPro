using System.ComponentModel.DataAnnotations;

namespace linkedin.Models
{
    public class CV
    {
        [Key]
        public int CVId { get; set; }

        public string FilePath { get; set; } // path to uploaded CV
        public DateTime UploadedAt { get; set; }
        public string? TexteAnalyse { get; set; }
        // Navigation property
        public ICollection<Candidature> candidatures { get; set; }
    }
}
