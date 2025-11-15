using NosCore.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NosCore.Algorithm.DistanceDefenceService
{
    /// <summary>
    /// Service for calculating distance combat defence values
    /// </summary>
    public interface IDistanceDefenceService
    {
        /// <summary>
        /// Gets the distance defence value for a character class at a specific level
        /// </summary>
        /// <param name="entityClass">The character class type</param>
        /// <param name="level">The character level</param>
        /// <returns>The distance defence value</returns>
        long GetDistanceDefence(CharacterClassType entityClass, byte level);
    }
}
