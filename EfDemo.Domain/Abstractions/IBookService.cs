using EfDemo.Domain.Entities;

namespace EfDemo.Domain.Abstractions
{
    public interface IBookService
    {
        Task<Book> AddToAuthorByIdAsync(int authorId, Book book);
    }
}
