using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Adapter._05._DependencyInjection
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
            string filename = @"People.json";
            var service = new StarWarsCharacterDisplayService(
                new CharacterFileSourceAdapter(filename, new CharacterFileSource()));

            var result = await service.ListCharacters();

            output.WriteLine(result);
        }

        [Fact]
        public async Task DisplayCharactersFromApi()
        {
            var service = new StarWarsCharacterDisplayService(
                new StarWarsApiCharacterSourceAdapter(new StarWarsApi()));

            var result = await service.ListCharacters();

            output.WriteLine(result);
        }
    }
}
