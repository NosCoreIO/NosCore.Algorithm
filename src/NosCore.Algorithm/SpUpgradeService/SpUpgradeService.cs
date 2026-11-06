//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.SpUpgradeService
{
    /// <summary>
    /// Provides what upgrading a specialist card costs and how likely each attempt is to succeed
    /// </summary>
    public class SpUpgradeService : ISpUpgradeService
    {
        internal static readonly byte[] SuccessRate = { 80, 75, 70, 60, 50, 40, 35, 30, 25, 20, 10, 7, 5, 3, 1 };
        internal static readonly byte[] DestructionRate = { 0, 0, 5, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 70 };
        internal static readonly long[] GoldCost = { 200000, 200000, 200000, 200000, 200000, 500000, 500000, 500000, 500000, 500000, 1000000, 1000000, 1000000, 1000000, 1000000 };
        internal static readonly short[] FeatherCost = { 3, 5, 8, 10, 15, 20, 25, 30, 35, 40, 45, 50, 55, 60, 70 };
        internal static readonly short[] FullMoonCost = { 1, 3, 5, 7, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30 };
        internal static readonly short[] SoulCost = { 2, 4, 6, 8, 10, 1, 2, 3, 4, 5, 1, 2, 3, 4, 5 };

        /// <inheritdoc />
        public byte MaxUpgrade => Constants.MaxSpUpgrade;

        /// <inheritdoc />
        public byte GetSuccessRate(byte upgrade) => SuccessRate[upgrade];

        /// <inheritdoc />
        public byte GetDestructionRate(byte upgrade) => DestructionRate[upgrade];

        /// <inheritdoc />
        public long GetGoldCost(byte upgrade) => GoldCost[upgrade];

        /// <inheritdoc />
        public short GetFeatherCost(byte upgrade) => FeatherCost[upgrade];

        /// <inheritdoc />
        public short GetFullMoonCost(byte upgrade) => FullMoonCost[upgrade];

        /// <inheritdoc />
        public short GetSoulCost(byte upgrade) => SoulCost[upgrade];

        /// <inheritdoc />
        public byte GetMinimumJobLevel(byte upgrade) => upgrade switch
        {
            < 5 => 21,
            < 10 => 41,
            _ => 51,
        };
    }
}
