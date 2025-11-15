using NosCore.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NosCore.Algorithm.CloseDefenceService
{
    /// <summary>
    /// Service for calculating close combat defence values
    /// </summary>
    public interface ICloseDefenceService
    {
        /// <summary>
        /// Gets the close defence value for a character class at a specific level
        /// </summary>
        /// <param name="entityClass">The character class type</param>
        /// <param name="level">The character level</param>
        /// <returns>The close defence value</returns>
        long GetCloseDefence(CharacterClassType entityClass, byte level);
    }
}
