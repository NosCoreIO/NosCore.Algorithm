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
    /// <summary>
    /// Service for calculating secondary weapon damage values for different character classes
    /// </summary>
    public interface ISecondaryDamageService
    {
        /// <summary>
        /// Gets the minimum secondary weapon damage value for a character class at a specific level
        /// </summary>
        /// <param name="entityClass">The character class type</param>
        /// <param name="level">The character level</param>
        /// <returns>The minimum secondary weapon damage value</returns>
        long GetSecondaryMinDamage(CharacterClassType entityClass, byte level);

        /// <summary>
        /// Gets the maximum secondary weapon damage value for a character class at a specific level
        /// </summary>
        /// <param name="entityClass">The character class type</param>
        /// <param name="level">The character level</param>
        /// <returns>The maximum secondary weapon damage value</returns>
        long GetSecondaryMaxDamage(CharacterClassType entityClass, byte level);
    }
}
