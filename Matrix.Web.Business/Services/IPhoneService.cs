using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Postman.Model;
using Matrix.Framework.Business;

namespace Matrix.Web.Business.Services
{
    public interface IPhoneService : IService
    {
        Task<List<PhoneMessageMetadata>> GetMessages(Guid application, DateTime from, DateTime to, int page = 1, int count = 10);

        Task<List<PhoneMessageMetadata>> Search(Guid application, DateTime from, DateTime to, string pattern, int page = 1, int count = 10);

        Task<Guid> SendMessage(Guid application, List<string> to, string message);
    }
}