using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.Models
{
    class ClosedState : BookingState
    {
        private string reasonClosed;


        public ClosedState(string reason)
        {
            reasonClosed = reason;
        }


        public override void Cancel(BookingContext booking)
        {
            Console.WriteLine("Invalid action for this state");
        }

        public override void DatePassed(BookingContext booking)
        {
            Console.WriteLine("Invalid action for this state");
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {
            Console.WriteLine("Invalid action for this state");
        }

        public override void EnterState(BookingContext booking)
        {
            booking.ShowState("Closed - " + reasonClosed);
        }
    }
}
