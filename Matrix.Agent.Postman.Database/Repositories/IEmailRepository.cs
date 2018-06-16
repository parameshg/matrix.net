using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Postman.Model;

namespace Matrix.Agent.Postman.Database.Repositories
{
    public interface IEmailRepository
    {
        Task<List<Email>> GetEmailWithStatus(Guid application, int status);

        Task<Email> GetEmailById(Guid id);

        Task<Guid> CreateEmail(Guid application, string from, List<string> to, List<string> cc, List<string> bcc, string subject, string body, bool html, int status);

        Task<bool> UpdateEmail(Guid id, int status);

        Task<bool> DeleteEmail(Guid id);

        Task<bool> DeleteEmailWithStatus(Guid application, int status);
    }
}