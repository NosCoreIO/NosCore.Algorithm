using NosCore.Algorithm.HpService;
using System;
using System.Collections.Generic;
using System.Text;

namespace NosCore.Algorithm.DamageService
{
    // Work in progress
    public class DamageMinMaxService : IDamageMinMaxService
    {
        private readonly double[,] _minDamage = new double[Constants.ClassCount, Constants.MaxLevel];
        private readonly double[,] _maxDamage = new double[Constants.ClassCount, Constants.MaxLevel];

        public DamageMinMaxService()
        {
            // Adventurer Damage from Opennos
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                _minDamage[0, i] = i + 9;
            }

            // Swordman
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                _minDamage[4, i] = i + 9;
            }

            // Archer
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                _minDamage[2, i] = i + 9;
            }

            // Magician
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                _minDamage[3, i] = i + 9;
            }

            // Fighter
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                _minDamage[0, i] = i + 9;
            }
        }

        public long GetMinDamage(byte @class, byte level)
        {
            return (long)_minDamage![@class, level - 1];
        }

        public long GetMaxDamage(byte @class, byte level)
        {
            return (long)_maxDamage![@class, level - 1];
        }
    }
}
