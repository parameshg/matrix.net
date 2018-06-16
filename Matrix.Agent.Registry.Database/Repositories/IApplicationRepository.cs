using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Registry.Model;

namespace Matrix.Agent.Registry.Database.Repositories
{
    public interface IApplicationRepository
    {
        Task<List<Application>> Get();

        Task<Guid> Create(string name, string description);

        Task<bool> Update(Guid id, string name, string description);

        Task<bool> Delete(Guid id);
    }
}