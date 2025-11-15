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
    /// <summary>
    /// Service for calculating hit rate values for different character classes
    /// </summary>
    public interface IHitRateService
    {
        /// <summary>
        /// Gets the hit rate value for a character class at a specific level
        /// </summary>
        /// <param name="entityClass">The character class type</param>
        /// <param name="level">The character level</param>
        /// <returns>The hit rate value</returns>
        long GetHitRate(CharacterClassType entityClass, byte level);
    }
}
