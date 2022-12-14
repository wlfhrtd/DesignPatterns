using Adapter.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Adapter._02._TwoProviders
{
    public class StarWarsCharacterDisplayService
    {
        public async Task<string> ListCharacters(CharacterSource source)
        {
            List<Person> people;

            if (source == CharacterSource.File)
            {
                string filePath = @"People.json";
                people = JsonConvert.DeserializeObject<List<Person>>(await File.ReadAllTextAsync(filePath));
            }
            else if (source == CharacterSource.Api)
            {
                using (var client = new HttpClient())
                {
                    string url = "https://swapi.dev/api/people";
                    string result = await client.GetStringAsync(url);
                    people = JsonConvert.DeserializeObject<ApiResult<Person>>(result).Results;
                }
            }
            else
            {
                throw new Exception("Invalid character source");
            }

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
