using System.Threading.Tasks;

namespace Dominio.Contracts
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}