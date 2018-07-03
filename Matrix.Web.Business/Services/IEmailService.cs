using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Postman.Model;
using Matrix.Framework.Business;

namespace Matrix.Web.Business.Services
{
    public interface IEmailService : IService
    {
        Task<List<EmailMetadata>> GetEmails(Guid application, DateTime from, DateTime to, int page = 1, int count = 10);

        Task<List<EmailMetadata>> Search(Guid application, DateTime from, DateTime to, string pattern, int page = 1, int count = 10);

        Task<Guid> SendMail(Guid application, List<string> to, List<string> cc, List<string> bcc, string subject, string body, bool html);
    }
}