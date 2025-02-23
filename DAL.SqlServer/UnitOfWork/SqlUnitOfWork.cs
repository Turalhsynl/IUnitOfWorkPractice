using Repository.Common;
using Repository.Repositories;

namespace DAL.SqlServer.UnitOfWork;

public class SqlUnitOfWork : IUnitOfWork
{
    public ICustomerRepository CustomerRepository => throw new NotImplementedException();

    public IProductRepository ProductRepository => throw new NotImplementedException();
}
