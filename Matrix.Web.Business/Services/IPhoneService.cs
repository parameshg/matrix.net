using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Framework.Business;

namespace Matrix.Web.Business.Services
{
    public interface IPhoneService : IService
    {
        Task<Guid> SendMessage(Guid application, List<string> to, string message);
    }
}