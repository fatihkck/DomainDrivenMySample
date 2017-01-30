using Infrastructure.DomainEvent;
using System.Diagnostics;

namespace ApplicationServices.Implementations.Customers.Events
{
    public class CustomerCheckedOutNotifyHandle:IHandles<CheckedOutEntity>
    {
        public void Handle(CheckedOutEntity args)
        {
            Debug.WriteLine("notify sending");
        }
    }
}
