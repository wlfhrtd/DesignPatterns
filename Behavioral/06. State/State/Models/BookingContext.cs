using System;


namespace State.Models
{
    public class BookingContext
    {
        public string Attendee { get; set; }

        public int TicketCount { get; set; }

        public int Id { get; set; }
        // reference to State pattern implementation
        // currently possible states: New, Closed, Pending, Booked
        private BookingState currentState;


        public BookingContext()
        {
            TransitionToState(new NewState());
        }


        public void TransitionToState(BookingState state)
        {
            currentState = state;
            currentState.EnterState(this);
        }

        public void SubmitDetails(string attendee, int ticketCount)
        {
            currentState.EnterDetails(this, attendee, ticketCount);
        }

        public void Cancel()
        {
            currentState.Cancel(this);
        }

        public void DatePassed()
        {
            currentState.DatePassed(this);
        }

        public void ShowState(string stateName)
        {
            Console.WriteLine("***** SHOW STATE *****");
            Console.WriteLine($"CurrentState: {stateName}");
            Console.WriteLine($"TicketCount: {TicketCount}");
            Console.WriteLine($"Attendee: {Attendee}");
            Console.WriteLine($"BookingID: {Id}");
        }
    }
}
