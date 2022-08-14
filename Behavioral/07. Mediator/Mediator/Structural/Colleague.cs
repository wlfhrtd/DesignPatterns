namespace Mediator.Structural
{
    public abstract class Colleague
    {
        protected Mediator mediator;

        // ORIGINAL
        //protected Colleague(Mediator m)
        //{
        //    mediator = m;
        //}

        internal void SetMediator(Mediator m)
        {
            mediator = m;
        }

        public virtual void Send(string message)
        {
            mediator.Send(message, this);
        }

        public abstract void HandleNotification(string message);
    }
}
