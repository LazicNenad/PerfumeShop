using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using PerfumeShop.Application.DTO;
using PerfumeShop.Application.Emails;

namespace PerfumeShop.Implementation.Emails
{
    public class SmptEmailSender : IEmailSender
    {
        private readonly string _fromEmail;
        private readonly string _password;
        private readonly int _port;
        private readonly string _host;

        public SmptEmailSender(string fromEmail, string password, int port, string host)
        {
            _fromEmail = fromEmail;
            _password = password;
            _port = port;
            _host = host;
        }

        public void SendEmail(MessageDto dto)
        {
            var smtp = new SmtpClient
            {
                Host = _host,
                Port = _port,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(_fromEmail, _password),
                UseDefaultCredentials = false
            };

            var message = new MailMessage(_fromEmail, dto.To);
            message.Subject = dto.Title;
            message.Body = dto.Body;
            message.IsBodyHtml = true;
            smtp.Send(message);
        }
    }
}
