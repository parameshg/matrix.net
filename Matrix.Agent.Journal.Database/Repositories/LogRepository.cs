using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matrix.Agent.Journal.Database.Converters;
using Matrix.Framework.Database;
using PowerMapper;

namespace Matrix.Agent.Journal.Database.Repositories
{
    public class LogRepository : Repository, ILogRepository
    {
        private readonly JournalDbContext db;

        static LogRepository()
        {
            Mapper.RegisterConverter<Model.LogEntry, Entities.LogEntry>(new LogEntryConverter().ConvertToEntity);
            Mapper.RegisterConverter<Entities.LogEntry, Model.LogEntry>(new LogEntryConverter().ConvertToModel);
        }

        public LogRepository(IRepositoryContext context, JournalDbContext database)
            : base(context)
        {
            db = database ?? throw new ArgumentNullException(nameof(database));
        }

        public async Task<List<Model.LogEntry>> Get(Guid app, DateTime from, DateTime to, int skip = 0, int count = 10)
        {
            var result = new List<Model.LogEntry>();

            await Task.Run(() =>
            {
                var entity = db.Logs.Where(i => i.Application.Equals(app) && i.Timestamp.Subtract(from).Seconds >= 0 && i.Timestamp.Subtract(to).Seconds <= 0).Skip(skip).Take(count).ToList();

                if (entity != null && entity.Count > 0)
                    result.AddRange(Mapper.Map<List<Model.LogEntry>>(entity));
            });

            return result;
        }

        public async Task<List<Model.LogEntry>> Search(Guid app, DateTime from, DateTime to, string pattern, int skip = 0, int count = 10)
        {
            var result = new List<Model.LogEntry>();

            await Task.Run(() =>
            {
                var entity = db.Logs.Where(i => i.Application.Equals(app) && i.Timestamp.Subtract(from).Seconds >= 0 && i.Timestamp.Subtract(to).Seconds <= 0 && i.Message.Contains(pattern)).Skip(skip).Take(count).ToList();

                if (entity != null && entity.Count > 0)
                    result.AddRange(Mapper.Map<List<Model.LogEntry>>(entity));
            });

            return result;
        }

        public async Task<Guid> Save(Model.LogEntry log)
        {
            var result = Guid.Empty;

            var entity = new Entities.LogEntry()
            {
                Id = log.Id,
                Timestamp = log.Timestamp,
                Application = log.Application,
                Source = log.Source,
                Level = log.Level,
                Event = log.Event,
                Message = log.Message
            };

            entity.Properties = new List<Entities.LogProperty>();

            foreach (var i in log.Properties)
            {
                entity.Properties.Add(new Entities.LogProperty()
                {
                    Key = i.Key,
                    Value = i.Value
                });
            }

            entity.Tags = new List<Entities.LogTag>();

            foreach (var i in log.Tags)
            {
                entity.Tags.Add(new Entities.LogTag()
                {
                    Value = i
                });
            }

            await db.Logs.AddAsync(entity);

            if (await db.SaveChangesAsync() > 0)
                result = entity.Id;

            return result;
        }
    }
}