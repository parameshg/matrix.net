using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Postman.Model;
using Matrix.Api.Business.Services;
using Matrix.Framework.Business;

namespace Matrix.Api.Business.Stub
{
    public class PhoneService : Service, IPhoneService
    {
        public PhoneService(IServiceContext context)
            : base(context)
        {
        }

        public async Task<List<PhoneMessageMetadata>> GetMessages(Guid application, DateTime from, DateTime to, int page = 1, int count = 10)
        {
            var result = new List<PhoneMessageMetadata>();

            await Task.Run(() => { });

            return result;
        }

        public async Task<List<PhoneMessageMetadata>> Search(Guid application, DateTime from, DateTime to, string pattern, int page = 1, int count = 10)
        {
            var result = new List<PhoneMessageMetadata>();

            await Task.Run(() => { });

            return result;
        }

        public async Task<Guid> SendMessage(Guid application, List<string> to, string message)
        {
            var result = Guid.Empty;

            await Task.Run(() => { result = Guid.NewGuid(); });

            return result;
        }
    }
}