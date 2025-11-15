//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.MpService
{
    /// <summary>
    /// Service for calculating mana point (MP) values for different character classes
    /// </summary>
    public interface IMpService
    {
        /// <summary>
        /// Gets the MP value for a character class at a specific level
        /// </summary>
        /// <param name="entityClass">The character class type</param>
        /// <param name="level">The character level</param>
        /// <returns>The MP value</returns>
        long GetMp(CharacterClassType entityClass, byte level);
    }
}