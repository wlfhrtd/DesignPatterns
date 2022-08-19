using Adapter.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Adapter._05._DependencyInjection
{
    public interface ICharacterSourceAdapter
    {
        Task<IEnumerable<Person>> GetCharacters();
    }
}
