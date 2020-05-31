using NosCore.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NosCore.Algorithm.DistanceDefenceService
{
    public class DistanceDefenceService : IDistanceDefenceService
    {
        private readonly long[,] _distanceDefence = new long[Constants.ClassCount, Constants.MaxLevel];

        public DistanceDefenceService()
        {
            var adventurerDefence = 4;
            var swordmanDefence = 4;
            var archerDefence = 4;
            var mageDefence = 24;
            var fighterDefence = 14;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                adventurerDefence += i % 2 == 0 ? 1 : 0;
                _distanceDefence[(byte)CharacterClassType.Adventurer, i] = adventurerDefence;

                swordmanDefence += i == 0 || (i - 2) % 10 == 0 || (i - 4) % 10 == 0 || (i - 5) % 5 == 0 || (i - 7) % 10 == 0 || (i - 9) % 10 == 0 ? 1 : 0;
                _distanceDefence[(byte)CharacterClassType.Swordsman, i] = swordmanDefence;

                archerDefence += i == 0 || (i - 2) % 10 == 0 || (i - 3) % 10 == 0 || (i - 4) % 10 == 0 || (i - 5) % 5 == 0 || (i - 7) % 10 == 0 || (i - 8) % 10 == 0 || (i - 9) % 10 == 0 ? 1 : 0;
                _distanceDefence[(byte)CharacterClassType.Archer, i] = archerDefence;

                mageDefence += i == 0 || (i - 2) % 10 == 0 || (i - 4) % 10 == 0 || (i - 5) % 5 == 0 || (i - 7) % 10 == 0 || (i - 9) % 10 == 0 ? 1 : 0;
                _distanceDefence[(byte)CharacterClassType.Mage, i] = mageDefence;

                fighterDefence += i > 0 && ((i - 1) % 20 == 0 || (i - 3) % 20 == 0 || (i - 6) % 20 == 0 || (i - 9) % 20 == 0 || (i - 12) % 20 == 0 || (i - 15) % 20 == 0 || (i - 18) % 20 == 0) ? 0 : 1;
                _distanceDefence[(byte)CharacterClassType.MartialArtist, i] = fighterDefence;
            }
        }

        public long GetDistanceDefence(CharacterClassType @class, byte level)
        {
            return _distanceDefence![(byte)@class, level - 1];
        }
    }
}
