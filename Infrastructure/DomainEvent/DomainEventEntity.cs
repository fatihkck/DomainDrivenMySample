using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DomainEvent
{
    public abstract class DomainEventEntity
    {
        public string Type { get { return this.GetType().Name; } }

        public DateTime Created { get; private set; }

        public Dictionary<string, Object> Args { get; private set; }

        public string CorrelationID { get; set; }

        public DomainEventEntity()
        {
            this.Created = DateTime.Now;
            this.Args = new Dictionary<string, Object>();
        }

        public abstract void Flatten();
    }
}
