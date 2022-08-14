﻿using System;

namespace Mediator.Structural
{
    public class Colleague2 : Colleague
    {
        // ORIGINAL
        //public Colleague2(Mediator mediator) : base(mediator)
        //{
        //}


        public override void HandleNotification(string message)
        {
            Console.WriteLine($"Colleague2 receives notification message: {message}");
        }
    }
}
