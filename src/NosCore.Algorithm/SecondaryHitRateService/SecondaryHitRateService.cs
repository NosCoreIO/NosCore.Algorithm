using NosCore.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NosCore.Algorithm.SecondaryHitRateService
{
    public class SecondaryHitRateService : ISecondaryHitRateService
    {
        private readonly double[,] _secondaryHitRate = new double[Constants.ClassCount, Constants.MaxLevel];

        public SecondaryHitRateService()
        {
            // Adventurer
            int adventurerHit = 18;
            int adventurerHitUp = 2;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                adventurerHit += adventurerHitUp;

                _secondaryHitRate[0, i] = adventurerHit;
            }

            // Swordman
            int swordmanHit = 16;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                int swordmanHitUp;

                if ((i - 5) % 5 == 0)
                {
                    swordmanHitUp = 4;
                }
                else
                {
                    swordmanHitUp = 2;
                }

                swordmanHit += swordmanHitUp;

                _secondaryHitRate[1, i] = swordmanHit;
            }

            // Archer
            int archerHit = 23;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                int archerHitUp;

                if (i > 0 && (i - 1) % 10 == 0 || i > 0 && (i - 3) % 10 == 0 || i > 0 && (i - 5) % 10 == 0 || i > 0 && (i - 8) % 10 == 0)
                {
                    archerHitUp = 1;
                }
                else
                {
                    archerHitUp = 2;
                }

                archerHit += archerHitUp;

                _secondaryHitRate[2, i] = archerHit;
            }

            // Magician
            int mageHit = 16;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                int mageHitUp;

                if ((i - 5) % 5 == 0)
                {
                    mageHitUp = 4;
                }
                else
                {
                    mageHitUp = 2;
                }

                mageHit += mageHitUp;

                _secondaryHitRate[3, i] = mageHit;
            }

            // Fighter
            int fighterHit = 16;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                int fighterHitUp;

                if ((i - 4) % 4 == 0 || (i - 10) % 10 == 0)
                {
                    fighterHitUp = 4;
                }
                else
                {
                    fighterHitUp = 2;
                }

                fighterHit += fighterHitUp;

                _secondaryHitRate[4, i] = fighterHit;
            }
        }

        public long GetSecondaryHitRate(CharacterClassType @class, byte level)
        {
            return (long)_secondaryHitRate![(byte)@class, level - 1];
        }
    }
}
