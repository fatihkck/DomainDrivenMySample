using Domain.Customers;
using System.Collections;
using System.Collections.Generic;

namespace ApplicationServices.Interfaces
{
    public interface ICustomerService
    {
        bool AddCustomer(string name, string city);
        IEnumerable<Customer> Getlist();

        bool AddCustomerAll(IEnumerable<Customer> customers);

        bool RemoveCustomerAll(IEnumerable<Customer> customers);


    }
}
