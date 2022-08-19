using Adapter.Models;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Adapter._04._AdapterIntroduction
{
    public class Tests
    {
        private readonly ITestOutputHelper output;

        public Tests(ITestOutputHelper outputHelperInterface)
        {
            output = outputHelperInterface;
        }


        [Fact]
        public async Task DisplayCharactersFromFile()
        {
            var service = new StarWarsCharacterDisplayService();

            var result = await service.ListCharacters(CharacterSource.File);

            output.WriteLine(result);
        }

        [Fact]
        public async Task DisplayCharactersFromApi()
        {
            var service = new StarWarsCharacterDisplayService();

            var result = await service.ListCharacters(CharacterSource.Api);

            output.WriteLine(result);
        }
    }
}
