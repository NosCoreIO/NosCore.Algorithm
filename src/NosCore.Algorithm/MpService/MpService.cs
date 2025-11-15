//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Shared.Enumerations;
using System;

namespace NosCore.Algorithm.MpService
{
    /// <summary>
    /// Provides mana point (MP) value calculations for different character classes and levels
    /// </summary>
    public class MpService : IMpService
    {
        private readonly long[,] _mpData = new long[Constants.ClassCount, Constants.MaxLevel];

        /// <summary>
        /// Constants used in MP calculations for each character class
        /// </summary>
        public readonly int[] ClassConstants = new int[] { 0,  0, 1, 8, 2 };

        /// <summary>
        /// Initializes a new instance of the MpService and pre-calculates MP values for all character classes and levels
        /// </summary>
        public MpService()
        {
            foreach (CharacterClassType classType in Enum.GetValues(typeof(CharacterClassType)))
            {
                for (var i = 0; i < Constants.MaxLevel; i++)
                {
                    var mpx = i + 1 + Math.Floor(i * (double)ClassConstants[(int)classType] / 10);
                    var mp = Math.Floor(9.25 * mpx + 50.75) + ((int)((mpx - 2) / 4) * 2) * (Modulus(mpx - 2, 4) + 1 + (int)((mpx - 6) / 4) * 2);
                    _mpData[(int)classType, i] = (long)mp;
                }
            }
        }

        /// <summary>
        /// Calculates the modulus of two numbers with special handling for negative values
        /// </summary>
        /// <param name="dividend">The dividend</param>
        /// <param name="divisor">The divisor</param>
        /// <returns>The modulus result</returns>
        private static double Modulus(double dividend, double divisor)
        {
            double modulus = (Math.Abs(dividend) - (Math.Abs(divisor) * Math.Floor(Math.Abs(dividend) / Math.Abs(divisor)))) * Math.Sign(dividend);
            return modulus;
        }

        /// <summary>
        /// Gets the MP value for a character class at a specific level
        /// </summary>
        /// <param name="class">The character class type</param>
        /// <param name="level">The character level</param>
        /// <returns>The MP value</returns>
        public long GetMp(CharacterClassType @class, byte level)
        {
            return _mpData![(byte)@class, level - 1];
        }
    }
}
