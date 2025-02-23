using DAL.SqlServer.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;

namespace DAL.SqlServer.Infastructure;

public class SqlProductRepository(AppDbContext context) : IProductRepository
{
    private readonly AppDbContext _context = context;

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task Delete(int id)
    {
        var user = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        user.IsDeleted = true;
        user.DeletedDate = DateTime.Now;
        user.DeletedBy = 0;
    }

    public IQueryable<Product> GetAll()
    {
        return _context.Products;
    }

    public async Task<Product> GetByIdAsync(int id)
    {
        return await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }

    public void Update(Product product)
    {
        product.UpdatedDate = DateTime.Now;
        _context.Update(product);
    }
}
