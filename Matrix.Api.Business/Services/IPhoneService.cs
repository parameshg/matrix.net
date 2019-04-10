using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Framework.Business;

namespace Matrix.Api.Business.Services
{
    public interface IPhoneService : IService
    {
        Task<Guid> SendText(Guid application, List<string> to, string message);
    }
}