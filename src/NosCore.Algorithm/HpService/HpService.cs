//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;
using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.HpService
{
    /// <summary>
    /// Provides health point (HP) value calculations for different character classes and levels
    /// </summary>
    public class HpService : IHpService
    {
        private readonly long[,] _hpData = new long[Constants.ClassCount, Constants.MaxLevel];

        /// <summary>
        /// Constants used in HP calculations for each character class
        /// </summary>
        public readonly int[] ClassConstants = { 0, 8, 3, 0, 5 };

        /// <summary>
        /// Initializes a new instance of the HpService and pre-calculates HP values for all character classes and levels
        /// </summary>
        public HpService()
        {
            foreach (CharacterClassType classType in Enum.GetValues(typeof(CharacterClassType)))
            {
                for (var i = 0; i < Constants.MaxLevel; i++)
                {
                    var hpx = i + 1 + Math.Floor(i * (double)(ClassConstants[(int)classType]) / 10);
                    var hp = (0.5 * Math.Pow(hpx, 2)) + (15.5 * hpx) + 205;
                    _hpData[(int)classType, i] = (long)hp;
                }
            }
        }

        /// <summary>
        /// Gets the HP value for a character class at a specific level
        /// </summary>
        /// <param name="class">The character class type</param>
        /// <param name="level">The character level</param>
        /// <returns>The HP value</returns>
        public long GetHp(CharacterClassType @class, byte level)
        {
            return _hpData![(byte)@class, level-1];
        }
    }
}
