namespace linkedin.Models
{
    public class Candidature
    {
        public int OffreId { get; set; }
        public Offre Offre { get; set; }

        public int CVId { get; set; }
        public CV CV { get; set; }
        public double Score { get; set; }
    }
}
