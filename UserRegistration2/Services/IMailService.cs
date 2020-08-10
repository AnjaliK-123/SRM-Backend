using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserRegistration1.Services
{
    public interface IMailService
    {
        Task SendMail(string toEmail, string subject, string content);

    }
}
