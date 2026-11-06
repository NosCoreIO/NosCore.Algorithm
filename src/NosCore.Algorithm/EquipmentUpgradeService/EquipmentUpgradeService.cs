//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.EquipmentUpgradeService
{
    /// <summary>
    /// Provides the costs and odds of upgrading a weapon or armour from +0 to +10. They do not depend on the item's rarity.
    /// </summary>
    public class EquipmentUpgradeService : IEquipmentUpgradeService
    {
        private const byte FirstCompleteGemUpgrade = 5;

        internal static readonly double[] SuccessRate = { 100, 100, 90, 80, 60, 40, 20, 5, 1.5, 0.6 };
        internal static readonly double[] FixedRate = { 0, 0, 10, 15, 20, 20, 20, 3, 2, 1 };
        internal static readonly long[] GoldCost = { 500, 1500, 3000, 10000, 30000, 80000, 150000, 400000, 700000, 1000000 };
        internal static readonly short[] CellaCost = { 20, 50, 80, 120, 160, 220, 280, 380, 480, 600 };
        internal static readonly short[] GemCost = { 1, 1, 2, 2, 3, 1, 1, 2, 2, 3 };

        /// <inheritdoc />
        public byte MaxUpgrade => Constants.MaxEquipmentUpgrade;

        /// <inheritdoc />
        public double GetSuccessRate(byte upgrade) => SuccessRate[upgrade];

        /// <inheritdoc />
        public double GetFixedRate(byte upgrade) => FixedRate[upgrade];

        /// <inheritdoc />
        public double GetFailureRate(byte upgrade) => 100 - SuccessRate[upgrade] - FixedRate[upgrade];

        /// <inheritdoc />
        public long GetGoldCost(byte upgrade) => GoldCost[upgrade];

        /// <inheritdoc />
        public short GetCellaCost(byte upgrade) => CellaCost[upgrade];

        /// <inheritdoc />
        public short GetGemCost(byte upgrade) => GemCost[upgrade];

        /// <inheritdoc />
        public bool UsesCompleteGem(byte upgrade) => upgrade >= FirstCompleteGemUpgrade;
    }
}
