using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Postman.Database.Repositories;
using Matrix.Framework.Business;

namespace Matrix.Agent.Postman.Business.Services
{
    public class PhoneService : Service, IPhoneService
    {
        public IPhoneRepository Repository { get; }

        public PhoneService(IServiceContext context, IPhoneRepository repository)
            : base(context)
        {
            Repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Guid> SendMessage(Guid application, List<string> to, string message)
        {
            var result = Guid.Empty;

            var from = string.Empty;

            var status = 0;

            result = await Repository.CreatePhoneMessage(application, from, to, message, status);

            return result;
        }
    }
}