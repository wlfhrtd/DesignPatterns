using Adapter.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Adapter._03._TwoProviderClasses
{
    public class StarWarsCharacterDisplayService
    {
        public async Task<string> ListCharacters(CharacterSource source)
        {
            List<Person> people;
            // source services have different method names ~~ different interfaces
            // that leads to implementing and applying Adapter pattern;
            // extract common interface first - currently both services return await List<Person> people
            if (source == CharacterSource.File)
            {
                string filePath = @"People.json";
                var characterSource = new CharacterFileSource();
                people = await characterSource.GetCharactersFromFile(filePath);
            }
            else if (source == CharacterSource.Api)
            {
                var swapiSource = new StarWarsApi();
                people = await swapiSource.GetCharacters();
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
