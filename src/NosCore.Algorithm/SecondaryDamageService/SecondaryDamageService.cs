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
        private readonly double[,] _secondaryMinDamage = new double[Constants.ClassCount, Constants.MaxLevel];

        public SecondaryDamageService()
        {
            // Adventurer
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                _secondaryMinDamage[(byte)CharacterClassType.Adventurer, i] = i + 10;
            }

            int swordmanMin = 8;
            for(var i = 0; i < Constants.MaxLevel; i++)
            {
                int swordmanMinUp;
                if (i == 0 || (i - 5) % 10 == 0 || (i - 10) % 10 == 0)
                {
                    swordmanMinUp = 2;
                }
                else
                {
                    swordmanMinUp = 1;
                }

                swordmanMin += swordmanMinUp;

                _secondaryMinDamage[(byte)CharacterClassType.Swordman, i] = swordmanMin;
            }

            int archerMin = 8;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                int archerMinUp;
                if (i == 0 || (i - 4) % 10 == 0 || i > 0 && (i - 7) % 10 == 0 || i > 1 && (i - 1) % 10 == 0)
                {
                    archerMinUp = 2;
                }
                else
                {
                    archerMinUp = 1;
                }

                archerMin += archerMinUp;

                _secondaryMinDamage[(byte)CharacterClassType.Archer, i] = archerMin;
            }

            int mageMin = 8;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                int mageMinUp;
                if (i == 0 || (i - 5) % 10 == 0 || (i - 10) % 10 == 0)
                {
                    mageMinUp = 2;
                }
                else
                {
                    mageMinUp = 1;
                }

                mageMin += mageMinUp;

                _secondaryMinDamage[(byte)CharacterClassType.Magician, i] = mageMin;
            }

            var fighterMin = 28;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                int fighterMinUp;
                if(i == 0 || (i - 4) % 10 == 0 || i > 0 && (i - 7) % 10 == 0 || i > 1 && (i - 1) % 10 == 0)
                {
                    fighterMinUp = 2;
                }
                else
                {
                    fighterMinUp = 1;
                }

                fighterMin += fighterMinUp;

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
