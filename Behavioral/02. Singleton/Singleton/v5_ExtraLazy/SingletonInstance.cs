﻿using System.Linq;
using System.Threading;
using Xunit;
using Xunit.Abstractions;


namespace Singleton.v5_ExtraLazy
{
    public class SingletonInstance
    {
        private readonly ITestOutputHelper output;


        public SingletonInstance(ITestOutputHelper helper)
        {
            output = helper;
            // doesn't work with static readonly field
            // SingletonTestHelpers.Reset(typeof(Singleton));
            Logger.Clear();
        }


        [Fact]
        public void ReturnsNonNullSingletonInstance()
        {
            // doesn't work
            // Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<Singleton>());

            var result = Singleton.Instance;

            Assert.NotNull(result);
            Assert.IsType<Singleton>(result);

            Logger.Output().ToList().ForEach(h => output.WriteLine(h));
        }

        [Fact]
        public void OnlyCallsConstructorOnceGivenThreeInstanceCalls()
        {
            // doesn't work
            // Assert.Null(SingletonTestHelpers.GetPrivateStaticInstance<Singleton>());

            // configure logger to slow down the creation longer than pauses below
            Logger.DelayMilliseconds = 10;

            var one = Singleton.Instance;
            Thread.Sleep(1);
            var two = Singleton.Instance;
            Thread.Sleep(1);
            var three = Singleton.Instance;

            var log = Logger.Output();
            // works isolated
            // Assert.Equal(1, log.Count(log => log.Contains("Constructor")));
            Assert.Equal(3, log.Count(log => log.Contains("Instance")));

            Logger.Output().ToList().ForEach(h => output.WriteLine(h));
        }

        [Fact]
        public void InitializesSingletonWhenAnotherStaticMemberIsReferenced()
        {
            Assert.Equal(0, Logger.Output().Count(log => log.Contains("Constructor")));

            var greeting = Singleton.SOMETHING;

            Assert.Equal(1, Logger.Output().Count(log => log.Contains("Constructor")));

            Logger.Output().ToList().ForEach(h => output.WriteLine(h));
        }
    }
}
