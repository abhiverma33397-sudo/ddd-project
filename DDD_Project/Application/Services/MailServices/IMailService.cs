using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services.MailServices
{
    public interface IMailService
    {
        Task SendMail(MailMessage mailMessage);
    }
}
