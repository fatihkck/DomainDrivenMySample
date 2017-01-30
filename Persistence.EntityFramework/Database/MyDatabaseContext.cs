using Domain.Customers;
using Persistence.EntityFramework.Configuration;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;

namespace Persistence.EntityFramework.Database
{

    public class MyDatabaseContext:DbContext
    {

        public MyDatabaseContext()
            :base("MyDatabaseContext")
        {

        }


        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            var builder = Assembly
                .GetExecutingAssembly()
                .GetTypes();

            var builderClass = builder
                .Where(p => p.IsClass
                && p.Name.EndsWith("Configuration")
                && p.BaseType.Name == typeof(BaseConfiguration<>).Name).ToList();

            foreach (var type in builderClass)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }
                 
            //base.OnModelCreating(modelBuilder);
        }
    }
}
