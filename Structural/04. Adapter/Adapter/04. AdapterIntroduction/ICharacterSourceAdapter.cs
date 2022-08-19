using Adapter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adapter._04._AdapterIntroduction
{
    public interface ICharacterSourceAdapter
    {
        Task<IEnumerable<Person>> GetCharacters();
    }
}
