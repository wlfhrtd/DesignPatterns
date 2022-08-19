﻿using Adapter.Models;
using System;
using System.Text;
using System.Threading.Tasks;

namespace Adapter._04._AdapterIntroduction
{
    public class StarWarsCharacterDisplayService
    {
        public async Task<string> ListCharacters(CharacterSource source)
        {
            ICharacterSourceAdapter characterSource;

            if (source == CharacterSource.File)
            {
                string filePath = @"People.json";
                characterSource = new CharacterFileSourceAdapter(filePath);
            }
            else if (source == CharacterSource.Api)
            {
                characterSource = new StarWarsApiCharacterSourceAdapter();
            }
            else
            {
                throw new Exception("Invalid character source");
            }

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
