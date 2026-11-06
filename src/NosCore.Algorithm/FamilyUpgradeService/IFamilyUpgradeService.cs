//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.FamilyUpgradeService
{
    /// <summary>
    /// Service for the capacities that family upgrades unlock
    /// </summary>
    public interface IFamilyUpgradeService
    {
        /// <summary>
        /// Gets the family warehouse slots at a warehouse upgrade level
        /// </summary>
        /// <param name="level">The warehouse upgrade level, 0 before any upgrade</param>
        /// <returns>The number of slots</returns>
        byte GetWarehouseSize(byte level);

        /// <summary>
        /// Gets the family member limit at a member upgrade level
        /// </summary>
        /// <param name="level">The member upgrade level, 0 before any upgrade</param>
        /// <returns>The maximum number of members</returns>
        byte GetMemberLimit(byte level);
    }
}
