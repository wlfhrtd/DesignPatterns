using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Adapter._01._Initial
{
    public class Tests
    {
        private readonly ITestOutputHelper output;

        public Tests(ITestOutputHelper outputHelperInterface)
        {
            output = outputHelperInterface;
        }


        [Fact]
        public async Task DisplayCharacters()
        {
            var service = new StarWarsCharacterDisplayService();

            var result = await service.ListCharacters();

            output.WriteLine(result);
        }
    }
}
