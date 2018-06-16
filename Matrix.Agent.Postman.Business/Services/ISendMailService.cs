using System.Collections.Generic;
using System.Threading.Tasks;

namespace Matrix.Agent.Postman.Business.Services
{
    public interface ISendMailService
    {
        Task<bool> Execute(string host, int port, string username, string password, string from, List<string> to, List<string> cc, List<string> bcc, string subject, string body, bool html);
    }
}