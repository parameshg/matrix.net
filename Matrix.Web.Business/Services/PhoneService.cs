using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Framework.Business;

namespace Matrix.Web.Business.Services
{
    public class PhoneService : Service, IPhoneService
    {
        public PhoneService(IServiceContext context)
            : base(context)
        {
        }

        public Task<Guid> SendMessage(Guid application, List<string> to, string message)
        {
            throw new NotImplementedException();
        }
    }
}