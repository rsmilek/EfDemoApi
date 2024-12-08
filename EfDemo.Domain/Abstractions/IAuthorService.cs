using EfDemo.Domain.Entities;

namespace EfDemo.Domain.Abstractions
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAll();

        Task<Author?> GetAsync(int authorId);

        Task<Author> AddAsync(Author author);

        Task<bool> DeleteAsync(int authorId);
    }
}
