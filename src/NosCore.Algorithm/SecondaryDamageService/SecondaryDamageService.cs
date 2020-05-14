using System;
using System.Collections.Generic;
using System.Text;

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
                _secondaryMinDamage[0, i] = i + 10;
            }

            // Swordman
            int swordmanMin = 8;
            int swordmanMinUp = 2;
            for(var i = 0; i < Constants.MaxLevel; i++)
            {
                if (i == 0 || (i - 5) % 10 == 0 || (i - 10) % 10 == 0)
                {
                    swordmanMinUp = 2;
                }
                else
                {
                    swordmanMinUp = 1;
                }

                swordmanMin += swordmanMinUp;

                _secondaryMinDamage[1, i] = swordmanMin;
            }

            // Archer
            int archerMin = 8;
            int archerMinUp = 2;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                if (i == 0 || (i - 4) % 10 == 0 || i > 0 && (i - 7) % 10 == 0 || i > 1 && (i - 1) % 10 == 0)
                {
                    archerMinUp = 2;
                }
                else
                {
                    archerMinUp = 1;
                }

                archerMin += archerMinUp;

                _secondaryMinDamage[2, i] = archerMin;
            }

            // Magician
            int mageMin = 8;
            int mageMinUp = 2;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                if (i == 0 || (i - 5) % 10 == 0 || (i - 10) % 10 == 0)
                {
                    mageMinUp = 2;
                }
                else
                {
                    mageMinUp = 1;
                }

                mageMin += mageMinUp;

                _secondaryMinDamage[3, i] = mageMin;
            }

            // Fighter
            int fighterMin = 28;
            int fighterMinUp = 2;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                if(i == 0 || (i - 4) % 10 == 0 || i > 0 && (i - 7) % 10 == 0 || i > 1 && (i - 1) % 10 == 0)
                {
                    fighterMinUp = 2;
                }
                else
                {
                    fighterMinUp = 1;
                }

                fighterMin += fighterMinUp;

                _secondaryMinDamage[4, i] = fighterMin;
            }
        }

        public long GetSecondaryMinDamage(byte @class, byte level)
        {
            return (long)_secondaryMinDamage![@class, level - 1];
        }

        public long GetSecondaryMaxDamage(byte @class, byte level) => GetSecondaryMinDamage(@class, level);
    }
}
