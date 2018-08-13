using System.Collections.Generic;
using System.Threading.Tasks;
using LiteDB;
using Matrix.CLI.Model;

namespace Matrix.CLI.Database.Repositories
{
    public class TargetRepository : ITargetRepository
    {
        private LiteDatabase db;

        public TargetRepository()
        {
            db = new LiteDatabase("matrix.targets");
        }

        public async Task<IList<TargetEntry>> GetTargets()
        {
            var result = new List<TargetEntry>();

            await Task.Run(() =>
            {
                var targets = db.GetCollection<TargetEntry>();

                result.AddRange(targets?.FindAll());
            });

            return result;
        }

        public async Task<TargetEntry> GetTarget(string name)
        {
            TargetEntry result = null;

            await Task.Run(() =>
            {
                var targets = db.GetCollection<TargetEntry>();

                result = targets?.FindById(name);
            });

            return result;
        }

        public async Task<bool> SaveTarget(string name, string url)
        {
            var result = false;

            await Task.Run(() =>
            {
                var targets = db.GetCollection<TargetEntry>();

                var entry = targets?.FindById(name);

                if (entry != null)
                {
                    entry.Url = url;

                    targets.Update(entry);

                    result = true;
                }
                else
                {
                    targets.Insert(new TargetEntry() { Alias = name, Url = url });

                    result = true;
                }
            });

            return result;
        }

        public async Task<bool> RemoveTarget(string name)
        {
            var result = false;

            await Task.Run(() =>
            {
                var targets = db.GetCollection<TargetEntry>();

                result = targets?.Delete(name) ?? false;
            });

            return result;
        }

        public async Task<bool> ClearTargets()
        {
            var result = false;

            await Task.Run(() =>
            {
                var targets = db.GetCollection<TargetEntry>();

                result = targets?.Delete(i => !string.IsNullOrEmpty(i.Alias)) > 0;
            });

            return result;
        }
    }
}