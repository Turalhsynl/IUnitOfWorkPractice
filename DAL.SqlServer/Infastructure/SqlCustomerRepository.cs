using DAL.SqlServer.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories;

namespace DAL.SqlServer.Infastructure;

public class SqlCustomerRepository(string connectionString, AppDbContext context) : BaseSqlRepository(connectionString), ICustomerRepository
{
    private readonly AppDbContext _context = context;

    public async Task AddAsync(Customer customer)
    {
        await _context.Customers.AddAsync(customer);
    }

    public async Task Delete(int id)
    {
        var user = await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);

        user.IsDeleted = true;
        user.DeletedDate = DateTime.Now;
        user.DeletedBy = 0;
    }

    public IQueryable<Customer> GetAll()
    {
        return _context.Customers;
    }

    public async Task<Customer> GetByIdAsync(int id)
    {
        return await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
    }

    public void Update(Customer customer)
    {
        customer.UpdatedDate = DateTime.Now;
        _context.Update(customer);
    }
}
