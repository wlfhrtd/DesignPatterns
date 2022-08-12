using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace State.Models
{
    class BookedState : BookingState
    {
        public override void Cancel(BookingContext booking)
        {
            booking.TransitionToState(new ClosedState("Canceled: Expect a refund"));
        }

        public override void DatePassed(BookingContext booking)
        {
            booking.TransitionToState(new ClosedState("We hope you enjoyed the event"));
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {
            Console.WriteLine("Not applicable");
        }

        public override void EnterState(BookingContext booking)
        {
            booking.ShowState("Booked");
        }
    }
}
