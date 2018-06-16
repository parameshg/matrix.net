using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix.Web.Business.Services
{
    public interface IConfigurationService
    {
        Task<List<KeyValuePair<string, string>>> GetSettings(Guid application);

        Task<string> GetSettings(Guid application, string key);

        Task<Guid> Create(Guid application, string key, string value);

        Task<bool> Update(Guid application, string key, string value);

        Task<bool> Delete(Guid application, string key);
    }
}