using NosCore.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NosCore.Algorithm.MagicDefenceService
{
    /// <summary>
    /// Service for calculating magic defence values for different character classes
    /// </summary>
    public interface IMagicDefenceService
    {
        /// <summary>
        /// Gets the magic defence value for a character class at a specific level
        /// </summary>
        /// <param name="entityClass">The character class type</param>
        /// <param name="level">The character level</param>
        /// <returns>The magic defence value</returns>
        long GetMagicDefence(CharacterClassType entityClass, byte level);
    }
}
