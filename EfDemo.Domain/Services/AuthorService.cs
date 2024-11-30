using EfDemo.Domain.Abstractions;
using EfDemo.Domain.Entities;

namespace EfDemo.Domain.Services
{
    public class AuthorService : ServiceBase, IAuthorService
    {

        public AuthorService(EfDemoDbContext context) : base(context)
        { }

        public async Task<Author> AddAsync(Author author)
        {
            await Context.AddAsync(author);
            await Context.SaveChangesAsync();

            return author;
        }

        public async Task<Author> GetAsync(int authorId)
        {
            return await Context.Authors.FindAsync(authorId);
        }
    }
}
