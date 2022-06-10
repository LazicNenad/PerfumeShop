using PerfumeShop.Application.DTO;

namespace PerfumeShop.Application.Emails;

public interface IEmailSender
{
    void SendEmail(MessageDto message);
}