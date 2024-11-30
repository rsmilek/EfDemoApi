using System;

namespace EfDemo.Domain.Services
{
    public abstract class ServiceBase
    {
        protected EfDemoDbContext Context;

        protected ServiceBase(EfDemoDbContext context)
        {
            Context = context;
        }
    }
}
