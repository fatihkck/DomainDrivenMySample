using ApplicationServices.Interfaces;
using Infrastructure.Caching;
using System;
using System.Collections.Generic;
using Domain.Customers;
using System.Linq;
using Infrastructure.Configuration;

namespace ApplicationServices.Implementations.Customers
{
    public class CustomerCacheService: ImplementationCacheService,ICustomerService
    {
        private readonly ICustomerService _internalCustomerService;


        public CustomerCacheService(ICustomerService internalCustomerService, ICacheManager cacheManager, IConfigurationRepository configurationRepository)
            : base(cacheManager, configurationRepository)
        {
            if (internalCustomerService == null) throw new ArgumentNullException("CustomerService");
            _internalCustomerService = internalCustomerService;

        }

        public bool AddCustomer(string name, string city)
        {
       
            return _internalCustomerService.AddCustomer(name, city);
        }

        public IEnumerable<Customer> Getlist()
        {
            List<Customer> result = new List<Customer>();

            string cacheKey = "CustomerGetList";
            if (!CacheManager.IsSet(cacheKey))
            {

                result = _internalCustomerService.Getlist().ToList();
                int cacheTime = ConfigurationRepository.GetConfigurationValue<int>("CacheMinutesDuration");
                CacheManager.Set(cacheKey, result, cacheTime);

                return result;
            }

            result = CacheManager.Get<List<Customer>>(cacheKey);

            return result;
        }

        public bool AddCustomerAll(IEnumerable<Customer> customers)
        {
            return _internalCustomerService.AddCustomerAll(customers);
        }

        public bool RemoveCustomerAll(IEnumerable<Customer> customers)
        {
            return _internalCustomerService.RemoveCustomerAll(customers);
        }
    }
}
