using Infrastructure.DomainEvent;
using System;

namespace ApplicationServices.Implementations.Customers.Events
{
    public class CheckedOutEntity : DomainEventEntity
    {
        public override void Flatten()
        {
            throw new NotImplementedException();
        }
    }
}
