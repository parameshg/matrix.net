using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<Guid> SendText(Guid application, List<string> to, string message)
        {
            var result = Guid.Empty;

            await Task.Run(() => { result = Guid.NewGuid(); });

            return result;
        }
    }
}