using Adapter.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Adapter._01._Initial
{
    public class StarWarsCharacterDisplayService
    {
        public async Task<string> ListCharacters()
        {
            string filePath = @"People.json";
            var people = JsonConvert.DeserializeObject<List<Person>>(await File.ReadAllTextAsync(filePath));

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
