using State.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace State.Models
{
    class PendingState : BookingState
    {
        private CancellationTokenSource cancellationTokenSource;

        public override void Cancel(BookingContext booking)
        {
            cancellationTokenSource.Cancel();
        }

        public override void DatePassed(BookingContext booking)
        {
            
        }

        public override void EnterDetails(BookingContext booking, string attendee, int ticketCount)
        {
            
        }

        public override void EnterState(BookingContext booking)
        {
            cancellationTokenSource = new CancellationTokenSource();
            booking.ShowState("Pending");
            BookingProcessing.ProcessBooking(booking, ProcessingComplete, cancellationTokenSource);
        }

        public void ProcessingComplete(BookingContext booking, ProcessingResult result)
        {
            switch (result)
            {
                case ProcessingResult.Success:
                    booking.TransitionToState(new BookedState());
                    break;
                case ProcessingResult.Fail:
                    Console.WriteLine("Processing failed. Enter a new booking");
                    booking.TransitionToState(new NewState());
                    break;
                case ProcessingResult.Cancel:
                    booking.TransitionToState(new ClosedState("Processing Canceled"));
                    break;
            }
        }
    }
}
