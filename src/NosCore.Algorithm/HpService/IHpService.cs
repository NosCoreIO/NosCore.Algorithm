//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.HpService
{
    /// <summary>
    /// Service for calculating health point (HP) values for different character classes
    /// </summary>
    public interface IHpService
    {
        /// <summary>
        /// Gets the HP value for a character class at a specific level
        /// </summary>
        /// <param name="entityClass">The character class type</param>
        /// <param name="level">The character level</param>
        /// <returns>The HP value</returns>
        long GetHp(CharacterClassType entityClass, byte level);
    }
}