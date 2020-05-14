//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.HitRateService
{
    public class HitRateService : IHitRateService
    {
        private readonly double[,] _hitRate = new double[Constants.ClassCount, Constants.MaxLevel];
        public HitRateService()
        {
            // Adventurer
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                _hitRate[0, i] = i + 10;
            }

            // Swordman
            int swordHitRate = 23;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                int swordHitRateUp;
                if ((i - 5) % 5 == 0)
                {
                    swordHitRateUp = 2;
                }
                else
                {
                    swordHitRateUp = 1;
                }

                swordHitRate += swordHitRateUp;

                _hitRate[1, i] = swordHitRate;
            }

            // Archer
            int archerHitRate = 31;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                int archerHitRateUp;
                if (i != 96 && i % 2 == 0 || i > 0 && i % 5 == 0)
                {
                    archerHitRateUp = 4;
                }
                else
                {
                    archerHitRateUp = 2;
                }

                archerHitRate += archerHitRateUp;

                _hitRate[2, i] = archerHitRate;
            }

            // Magician
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                _hitRate[3, i] = 0;
            }

            // Fighter
            int fighterHitRate = 8;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                int fighterHitRateUp;
                if (i == 0 || (i - 4) % 10 == 0 || i > 0 && (i - 7) % 10 == 0 || i > 0 && (i - 10) % 10 == 0)
                {
                    fighterHitRateUp = 2;
                }
                else
                {
                    fighterHitRateUp = 1;
                }

                fighterHitRate += fighterHitRateUp;

                _hitRate[4, i] = fighterHitRate;
            }
        }

        public long GetHitRate(CharacterClassType @class, byte level)
        {
            return (long)_hitRate![(byte)@class, level - 1];
        }
    }
}
