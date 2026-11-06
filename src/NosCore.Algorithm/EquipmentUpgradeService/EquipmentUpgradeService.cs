//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.EquipmentUpgradeService
{
    /// <summary>
    /// Provides the costs and odds of upgrading a weapon or armour from +0 to +10.
    /// Items of rarity 8 and above pay more and have their own odds.
    /// </summary>
    public class EquipmentUpgradeService : IEquipmentUpgradeService
    {
        private const short HighRarity = 8;
        private const byte FirstCompleteGemUpgrade = 5;

        internal static readonly double[] SuccessRate = { 100, 100, 90, 80, 60, 40, 20, 5, 1.5, 0.6 };
        internal static readonly double[] FixedRate = { 0, 0, 10, 15, 20, 20, 20, 12, 2, 1 };
        internal static readonly long[] GoldCost = { 500, 1500, 3000, 10000, 30000, 80000, 150000, 400000, 700000, 1000000 };
        internal static readonly short[] CellaCost = { 20, 50, 80, 120, 160, 220, 280, 380, 480, 600 };
        internal static readonly short[] GemCost = { 1, 1, 2, 2, 3, 1, 1, 2, 2, 3 };

        internal static readonly double[] HighRaritySuccessRate = { 50, 60, 30, 35, 20, 10, 5, 3, 2, 1 };
        internal static readonly double[] HighRarityFixedRate = { 0, 0, 10, 15, 20, 20, 20, 20, 15, 10 };
        internal static readonly long[] HighRarityGoldCost = { 5000, 15000, 30000, 100000, 300000, 800000, 1500000, 4000000, 7000000, 10000000 };
        internal static readonly short[] HighRarityCellaCost = { 40, 100, 160, 240, 320, 440, 560, 760, 960, 1200 };
        internal static readonly short[] HighRarityGemCost = { 2, 2, 4, 4, 6, 2, 2, 4, 4, 6 };

        /// <inheritdoc />
        public byte MaxUpgrade => Constants.MaxEquipmentUpgrade;

        /// <inheritdoc />
        public double GetSuccessRate(byte upgrade, short rarity) =>
            (rarity >= HighRarity ? HighRaritySuccessRate : SuccessRate)[upgrade];

        /// <inheritdoc />
        public double GetFixedRate(byte upgrade, short rarity) =>
            (rarity >= HighRarity ? HighRarityFixedRate : FixedRate)[upgrade];

        /// <inheritdoc />
        public double GetFailureRate(byte upgrade, short rarity) =>
            100 - GetSuccessRate(upgrade, rarity) - GetFixedRate(upgrade, rarity);

        /// <inheritdoc />
        public long GetGoldCost(byte upgrade, short rarity) =>
            (rarity >= HighRarity ? HighRarityGoldCost : GoldCost)[upgrade];

        /// <inheritdoc />
        public short GetCellaCost(byte upgrade, short rarity) =>
            (rarity >= HighRarity ? HighRarityCellaCost : CellaCost)[upgrade];

        /// <inheritdoc />
        public short GetGemCost(byte upgrade, short rarity) =>
            (rarity >= HighRarity ? HighRarityGemCost : GemCost)[upgrade];

        /// <inheritdoc />
        public bool UsesCompleteGem(byte upgrade) => upgrade >= FirstCompleteGemUpgrade;
    }
}
