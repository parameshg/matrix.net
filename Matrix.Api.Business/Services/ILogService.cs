using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Framework.Business;

namespace Matrix.Api.Business.Services
{
    public interface ILogService : IService
    {
        Task SaveLogEntry(Guid application, string message, DateTime? timestamp = null, string source = null, int level = 0, int @event = 0, Dictionary<string, string> properties = null, List<string> tags = null);
    }
}