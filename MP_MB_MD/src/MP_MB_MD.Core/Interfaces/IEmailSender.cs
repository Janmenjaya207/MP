using System.Threading.Tasks;

namespace MP_MB_MD.Core.Interfaces
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string to, string from, string subject, string body);
    }
}
