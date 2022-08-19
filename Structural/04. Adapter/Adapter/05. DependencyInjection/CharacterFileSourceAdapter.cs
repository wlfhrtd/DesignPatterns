using Adapter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adapter._05._DependencyInjection
{
    public class CharacterFileSourceAdapter : ICharacterSourceAdapter
    {
        private string fileName;
        private CharacterFileSource fileSource;

        public CharacterFileSourceAdapter(string fullPath, CharacterFileSource characterFileSource)
        {
            fileName = fullPath;
            fileSource = characterFileSource;
        }


        public async Task<IEnumerable<Person>> GetCharacters()
        {
            return await fileSource.GetCharactersFromFile(fileName);
        }
    }
}
