using EfDemo.Api.DTOs;
using EfDemo.Domain;
using EfDemo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly EfDemoDbContext _context;

        public AuthorController(EfDemoDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthors()
        {
            var authors = await _context.Set<Author>()
                .Select(x => new AuthorDTO
                {
                    AuthorId = x.AuthorId,
                    FirstName = x.FirstName,
                    LastName = x.LastName
                })
                .ToListAsync();

            return Ok(authors);
        }
    }
}
