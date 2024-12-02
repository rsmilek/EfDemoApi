using EfDemo.Domain.Entities;

namespace EfDemo.Domain.Abstractions
{
    public interface ICoverService
    {
        Task<Cover> AddAsync(Cover cover);
    }
}
