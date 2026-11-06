//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.SpUpgradeService
{
    /// <summary>
    /// Service for retrieving what upgrading a specialist card costs and how likely each attempt is to succeed
    /// </summary>
    public interface ISpUpgradeService
    {
        /// <summary>
        /// Gets the highest upgrade level a specialist card can reach
        /// </summary>
        byte MaxUpgrade { get; }

        /// <summary>
        /// Gets the chance that an attempt from a specific upgrade level succeeds
        /// </summary>
        /// <param name="upgrade">The card's current upgrade level</param>
        /// <returns>The success rate as a percentage</returns>
        byte GetSuccessRate(byte upgrade);

        /// <summary>
        /// Gets the chance that an attempt from a specific upgrade level destroys the card's soul.
        /// It is part of the failure rate, not added to it.
        /// </summary>
        /// <param name="upgrade">The card's current upgrade level</param>
        /// <returns>The destruction rate as a percentage</returns>
        byte GetDestructionRate(byte upgrade);

        /// <summary>
        /// Gets the gold cost of an attempt from a specific upgrade level
        /// </summary>
        /// <param name="upgrade">The card's current upgrade level</param>
        /// <returns>The gold cost</returns>
        long GetGoldCost(byte upgrade);

        /// <summary>
        /// Gets the number of Angel's Feathers an attempt from a specific upgrade level consumes
        /// </summary>
        /// <param name="upgrade">The card's current upgrade level</param>
        /// <returns>The feather cost</returns>
        short GetFeatherCost(byte upgrade);

        /// <summary>
        /// Gets the number of Full Moon Crystals an attempt from a specific upgrade level consumes
        /// </summary>
        /// <param name="upgrade">The card's current upgrade level</param>
        /// <returns>The full moon crystal cost</returns>
        short GetFullMoonCost(byte upgrade);

        /// <summary>
        /// Gets the number of souls a successful attempt from a specific upgrade level consumes
        /// </summary>
        /// <param name="upgrade">The card's current upgrade level</param>
        /// <returns>The soul cost</returns>
        short GetSoulCost(byte upgrade);

        /// <summary>
        /// Gets the card's minimum job level for an attempt from a specific upgrade level
        /// </summary>
        /// <param name="upgrade">The card's current upgrade level</param>
        /// <returns>The minimum job level</returns>
        byte GetMinimumJobLevel(byte upgrade);
    }
}
