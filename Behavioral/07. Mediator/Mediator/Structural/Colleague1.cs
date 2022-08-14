using System;

namespace Mediator.Structural
{
    public class Colleague1 : Colleague
    {
        // ORIGINAL
        //public Colleague1(Mediator mediator) : base(mediator)
        //{
        //}


        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Colleague1 receives notification message: {message}");
        }
    }
}
