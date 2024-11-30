using EfDemo.Domain.Abstractions;
using EfDemo.Domain.Entities;

namespace EfDemo.Domain.Services
{
    public class BookService : ServiceBase, IBookService
    {
        private readonly IAuthorService _authorService;

        public BookService(EfDemoDbContext context, IAuthorService authorService) : base(context)
        {
            _authorService = authorService ?? throw new ArgumentNullException(nameof(authorService));
        }

        public async Task<Book> AddToAuthorByIdAsync(int authorId, Book book)
        {
            book.Author = await _authorService.GetAsync(authorId);

            await Context.AddAsync(book);
            await Context.SaveChangesAsync();

            return book;
        }
    }
}
