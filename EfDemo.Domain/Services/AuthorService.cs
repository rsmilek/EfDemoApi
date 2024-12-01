using EfDemo.Domain.Abstractions;
using EfDemo.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EfDemo.Domain.Services
{
    public class AuthorService : ServiceBase, IAuthorService
    {

        public AuthorService(EfDemoDbContext context) : base(context)
        { }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await Context.Set<Author>().ToListAsync();
        }

        public async Task<Author> GetAsync(int authorId)
        {
            return await Context.FindAsync<Author>(authorId);
        }

        public async Task<Author> AddAsync(Author author)
        {
            await Context.AddAsync(author);
            await Context.SaveChangesAsync();

            return author;
        }

        public async Task<bool> DeleteAsync(int authorId)
        {
            var author = await Context.Set<Author>().FindAsync(authorId);
            if (author == null)
            {
                return false;
            }

            Context.Set<Author>().Remove(author);
            await Context.SaveChangesAsync();

            return true;
        }

    }
}
