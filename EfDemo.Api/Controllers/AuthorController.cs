using EfDemo.Api.DTOs;
using EfDemo.Domain;
using EfDemo.Domain.Abstractions;
using EfDemo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EfDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly EfDemoDbContext _context;
        private readonly IAuthorService _authorService;

        public AuthorController(
            EfDemoDbContext context,
            IAuthorService authorService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _authorService = authorService ?? throw new ArgumentNullException(nameof(authorService));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthors()
        {
            var authors = await _authorService.GetAll();
            var authorDtos = authors.Select(x => new AuthorDTO
            {
                AuthorId = x.AuthorId,
                FirstName = x.FirstName,
                LastName = x.LastName
            }).ToList();

            return Ok(authorDtos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDTO>> GetAuthor(int id)
        {
            var author = await _authorService.GetAsync(id);
            
            if (author == null)
            {
                return NotFound();
            }

            var authorDto = new AuthorDTO
            {
                AuthorId = author.AuthorId,
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            return Ok(authorDto);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDTO>> PostAuthor(AuthorDTO authorDto)
        {
            var author = new Author
            {
                FirstName = authorDto.FirstName,
                LastName = authorDto.LastName
            };
            await _authorService.AddAsync(author);
            authorDto.AuthorId = author.AuthorId;

            return CreatedAtAction(nameof(GetAuthors), new { id = authorDto.AuthorId }, authorDto);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var resutl = await _authorService.DeleteAsync(id);

            if (!resutl)
            {
                return NotFound();
            }

            return NoContent();
        }
    }

}
