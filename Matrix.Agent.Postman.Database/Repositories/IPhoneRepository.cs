using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Postman.Model;

namespace Matrix.Agent.Postman.Database.Repositories
{
    public interface IPhoneRepository
    {
        Task<List<PhoneMessage>> GetPhoneMessagesWithStatus(Guid application, int status);

        Task<PhoneMessage> GetPhoneMessageById(Guid id);

        Task<Guid> CreatePhoneMessage(Guid application, string from, List<string> to, string message, int status);

        Task<bool> UpdatePhoneMessage(Guid id, int status);

        Task<bool> DeletePhoneMessage(Guid id);

        Task<bool> DeletePhoneMessagesWithStatus(Guid application, int status);
    }
}