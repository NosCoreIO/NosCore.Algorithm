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
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                _hitRate[(byte)CharacterClassType.Adventurer, i] = i + 10;
            }

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

                _hitRate[(byte)CharacterClassType.Swordman, i] = swordHitRate;
            }

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

            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                _hitRate[(byte)CharacterClassType.Magician, i] = 0;
            }

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

                _hitRate[(byte)CharacterClassType.MartialArtist, i] = fighterHitRate;
            }
        }

        public long GetHitRate(CharacterClassType @class, byte level)
        {
            return (long)_hitRate![(byte)@class, level - 1];
        }
    }
}
