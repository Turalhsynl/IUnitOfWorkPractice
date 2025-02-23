using Domain.Entities;

namespace Repository.Repositories;

public interface IProductRepository
{
    Task AddAsync(Product product);
    void Update(Product product);
    Task Delete(int id);
    IQueryable<Product> GetAll();
    Task<Product> GetByIdAsync(int id);
}
