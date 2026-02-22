using Microsoft.AspNetCore.Identity.UI.Services;
using System.Threading.Tasks;

namespace linkedin.Services
{
    public class DummyEmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            // Ici on ne fait rien, juste pour satisfaire l'Identity
            return Task.CompletedTask;
        }
    }
}
