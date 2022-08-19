using Adapter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adapter._04._AdapterIntroduction
{
    public class CharacterFileSourceAdapter : ICharacterSourceAdapter
    {
        private string fileName;
        private CharacterFileSource fileSource;

        public CharacterFileSourceAdapter(string fullPath)
        {
            fileName = fullPath;
            fileSource = new CharacterFileSource();
        }


        public async Task<IEnumerable<Person>> GetCharacters()
        {
            return await fileSource.GetCharactersFromFile(fileName);
        }
    }
}
