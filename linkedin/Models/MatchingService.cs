using linkedin.Models;

public class MatchingService
{
    private readonly Dictionary<string, double> _poids;

    public MatchingService(double poidsCompetences = 0.5, double poidsExperience = 0.3, double poidsDiplome = 0.2)
    {
        _poids = new Dictionary<string, double>
        {
            { "Competences", poidsCompetences },
            { "Experience", poidsExperience },
            { "Diplome", poidsDiplome }
        };
    }

    public double CalculerScore(string cvTexte, Offre offre)
    {
        double score = 0;

        if (!string.IsNullOrEmpty(offre.CompetencesRequises))
        {
            var competences = offre.CompetencesRequises.Split(',');
            score += _poids["Competences"] *
                     (double)competences.Count(c => cvTexte.Contains(c, StringComparison.OrdinalIgnoreCase)) / competences.Length;
        }

        if (!string.IsNullOrEmpty(offre.ExperienceRequise))
        {
            if (cvTexte.Contains(offre.ExperienceRequise, StringComparison.OrdinalIgnoreCase))
                score += _poids["Experience"];
        }

        if (!string.IsNullOrEmpty(offre.DiplomeRequis))
        {
            if (cvTexte.Contains(offre.DiplomeRequis, StringComparison.OrdinalIgnoreCase))
                score += _poids["Diplome"];
        }

        return Math.Round(score * 100, 2); // Score en %
    }
}
