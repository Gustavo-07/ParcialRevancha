using System.Threading.Tasks;

namespace Dominio.Contracts
{
    public interface IMailSender
    {
        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}