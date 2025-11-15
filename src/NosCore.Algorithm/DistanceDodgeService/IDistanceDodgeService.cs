using NosCore.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NosCore.Algorithm.DistanceDodgeService
{
    /// <summary>
    /// Service for calculating distance combat dodge values
    /// </summary>
    public interface IDistanceDodgeService
    {
        /// <summary>
        /// Gets the distance dodge value for a character class at a specific level
        /// </summary>
        /// <param name="entityClass">The character class type</param>
        /// <param name="level">The character level</param>
        /// <returns>The distance dodge value</returns>
        long GetDistanceDodge(CharacterClassType entityClass, byte level);
    }
}
