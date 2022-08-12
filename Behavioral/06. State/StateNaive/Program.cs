using StateNaive.Models;
using System;

namespace StateNaive
{
    class Program
    {
        static void Main(string[] args)
        {
            Booking b = new();
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
                    b.DataPassed();
                }

                if (key.KeyChar == 's')
                {
                    b.SubmitDetails("New Attendee", 5);
                }
            }
        }
    }
}
