using State.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace State.Components
{
    public class BookingProcessing
    {
        public static async void ProcessBooking(BookingContext booking, Action<BookingContext, ProcessingResult> callback, CancellationTokenSource token)
        {

            try
            {
                await Task.Run(async delegate
                {
                    await Task.Delay(new TimeSpan(0, 0, 3), token.Token);
                });
            }
            catch (OperationCanceledException)
            {
                callback(booking, ProcessingResult.Cancel);
                return;
            }

            ProcessingResult result = new Random().Next(0, 2) == 0 ? ProcessingResult.Success : ProcessingResult.Fail;
            callback(booking, result);
        }
    }

    public enum ProcessingResult
    {
        Success,
        Fail,
        Cancel,
    }
}
