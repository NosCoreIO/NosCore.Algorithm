//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.SpeedService
{
    /// <summary>
    /// Service for retrieving base speed values for different character classes
    /// </summary>
    public interface ISpeedService
    {
        /// <summary>
        /// Gets the base speed value for a character class
        /// </summary>
        /// <param name="entityClass">The character class type</param>
        /// <returns>The base speed value</returns>
        byte GetSpeed(CharacterClassType entityClass);
    }
}