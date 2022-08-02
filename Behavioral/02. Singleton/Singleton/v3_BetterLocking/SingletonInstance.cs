﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;


namespace Singleton.v3_BetterLocking
{
    public class SingletonInstance
    {
        private readonly ITestOutputHelper output;


        public SingletonInstance(ITestOutputHelper helper)
        {
            output = helper;
            SingletonTestHelpers.Reset(typeof(Singleton));
            Logger.Clear();
        }


        [Fact]
        public void ReturnsNonNullSingletonInstance()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<Singleton>());

            var result = Singleton.Instance;

            Assert.NotNull(result);
            Assert.IsType<Singleton>(result);

            Logger.Output().ToList().ForEach(h => output.WriteLine(h));
        }

        [Fact]
        public void OnlyCallsConstructorOnceGivenThreeInstanceCalls()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<Singleton>());

            // configure logger to slow down the creation longer than pauses below
            Logger.DelayMilliseconds = 10;

            var one = Singleton.Instance;
            Thread.Sleep(1);
            var two = Singleton.Instance;
            Thread.Sleep(1);
            var three = Singleton.Instance;

            var log = Logger.Output();
            Assert.Equal(1, log.Count(log => log.Contains("Constructor")));
            Assert.Equal(3, log.Count(log => log.Contains("Instance")));

            Logger.Output().ToList().ForEach(h => output.WriteLine(h));
        }

        [Fact]
        public void CallsConstructorMultipleTimesGivenThreeParallelInstanceCalls()
        {
            Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<Singleton>());

            // configure logger to slow down the creation long enough to cause problems
            Logger.DelayMilliseconds = 50;

            var strings = new List<string>() { "one", "two", "three" };
            var instances = new List<Singleton>();
            var options = new ParallelOptions() { MaxDegreeOfParallelism = 3 }; // 3 threads

            Parallel.ForEach(strings, options, instance =>
            {
                instances.Add(Singleton.Instance);
            });

            var log = Logger.Output();

            try
            {
                Assert.Equal(1, log.Count(log => log.Contains("Constructor")));
                Assert.Equal(3, log.Count(log => log.Contains("Instance")));
            }
            finally
            {
                Logger.Output().ToList().ForEach(h => output.WriteLine(h));
            }
        }
    }
}
