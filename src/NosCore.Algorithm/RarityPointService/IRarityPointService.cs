//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.RarityPointService
{
    /// <summary>
    /// Service for the stat points an equipment's rarity adds
    /// </summary>
    public interface IRarityPointService
    {
        /// <summary>
        /// Gets the points an item of a given rarity and level adds to its stats
        /// </summary>
        /// <param name="rarity">The item's rarity</param>
        /// <param name="itemLevel">The item's level</param>
        /// <returns>The rarity points</returns>
        int GetRarityPoint(sbyte rarity, byte itemLevel);
    }
}
