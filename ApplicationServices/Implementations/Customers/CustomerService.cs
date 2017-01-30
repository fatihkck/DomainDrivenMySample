using ApplicationServices.Implementations.Customers.Events;
using ApplicationServices.Interfaces;
using Domain.Customers;
using Domain.ValueObjects.Address;
using Infrastructure.DomainEvent;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;

namespace ApplicationServices.Implementations.Customers
{
    public class CustomerService : ImplementationService, ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository,IUnitOfWork unitOfWork)
            :base(unitOfWork)
        {
            if (customerRepository == null) throw new ArgumentNullException("Customer Repository");
            _customerRepository = customerRepository;
        }
        public bool AddCustomer(string name, string city)
        {
            _customerRepository.Add(new Customer
            {

                Name = name,
                Adress = new Address
                {
                    AddressLine = "Test",
                    City = city,
                    PostalCode = "80360"
                }

            });
            UnitOfWork.SaveChanges();
          
            return true;
        }

        public bool AddCustomerAll(IEnumerable<Customer> customers)
        {
            _customerRepository.AddRange(customers);
            UnitOfWork.SaveChanges();
            return true;
        }

        public bool RemoveCustomerAll(IEnumerable<Customer> customers)
        {
            _customerRepository.RemoveRange(customers);
            UnitOfWork.SaveChanges();
            return true;
        }

        public IEnumerable<Customer> Getlist()
        {
            DomainEvents.Raise(new CheckedOutEntity() { CorrelationID = "Test" }); ;
            return _customerRepository.GetAll();

        }

      
    }
}
