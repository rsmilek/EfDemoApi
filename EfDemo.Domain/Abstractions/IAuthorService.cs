using EfDemo.Domain.Entities;

namespace EfDemo.Domain.Abstractions
{
    public interface IAuthorService
    {
        Task<Author> AddAsync(Author author);

        Task<Author> GetAsync(int authorId);
    }
}
