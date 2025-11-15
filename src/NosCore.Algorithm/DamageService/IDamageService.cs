//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.DamageService
{
    /// <summary>
    /// Service for calculating damage values for different character classes
    /// </summary>
    public interface IDamageService
    {
        /// <summary>
        /// Gets the minimum damage value for a character class at a specific level
        /// </summary>
        /// <param name="entityClass">The character class type</param>
        /// <param name="level">The character level</param>
        /// <returns>The minimum damage value</returns>
        long GetMinDamage(CharacterClassType entityClass, byte level);

        /// <summary>
        /// Gets the maximum damage value for a character class at a specific level
        /// </summary>
        /// <param name="entityClass">The character class type</param>
        /// <param name="level">The character level</param>
        /// <returns>The maximum damage value</returns>
        long GetMaxDamage(CharacterClassType entityClass, byte level);
    }
}