using NosCore.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NosCore.Algorithm.HitDodgeService
{
    /// <summary>
    /// Service for calculating close combat dodge values
    /// </summary>
    public interface IHitDodgeService
    {
        /// <summary>
        /// Gets the close combat dodge value for a character class at a specific level
        /// </summary>
        /// <param name="entityClass">The character class type</param>
        /// <param name="level">The character level</param>
        /// <returns>The close combat dodge value</returns>
        long GetHitDodge(CharacterClassType entityClass, byte level);
    }
}
