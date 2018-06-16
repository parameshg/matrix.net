using System;

namespace Matrix.Framework.Business
{
    public class Service : IService
    {
        public IServiceContext Context { get; }

        public Service(IServiceContext context)
        {
            Context = context ?? throw new ArgumentNullException(nameof(context));
        }
    }
}