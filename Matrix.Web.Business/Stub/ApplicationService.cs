using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Matrix.Agent.Registry.Model;
using Matrix.Framework.Business;
using Matrix.Framework.Constants;
using Matrix.Web.Business.Services;

namespace Matrix.Web.Business.Stub
{
    public class ApplicationService : Service, IApplicationService
    {
        private List<Application> db { get; set; }

        public ApplicationService(IServiceContext context)
            : base(context)
        {
            db = new List<Application>();

            db.Add(new Application()
            {
                Id = This.Id,
                Name = This.Name,
                Description = This.Description
            });

            db.Add(new Application()
            {
                Id = Default.Id,
                Name = Default.Name,
                Description = Default.Description
            });
        }

        public async Task<List<Application>> GetApplications()
        {
            var result = new List<Application>();

            await Task.Run(() => { result.AddRange(db); });

            return result;
        }

        public async Task<Guid> Register(string name, string description)
        {
            var result = Guid.Empty;

            await Task.Run(() =>
            {
                var id = Guid.NewGuid();

                db.Add(new Application()
                {
                    Id = id,
                    Name = name,
                    Description = description
                });

                result = id;
            });

            return result;
        }

        public async Task<bool> Update(Guid id, string name, string description)
        {
            var result = false;

            await Task.Run(() =>
            {
                var i = db.FindIndex(o => o.Id.Equals(id));

                db[i].Name = name;
                db[i].Description = description;

                result = true;

            });

            return result;
        }

        public async Task<bool> Delete(Guid id)
        {
            var result = false;

            await Task.Run(() =>
            {
                var i = db.FindIndex(o => o.Id.Equals(id));

                db.RemoveAt(i);

                result = true;

            });

            return result;
        }
    }
}