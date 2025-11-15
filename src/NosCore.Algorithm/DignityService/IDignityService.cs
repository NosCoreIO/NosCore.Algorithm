//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.DignityService
{
    /// <summary>
    /// Service for calculating dignity levels and thresholds
    /// </summary>
    public interface IDignityService
    {
        /// <summary>
        /// Gets the dignity level type based on a dignity value
        /// </summary>
        /// <param name="dignity">The dignity value</param>
        /// <returns>The dignity level type</returns>
        DignityType GetLevelFromDignity(short dignity);

        /// <summary>
        /// Gets the dignity value range for a specific dignity level
        /// </summary>
        /// <param name="level">The dignity level type</param>
        /// <returns>A tuple containing the maximum and minimum dignity values for the level</returns>
        (short, short) GetDignity(DignityType level);
    }
}