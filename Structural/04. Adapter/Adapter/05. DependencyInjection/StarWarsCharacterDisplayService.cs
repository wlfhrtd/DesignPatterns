using Adapter.Models;
using System.Text;
using System.Threading.Tasks;

namespace Adapter._05._DependencyInjection
{
    public class StarWarsCharacterDisplayService
    {
        private readonly ICharacterSourceAdapter characterSource;

        public StarWarsCharacterDisplayService(ICharacterSourceAdapter characterSourceAdapter)
        {
            characterSource = characterSourceAdapter;
        }


        public async Task<string> ListCharacters()
        {
            var people = await characterSource.GetCharacters();

            var sb = new StringBuilder();
            int nameWidth = 30;
            sb.AppendLine($"{"NAME".PadRight(nameWidth)}   {"HAIR"}");

            foreach (Person person in people)
            {
                sb.AppendLine($"{person.Name.PadRight(nameWidth)}   {person.HairColor}");
            }

            return sb.ToString();
        }
    }
}
