using ApplicationServices.Implementations;
using ApplicationServices.Implementations.Customers;
using ApplicationServices.Interfaces;
using ApplicationServices.Model;
using Domain.Customers;
using Infrastructure.Caching;
using Infrastructure.Configuration;
using Infrastructure.Repository;
using Persistence.EntityFramework.Database;
using Persistence.EntityFramework.Repositories;
using Persistence.EntityFramework.Repositories.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsoleApp
{
    public class Person
    {
        public void Complate()
        {
            Console.WriteLine("Complate Run");
        }

    }

    public class Test : Person
    {
        public void Run()
        {
            Console.WriteLine("Test Run running");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {


            Insert();
          

            Console.Read();
            
        }

        public  static void Insert()
        {
            
            var objectContext = new ObjectContextFactory();
            IUnitOfWork _unitOfWork = new UnitOfWork(objectContext);
            ICustomerRepository _customerRepository = new CustomerRepository(objectContext);
            ICustomerService customerService = new CustomerCacheService(new CustomerService(_customerRepository, _unitOfWork), new MemoryCacheManager(), new AppSettingsConfigurationRepository());

            customerService.Getlist();

            

            //List<Customer> customers = new List<Customer>
            //{
            //    new Customer
            //    {
            //        Name = "Fatih",
            //        Adress = new Domain.ValueObjects.Address.Address
            //        {
            //            AddressLine = "Adres",
            //            City = "şehir",
            //            PostalCode = "80360"
            //        }
            //    },
            //    new Customer
            //    {
            //        Name = "Fatih1",
            //        Adress = new Domain.ValueObjects.Address.Address
            //        {
            //            AddressLine = "Adres1",
            //            City = "şehir1",
            //            PostalCode = "803601"
            //        }
            //    },
            //     new Customer
            //    {
            //        Name = "Fatih2",
            //        Adress = new Domain.ValueObjects.Address.Address
            //        {
            //            AddressLine = "Adres2",
            //            City = "şehir2",
            //            PostalCode = "803602"
            //        }
            //    }
            //};

            //customerService.AddCustomerAll(customers);
            var customers = customerService.Getlist().ToList();
            var customers1= customerService.Getlist().ToList();

            //customerService.AddCustomer("Fatih1", "İstanbul1");

            Console.WriteLine("Done");
        }

      
    }
}
