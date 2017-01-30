using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DomainEvent
{
    public interface IHandles<T>
   where T : DomainEventEntity
    {
        void Handle(T args);
    }

}
