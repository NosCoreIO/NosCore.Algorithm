//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.EquipmentUpgradeService
{
    /// <summary>
    /// Service for retrieving what upgrading a weapon or armour costs and how likely each attempt is to succeed.
    /// An attempt either succeeds, fixes the item at its current level, or fails.
    /// </summary>
    public interface IEquipmentUpgradeService
    {
        /// <summary>
        /// Gets the highest upgrade level a weapon or armour can reach
        /// </summary>
        byte MaxUpgrade { get; }

        /// <summary>
        /// Gets the chance that an attempt from a specific upgrade level succeeds
        /// </summary>
        /// <param name="upgrade">The item's current upgrade level</param>
        /// <param name="rarity">The item's rarity</param>
        /// <returns>The success rate as a percentage</returns>
        double GetSuccessRate(byte upgrade, sbyte rarity);

        /// <summary>
        /// Gets the chance that an attempt from a specific upgrade level fixes the item at that level.
        /// Whatever is neither success nor fixed is failure.
        /// </summary>
        /// <param name="upgrade">The item's current upgrade level</param>
        /// <param name="rarity">The item's rarity</param>
        /// <returns>The fixed rate as a percentage</returns>
        double GetFixedRate(byte upgrade, sbyte rarity);

        /// <summary>
        /// Gets the chance that an attempt from a specific upgrade level fails
        /// </summary>
        /// <param name="upgrade">The item's current upgrade level</param>
        /// <param name="rarity">The item's rarity</param>
        /// <returns>The failure rate as a percentage</returns>
        double GetFailureRate(byte upgrade, sbyte rarity);

        /// <summary>
        /// Gets the gold cost of an attempt from a specific upgrade level
        /// </summary>
        /// <param name="upgrade">The item's current upgrade level</param>
        /// <param name="rarity">The item's rarity</param>
        /// <returns>The gold cost</returns>
        long GetGoldCost(byte upgrade, sbyte rarity);

        /// <summary>
        /// Gets the number of Cella Powder an attempt from a specific upgrade level consumes
        /// </summary>
        /// <param name="upgrade">The item's current upgrade level</param>
        /// <param name="rarity">The item's rarity</param>
        /// <returns>The Cella Powder cost</returns>
        short GetCellaCost(byte upgrade, sbyte rarity);

        /// <summary>
        /// Gets the number of gems an attempt from a specific upgrade level consumes.
        /// Below +5 they are Soul Gems, from +5 on Complete Soul Gems.
        /// </summary>
        /// <param name="upgrade">The item's current upgrade level</param>
        /// <param name="rarity">The item's rarity</param>
        /// <returns>The gem cost</returns>
        short GetGemCost(byte upgrade, sbyte rarity);

        /// <summary>
        /// Tells whether an attempt from a specific upgrade level takes Complete Soul Gems rather than Soul Gems
        /// </summary>
        /// <param name="upgrade">The item's current upgrade level</param>
        /// <returns>True when the attempt takes Complete Soul Gems</returns>
        bool UsesCompleteGem(byte upgrade);
    }
}
