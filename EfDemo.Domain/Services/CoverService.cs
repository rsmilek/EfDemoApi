using EfDemo.Domain.Abstractions;
using EfDemo.Domain.Entities;

namespace EfDemo.Domain.Services
{
    public class CoverService : ServiceBase, ICoverService
    {

        public CoverService(EfDemoDbContext context) : base(context)
        { }

        public async Task<Cover> AddAsync(Cover cover)
        {
            await Context.AddAsync(cover);
            await Context.SaveChangesAsync();

            return cover;
        }
    }
}
