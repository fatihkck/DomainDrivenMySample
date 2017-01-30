using Domain.Customers;

namespace Persistence.EntityFramework.Configuration
{
    public class CustomerConfiguration:BaseConfiguration<Customer>
    {
        public CustomerConfiguration()
        {

            Property(p => p.Name)
                .HasMaxLength(50);

            Property(p => p.Adress.AddressLine)
                .HasMaxLength(500)
                .HasColumnName("AdressLine");


            Property(p => p.Adress.City)
                .HasMaxLength(50)
                .HasColumnName("City");
        }
    }
}
