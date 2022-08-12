using StateNaive.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StateNaive.Models
{
    public class Booking
    {
        public string Attendee { get; set; }

        public int TicketCount { get; set; }

        public int Id { get; set; }

        private CancellationTokenSource cancellationTokenSource;
        // for business rules implementation
        private bool isNew;
        // another rule
        private bool isPending;
        // another business rule
        private bool isBooked;

        public Booking()
        {
            Id = new Random().Next();
            ShowState("New");
            isNew = true;
        }

        // no business logic
        //public void SubmitDetails(string attendee, int ticketCount)
        //{
        //    Attendee = attendee;
        //    TicketCount = ticketCount;

        //    cancellationTokenSource = new CancellationTokenSource();

        //    BookingProcessing.ProcessBooking(this, ProcessingComplete, cancellationTokenSource);

        //    ShowState("Pending");
        //    Console.WriteLine("Processing Booking");
        //}

        // naive business logic implementation
        public void SubmitDetails(string attendee, int ticketCount)
        {
            if (isNew)
            {
                isNew = false;
                isPending = true;

                Attendee = attendee;
                TicketCount = ticketCount;

                cancellationTokenSource = new CancellationTokenSource();

                BookingProcessing.ProcessBooking(this, ProcessingComplete, cancellationTokenSource);

                ShowState("Pending");
                Console.WriteLine("Processing Booking");
            }
        }

        // problem: we can change state indifferently new - closed_by_user - closed_expired
        // although we may have requirement to track business logic
        // naive solution: introduce boolean isNew

        // real problem: introducing every new business rule with naive approach
        // requires to change code in several places + code repetition
        // + logic becomes hard to maintain + 0 extensibility

        // no business logic
        //public void Cancel()
        //{
        //    ShowState("Closed");
        //    Console.WriteLine("Canceled by user");
        //}

        // naive business logic enforcement
        public void Cancel()
        {
            if (isNew == true)
            {
                ShowState("Closed");
                Console.WriteLine("Canceled by user");
                isNew = false;
            }
            // introduce another business rule
            else if (isPending)
            {
                cancellationTokenSource.Cancel();
            }
            // another rule
            else if (isBooked)
            {
                ShowState("Closed");
                Console.WriteLine("Booking canceled: Expect a refund");
                isBooked = false;
            }
            else
            {
                Console.WriteLine("Closed bookings cannot be canceled");
            }
        }

        // no business logic
        //public void DataPassed()
        //{
        //    ShowState("Closed");
        //    Console.WriteLine("Booking expired");
        //}

        // naive business logic enforcement
        public void DataPassed()
        {
            if (isNew)
            {
                ShowState("Closed");
                Console.WriteLine("Booking expired");
                isNew = false;
            }
            // another rule
            else if (isBooked)
            {
                ShowState("Closed");
                Console.WriteLine("Enjoy your event");
                isBooked = false;
            }
        }

        public void ProcessingComplete(Booking booking, ProcessingResult result)
        {
            // another business rule
            isPending = false;

            switch (result)
            {
                case ProcessingResult.Success:
                    isBooked = true; // another rule
                    ShowState("Booked");
                    Console.WriteLine("Enjoy the Event");
                    break;
                case ProcessingResult.Fail:
                    Console.WriteLine("Processing failed. Enter a new booking");
                    Attendee = string.Empty;
                    TicketCount = 0;
                    Id = new Random().Next();
                    isNew = true; // naive business rule implementation
                    ShowState("New");
                    break;
                case ProcessingResult.Cancel:
                    ShowState("Closed");
                    Console.WriteLine("Processing Canceled");
                    break;
            }
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
