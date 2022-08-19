using Adapter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adapter._04._AdapterIntroduction
{
    public class StarWarsApiCharacterSourceAdapter : ICharacterSourceAdapter
    {
        private StarWarsApi starWarsApi = new StarWarsApi();

        public async Task<IEnumerable<Person>> GetCharacters()
        {
            return await starWarsApi.GetCharacters();
        }
    }
}
