using Infrastructure.DomainEvent;
using System.Diagnostics;

namespace ApplicationServices.Implementations.Customers.Events
{
    public class CustomerCheckedOutEmailHandle : IHandles<CheckedOutEntity>
    {
        public void Handle(CheckedOutEntity args)
        {
            Debug.WriteLine("email sending");
        }
    }
}
