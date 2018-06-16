using System;

namespace Matrix.Framework.Database
{
    public class Repository : IRepository
    {
        public IRepositoryContext Context { get; }

        public Repository(IRepositoryContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}