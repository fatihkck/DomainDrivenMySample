using Domain.Customers;
using Infrastructure.Repository;
using Persistence.EntityFramework.Database;
using System.Data.Entity;

namespace Persistence.EntityFramework.Repositories.Customers
{
    public class CustomerRepository : Repository<Customer, int>, ICustomerRepository
    {
        public CustomerRepository(IObjectContextFactory contextFactory) :
            base(contextFactory)
        {

        }
    }
}
