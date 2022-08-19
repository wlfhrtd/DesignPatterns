using Adapter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adapter._05._DependencyInjection
{
    public class StarWarsApiCharacterSourceAdapter : ICharacterSourceAdapter
    {
        private StarWarsApi api;

        public StarWarsApiCharacterSourceAdapter(StarWarsApi starWarsApi)
        {
            api = starWarsApi;
        }


        public async Task<IEnumerable<Person>> GetCharacters()
        {
            return await api.GetCharacters();
        }
    }
}
