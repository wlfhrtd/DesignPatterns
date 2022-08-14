using System.Collections.Generic;
using System.Linq;

namespace Mediator.Structural
{
    public class ConcreteMediator : Mediator
    {
        // ORIGINAL
        //public Colleague1 Colleague1 { get; set; }
        //public Colleague2 Colleague2 { get; set; }

        //public override void Send(string message, Colleague colleague)
        //{
        //    if (colleague == Colleague1) Colleague2.HandleNotification(message);
        //    else Colleague1.HandleNotification(message);
        //}

        // EXTENSIBLE
        private List<Colleague> colleagues = new();

        public void Register(Colleague colleague)
        {
            colleague.SetMediator(this);
            colleagues.Add(colleague);
        }

        public override void Send(string message, Colleague colleague)
        {
            colleagues.Where(c => c != colleague).ToList().ForEach(c => c.HandleNotification(message));
        }

        // EXTENSIBLE WITH DELEGATING CREATION OF COLLEAGUES TO MEDIATOR ITSELF
        public T CreateColleague<T>() where T : Colleague, new()
        {
            var c = new T();
            c.SetMediator(this);
            colleagues.Add(c);

            return c;
        }
    }
}
