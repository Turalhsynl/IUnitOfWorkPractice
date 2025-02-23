using Domain.Entities;

namespace Repository.Repositories;

public interface ICustomerRepository
{
    Task AddAsync(Customer customer);
    void Update(Customer customer);
    Task Delete(int id);
    IQueryable<Customer> GetAll();
    Task<Customer> GetByIdAsync(int id);
}
