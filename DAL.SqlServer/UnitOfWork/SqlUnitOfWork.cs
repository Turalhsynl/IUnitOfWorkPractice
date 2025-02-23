using DAL.SqlServer.Context;
using DAL.SqlServer.Infastructure;
using Repository.Common;
using Repository.Repositories;

namespace DAL.SqlServer.UnitOfWork;

public class SqlUnitOfWork(string connectionString, AppDbContext context) : IUnitOfWork
{
    private readonly string _connectionString = connectionString;
    private readonly AppDbContext _context = context;

    public SqlCustomerRepository sqlCustomerRepository;
    public SqlProductRepository sqlProductRepository;

    public ICustomerRepository CustomerRepository => sqlCustomerRepository ?? new SqlCustomerRepository(_connectionString, _context);

    public IProductRepository ProductRepository => sqlProductRepository ?? new SqlProductRepository(_context, _connectionString);
}

