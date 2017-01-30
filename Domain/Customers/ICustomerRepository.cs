using Infrastructure.Repository;

namespace Domain.Customers
{
    public interface ICustomerRepository : IRepository<Customer, int>
    {
    }
}
