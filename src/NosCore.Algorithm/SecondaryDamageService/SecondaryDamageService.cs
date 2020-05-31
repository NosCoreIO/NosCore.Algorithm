//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.SecondaryDamageService
{
    public class SecondaryDamageService : ISecondaryDamageService
    {
        private readonly long[,] _secondaryMinDamage = new long[Constants.ClassCount, Constants.MaxLevel];

        public SecondaryDamageService()
        {
            var fighterMin = 28;
            var mageMin = 8;
            var archerMin = 8;
            var swordmanMin = 8;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                _secondaryMinDamage[(byte)CharacterClassType.Adventurer, i] = i + 10;

                swordmanMin += i == 0 || (i - 5) % 10 == 0 || i % 10 == 0 ? 2 : 1;
                _secondaryMinDamage[(byte)CharacterClassType.Swordsman, i] = swordmanMin;

                archerMin += i == 0 || (i - 4) % 10 == 0 || (i - 7) % 10 == 0 || i > 1 && (i - 1) % 10 == 0 ? 2 : 1;
                _secondaryMinDamage[(byte)CharacterClassType.Archer, i] = archerMin;

                mageMin += i == 0 || (i - 5) % 10 == 0 || i % 10 == 0 ? 2 : 1;
                _secondaryMinDamage[(byte)CharacterClassType.Mage, i] = mageMin;

                fighterMin += i == 0 || (i - 4) % 10 == 0 || (i - 7) % 10 == 0 || i > 1 && (i - 1) % 10 == 0 ? 2 : 1;
                _secondaryMinDamage[(byte)CharacterClassType.MartialArtist, i] = fighterMin;
            }
        }

        public long GetSecondaryMinDamage(CharacterClassType @class, byte level)
        {
            return (long)_secondaryMinDamage![(byte)@class, level - 1];
        }

        public long GetSecondaryMaxDamage(CharacterClassType @class, byte level) => GetSecondaryMinDamage(@class, level);
    }
}
