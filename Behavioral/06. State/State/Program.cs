using State.Models;
using System;

namespace State
{
    class Program
    {
        static void Main(string[] args)
        {
            BookingContext b = new();
            Console.WriteLine();
            while (true)
            {
                var key = Console.ReadKey();

                if (key.KeyChar == 'q')
                {
                    return;
                }

                if (key.KeyChar == 'c')
                {
                    b.Cancel();
                }

                if (key.KeyChar == 'p')
                {
                    b.DatePassed();
                }

                if (key.KeyChar == 's')
                {
                    b.SubmitDetails("New Attendee", 5);
                }
            }
        }
    }
}
