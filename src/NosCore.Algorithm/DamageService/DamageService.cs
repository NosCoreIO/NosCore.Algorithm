//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Algorithm.HpService;
using System;
using System.Collections.Generic;
using System.Text;
using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.DamageService
{
    public class DamageService : IDamageService
    {
        private readonly double[,] _minDamage = new double[Constants.ClassCount, Constants.MaxLevel];

        public DamageService()
        {
            // Adventurer
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                _minDamage[0, i] = i + 10;
            }

            // Swordman
            int swordmanMin = 8;
            int swordmanMinUp = 2;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                if (i > 0 && (i - 2) % 10 == 0 || i > 0 && (i - 7) % 10 == 0)
                {
                    swordmanMinUp++;
                }

                if (i > 0 && (i - 1) % 10 == 0 || i > 0 && (i - 6) % 10 == 0)
                {
                    swordmanMinUp--;
                }

                swordmanMin += swordmanMinUp;

                _minDamage[1, i] = swordmanMin;
            }

            // Archer
            int archerMin = 58;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                int archerMinUp;
                if (i > 0 && (i - 1) % 10 == 0 || i > 0 && (i - 3) % 10 == 0 || i > 0 && (i - 5) % 10 == 0 || i > 0 && (i - 8) % 10 == 0)
                {
                    archerMinUp = 1;
                }
                else
                {
                    archerMinUp = 2;
                }

                archerMin += archerMinUp;

                _minDamage[2, i] = archerMin;
            }

            // Magician
            int mageMin = 8;
            int mageMinUp = 2;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                if (i > 0 && (i - 2) % 10 == 0 || i > 0 && (i - 7) % 10 == 0)
                {
                    mageMinUp++;
                }

                if (i > 0 && (i - 1) % 10 == 0 || i > 0 && (i - 6) % 10 == 0)
                {
                    mageMinUp--;
                }

                mageMin += mageMinUp;

                _minDamage[3, i] = mageMin;
            }

            // Fighter
            int fighterMin = 8;
            int fighterMinUp = 2;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                if (i > 0 && (i - 2) % 10 == 0 || i > 0 && (i - 4) % 10 == 0 || i > 0 && (i - 6) % 10 == 0 || i > 0 && (i - 8) % 10 == 0 || i > 0 && (i - 10) % 10 == 0)
                {
                    fighterMinUp++;
                }

                if (i > 0 && (i - 1) % 10 == 0 || i > 0 && (i - 3) % 10 == 0 || i > 0 && (i - 5) % 10 == 0 || i > 0 && (i - 7) % 10 == 0 || i > 0 && (i - 9) % 10 == 0)
                {
                    fighterMinUp--;
                }

                fighterMin += fighterMinUp;

                _minDamage[4, i] = fighterMin;
            }
        }

        public long GetMinDamage(CharacterClassType @class, byte level)
        {
            return (long)_minDamage![(byte)@class, level - 1];
        }

        public long GetMaxDamage(CharacterClassType @class, byte level) => GetMinDamage(@class, level);
    }
}
