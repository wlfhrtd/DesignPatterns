using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace Proxy._01._VirtualProxy.Tests
{
    public class LazyExpensiveToFullyLoadConstructor
    {
        private readonly ITestOutputHelper output;
        public LazyExpensiveToFullyLoadConstructor(ITestOutputHelper outputHelper)
        {
            output = outputHelper;
        }

        [Fact]
        public void LogsConstructionToHistory()
        {
            var obj = new LazyExpensiveToFullyLoad();

            Assert.Equal("Constructor called.", obj.History.Last());
            WriteHistory(obj);
        }

        [Fact]
        public void LogsCollectionLoadingToHistory()
        {
            var obj = new LazyExpensiveToFullyLoad();
            output.WriteLine("Initial object created history:");
            WriteHistory(obj);

            var list = obj.HomeEntities;
            Assert.Equal(2, obj.History.Count());
            output.WriteLine("Access HomeEntities. Now history:");
            WriteHistory(obj);

            var anotherList = obj.AwayEntities;
            Assert.Equal(3, obj.History.Count());
            output.WriteLine("Access AwayEntities. Now history:");
            WriteHistory(obj);
        }

        private void WriteHistory(LazyExpensiveToFullyLoad obj)
        {
            obj.History.ForEach(h => output.WriteLine(h));
        }
    }
}
