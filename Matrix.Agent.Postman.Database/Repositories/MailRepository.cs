using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matrix.Agent.Postman.Model;
using Matrix.Framework.Database;
using PowerMapper;

namespace Matrix.Agent.Postman.Database.Repositories
{
    public class MailRepository : Repository, IMailRepository
    {
        private readonly PostmanDbContext db;

        public MailRepository(IRepositoryContext context, PostmanDbContext database)
            : base(context)
        {
            db = database;
        }

        public async Task<Email> GetEmailById(Guid id)
        {
            Email result = null;

            await Task.Run(() =>
            {
                result = Mapper.Map<Entities.Email, Email>(db.Emails.FirstOrDefault(i => i.Id.Equals(id)));
            });

            return result;
        }

        public async Task<List<Email>> GetEmailWithStatus(Guid application, int status)
        {
            var result = new List<Email>();

            await Task.Run(() =>
            {
                result = Mapper.Map<List<Entities.Email>, List<Email>>(db.Emails.Where(i => i.Application.Equals(application) && i.Status.Equals(status)).ToList());
            });

            return result;
        }

        public async Task<Guid> CreateEmail(Guid application, string from, List<string> to, List<string> cc, List<string> bcc, string subject, string body, bool html, int status)
        {
            var result = Guid.Empty;

            var id = Guid.NewGuid();

            var entity = new Entities.Email()
            {
                Id = id,
                Application = application,
                From = from,
                Subject = subject,
                Body = body,
                HTML = html,
                Status = status,
            };

            foreach (var i in to)
            {
                entity.To.Add(new Entities.EmailAddress() { EmailId = id, Address = i });
            }

            foreach (var i in cc)
            {
                entity.To.Add(new Entities.EmailAddress() { EmailId = id, Address = i, Copy = true });
            }

            foreach (var i in bcc)
            {
                entity.To.Add(new Entities.EmailAddress() { EmailId = id, Address = i, Blind = true });
            }

            await db.Emails.AddAsync(entity);

            if (await db.SaveChangesAsync() > 0)
            {
                result = id;
            }

            return result;
        }

        public async Task<bool> UpdateEmail(Guid id, int status)
        {
            var result = false;

            var entity = db.Emails.FirstOrDefault(i => i.Id.Equals(id));

            if (entity != null)
            {
                entity.Status = status;
            }

            result = await db.SaveChangesAsync() > 0;

            return result;
        }

        public async Task<bool> DeleteEmail(Guid id)
        {
            var result = false;

            db.Emails.Remove(db.Emails.FirstOrDefault(i => i.Id.Equals(id)));

            result = await db.SaveChangesAsync() > 0;

            return result;
        }

        public async Task<bool> DeleteEmailWithStatus(Guid application, int status)
        {
            var result = false;

            db.Emails.RemoveRange(db.Emails.Where(i => i.Application.Equals(application) && i.Status.Equals(status)));

            result = await db.SaveChangesAsync() > 0;

            return result;
        }
    }
}