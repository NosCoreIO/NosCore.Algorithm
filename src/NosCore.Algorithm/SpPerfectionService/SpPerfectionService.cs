//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.SpPerfectionService
{
    /// <summary>
    /// Provides what perfecting a specialist card costs, how likely each attempt is to succeed and how many points a success adds.
    /// The values change every 20 points of perfection.
    /// </summary>
    public class SpPerfectionService : ISpPerfectionService
    {
        private const byte TierSize = 20;

        internal static readonly byte[] SuccessRate = { 50, 40, 30, 20, 10 };
        internal static readonly long[] GoldCost = { 5000, 10000, 20000, 50000, 100000 };
        internal static readonly short[] StoneCost = { 1, 2, 3, 4, 5 };
        internal static readonly byte[] MinimumGain = { 1, 1, 1, 2, 3 };
        internal static readonly byte[] MaximumGain = { 1, 1, 1, 2, 5 };

        /// <inheritdoc />
        public byte MaxPerfection => Constants.MaxSpPerfection;

        /// <inheritdoc />
        public byte GetSuccessRate(byte perfection) => SuccessRate[Tier(perfection)];

        /// <inheritdoc />
        public long GetGoldCost(byte perfection) => GoldCost[Tier(perfection)];

        /// <inheritdoc />
        public short GetStoneCost(byte perfection) => StoneCost[Tier(perfection)];

        /// <inheritdoc />
        public byte GetMinimumGain(byte perfection) => MinimumGain[Tier(perfection)];

        /// <inheritdoc />
        public byte GetMaximumGain(byte perfection) => MaximumGain[Tier(perfection)];

        private static int Tier(byte perfection) => perfection / TierSize;
    }
}
