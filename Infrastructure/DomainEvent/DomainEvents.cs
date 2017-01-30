using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DomainEvent
{
    public static class DomainEvents
    {
        [ThreadStatic] //so that each thread has its own callbacks
        private static List<Delegate> actions;


        //Registers a callback for the given domain event, used for testing only
        public static void Register<T>(Action<T> callback) where T : DomainEventEntity
        {
            if (actions == null)
                actions = new List<Delegate>();

            actions.Add(callback);
        }

        //Clears callbacks passed to Register on the current thread
        public static void ClearCallbacks()
        {
            actions = null;
        }

        //Raises the given domain event
        public static void Raise<T>(T args) where T : DomainEventEntity
        {

            var type = typeof(IHandles<T>);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && p.IsClass).ToList();

            foreach (var item in types)
            {
                dynamic handler = Activator.CreateInstance(item);
                handler.Handle(args);
            }

            //if (Container != null)
            //    foreach (var handler in Container.ResolveAll<IHandles<T>>())
            //        handler.Handle(args);

            if (actions != null)
                foreach (var action in actions)
                    if (action is Action<T>)
                        ((Action<T>)action)(args);
        }
    }

}
