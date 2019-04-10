using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix.Api.Business.Services
{
    public interface IConfigurationService
    {
        Task<List<KeyValuePair<string, string>>> GetSettings(Guid application);

        Task<string> GetSettings(Guid application, string key);
    }
}