using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;


namespace Singleton
{
    public static class Logger
    {
        private static ConcurrentQueue<string> log = new ConcurrentQueue<string>();

        public static int DelayMilliseconds { get; set; } = 0;

        public static void Log(string message)
        {
            System.Threading.Thread.Sleep(DelayMilliseconds);
            log.Enqueue(message);
        }

        public static void Clear()
        {
            log.Clear();
        }

        public static string StringDump()
        {
            return string.Join(Environment.NewLine, log);
        }

        public static List<string> Output()
        {
            return log.ToList();
        }
    }
}
