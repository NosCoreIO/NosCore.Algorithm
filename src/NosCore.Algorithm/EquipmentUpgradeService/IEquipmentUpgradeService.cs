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
        /// <returns>The success rate as a percentage</returns>
        double GetSuccessRate(byte upgrade);

        /// <summary>
        /// Gets the chance that an attempt from a specific upgrade level fixes the item at that level.
        /// Whatever is neither success nor fixed is failure.
        /// </summary>
        /// <param name="upgrade">The item's current upgrade level</param>
        /// <returns>The fixed rate as a percentage</returns>
        double GetFixedRate(byte upgrade);

        /// <summary>
        /// Gets the chance that an attempt from a specific upgrade level fails
        /// </summary>
        /// <param name="upgrade">The item's current upgrade level</param>
        /// <returns>The failure rate as a percentage</returns>
        double GetFailureRate(byte upgrade);

        /// <summary>
        /// Gets the gold cost of an attempt from a specific upgrade level
        /// </summary>
        /// <param name="upgrade">The item's current upgrade level</param>
        /// <returns>The gold cost</returns>
        long GetGoldCost(byte upgrade);

        /// <summary>
        /// Gets the number of Cella Powder an attempt from a specific upgrade level consumes
        /// </summary>
        /// <param name="upgrade">The item's current upgrade level</param>
        /// <returns>The Cella Powder cost</returns>
        short GetCellaCost(byte upgrade);

        /// <summary>
        /// Gets the number of gems an attempt from a specific upgrade level consumes.
        /// Which gem it is depends on the level, see <see cref="GetGemType"/>.
        /// </summary>
        /// <param name="upgrade">The item's current upgrade level</param>
        /// <returns>The gem cost</returns>
        short GetGemCost(byte upgrade);

        /// <summary>
        /// Gets the gem an attempt from a specific upgrade level consumes
        /// </summary>
        /// <param name="upgrade">The item's current upgrade level</param>
        /// <returns>Soul Gems below +5, Complete Soul Gems from +5 and Dimensional Force from +10</returns>
        UpgradeGemType GetGemType(byte upgrade);

        /// <summary>
        /// Gets the number of Dimensiolith Shards an attempt from a specific upgrade level consumes
        /// </summary>
        /// <param name="upgrade">The item's current upgrade level</param>
        /// <returns>The shard cost, 0 below +10</returns>
        short GetShardCost(byte upgrade);

        /// <summary>
        /// Gets the value at which an item's pity gauge is full and its next attempt cannot fail
        /// </summary>
        short PityGaugeMaximum { get; }

        /// <summary>
        /// Gets how much an attempt from a specific upgrade level that does not succeed fills the item's pity gauge.
        /// It equals the success chance, so a full gauge takes as many misses as the chance's inverse.
        /// </summary>
        /// <param name="upgrade">The item's current upgrade level</param>
        /// <returns>The gauge gain out of <see cref="PityGaugeMaximum"/>, 0 below +10</returns>
        short GetPityGaugeGain(byte upgrade);
    }
}
