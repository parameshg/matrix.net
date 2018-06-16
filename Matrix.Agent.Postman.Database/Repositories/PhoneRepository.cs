using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matrix.Agent.Postman.Model;
using Matrix.Framework.Database;
using PowerMapper;

namespace Matrix.Agent.Postman.Database.Repositories
{
    public class PhoneRepository : Repository, IPhoneRepository
    {
        private readonly PostmanDbContext db;

        public PhoneRepository(IRepositoryContext context, PostmanDbContext database)
            : base(context)
        {
            db = database;
        }

        public async Task<List<PhoneMessage>> GetPhoneMessagesWithStatus(Guid application, int status)
        {
            var result = new List<PhoneMessage>();

            await Task.Run(() =>
            {
                result = Mapper.Map<List<Entities.PhoneMessage>, List<PhoneMessage>>(db.PhoneMessages.Where(i => i.Application.Equals(application) && i.Status.Equals(status)).ToList());
            });

            return result;
        }

        public async Task<PhoneMessage> GetPhoneMessageById(Guid id)
        {
            PhoneMessage result = null;

            await Task.Run(() =>
            {
                result = Mapper.Map<Entities.PhoneMessage, PhoneMessage>(db.PhoneMessages.FirstOrDefault(i => i.Id.Equals(id)));
            });

            return result;
        }

        public async Task<Guid> CreatePhoneMessage(Guid application, string from, List<string> to, string message, int status)
        {
            var result = Guid.Empty;

            var id = Guid.NewGuid();

            var entity = new Entities.PhoneMessage()
            {
                Id = id,
                Application = application,
                From = from,
                To = new List<Entities.PhoneNumber>(),
                Message = message,
                Status = status
            };

            foreach (var i in to)
                entity.To.Add(new Entities.PhoneNumber() { PhoneMessageId = id, Number = i });

            await db.PhoneMessages.AddAsync(entity);

            if (await db.SaveChangesAsync() > 0)
                result = id;

            return result;
        }

        public async Task<bool> UpdatePhoneMessage(Guid id, int status)
        {
            var result = false;

            var entity = db.PhoneMessages.FirstOrDefault(i => i.Id.Equals(id));

            if (entity != null)
                entity.Status = status;

            result = await db.SaveChangesAsync() > 0;

            return result;
        }

        public async Task<bool> DeletePhoneMessage(Guid id)
        {
            var result = false;

            db.PhoneMessages.Remove(db.PhoneMessages.FirstOrDefault(i => i.Id.Equals(id)));

            result = await db.SaveChangesAsync() > 0;

            return result;
        }

        public async Task<bool> DeletePhoneMessagesWithStatus(Guid application, int status)
        {
            var result = false;

            db.Emails.RemoveRange(db.Emails.Where(i => i.Application.Equals(application) && i.Status.Equals(status)));

            result = await db.SaveChangesAsync() > 0;

            return result;
        }
    }
}