using Microsoft.AspNetCore.Identity;

namespace linkedin.Models
{
    public class Offre
    {
        public int Id { get; set; }

        public required string Titre { get; set; }
        public required string Description { get; set; }
        public DateTime DatePublication { get; set; } = DateTime.Now;
        public string? CompetencesRequises { get; set; }  // e.g., "C#,SQL,JavaScript"
        public string? ExperienceRequise { get; set; }    // e.g., "3 ans"
        public string? DiplomeRequis { get; set; }
        public ICollection<Candidature>? candidatures { get; set; }
    }
}
