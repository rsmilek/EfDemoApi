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
            var author = await _authorService.GetAsync(authorId);
            if (author == null)
            {
                throw new ArgumentException($"Author with ID {authorId} not found.", nameof(authorId));
            }

            book.Author = author;

            await Context.AddAsync(book);
            await Context.SaveChangesAsync();

            return book;
        }
    }
}
