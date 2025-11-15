//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Shared.Enumerations;
using System;

namespace NosCore.Algorithm.SecondaryDamageService
{
    /// <summary>
    /// Provides secondary weapon damage value calculations for different character classes and levels
    /// </summary>
    public class SecondaryDamageService : ISecondaryDamageService
    {
        private readonly long[,] _secondaryMinDamage = new long[Constants.ClassCount, Constants.MaxLevel];

        /// <summary>
        /// Initializes a new instance of the SecondaryDamageService and pre-calculates secondary damage values for all character classes and levels
        /// </summary>
        public SecondaryDamageService()
        {
            var fighterMin = 28;
            var mageMin = 8;
            var archerMin = 8;
            var swordmanMin = 8;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                _secondaryMinDamage[(byte)CharacterClassType.Adventurer, i] = i + 10;

                swordmanMin += i == 0 || (i - 5) % 10 == 0 || i % 10 == 0 ? 2 : 1;
                _secondaryMinDamage[(byte)CharacterClassType.Swordsman, i] = swordmanMin;

                archerMin += i == 0 || (i - 4) % 10 == 0 || (i - 7) % 10 == 0 || i > 1 && (i - 1) % 10 == 0 ? 2 : 1;
                _secondaryMinDamage[(byte)CharacterClassType.Archer, i] = archerMin;

                mageMin += i == 0 || (i - 5) % 10 == 0 || i % 10 == 0 ? 2 : 1;
                _secondaryMinDamage[(byte)CharacterClassType.Mage, i] = mageMin;

                fighterMin += i == 0 || (i - 4) % 10 == 0 || (i - 7) % 10 == 0 || i > 1 && (i - 1) % 10 == 0 ? 2 : 1;
                _secondaryMinDamage[(byte)CharacterClassType.MartialArtist, i] = fighterMin;
            }
        }

        /// <summary>
        /// Gets the minimum secondary weapon damage value for a character class at a specific level
        /// </summary>
        /// <param name="class">The character class type</param>
        /// <param name="level">The character level</param>
        /// <returns>The minimum secondary weapon damage value</returns>
        public long GetSecondaryMinDamage(CharacterClassType @class, byte level)
        {
            return (long)_secondaryMinDamage![(byte)@class, level - 1];
        }

        /// <summary>
        /// Gets the maximum secondary weapon damage value for a character class at a specific level
        /// </summary>
        /// <param name="class">The character class type</param>
        /// <param name="level">The character level</param>
        /// <returns>The maximum secondary weapon damage value</returns>
        public long GetSecondaryMaxDamage(CharacterClassType @class, byte level) => GetSecondaryMinDamage(@class, level);
    }
}
