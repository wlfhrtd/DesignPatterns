using Adapter.Models;
using System;

namespace Adapter._06._ResultWrapper
{
    public class CharacterToPersonAdapter : Person
    {
        private readonly Character character;

        public CharacterToPersonAdapter(Character c)
        {
            character = c ?? throw new ArgumentNullException(nameof(character));
        }

        // of course it requires to make properties virtual in 'convertTo' entity
        // (Person in this case)
        // obviously 'convertTo' entity should not be sealed as adapter is derived from it
        public override string Name
        {
            get => character.FullName;
            set => character.FullName = value;
        }

        public override string HairColor
        {
            get => character.Hair;
            set => character.Hair = value;
        }
    }
}
