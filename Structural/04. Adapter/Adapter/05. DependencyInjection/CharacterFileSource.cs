using Adapter.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Adapter._05._DependencyInjection
{
    public class CharacterFileSource
    {
        public async Task<List<Person>> GetCharactersFromFile(string filename)
        {
            var characters = JsonConvert.DeserializeObject<List<Person>>(await File.ReadAllTextAsync(filename));

            return characters;
        }
    }
}
