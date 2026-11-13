//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.IceBreakerRewardService
{
    /// <summary>
    /// Provides the level brackets of the Icebreaker and what its winners earn
    /// </summary>
    public class IceBreakerRewardService : IIceBreakerRewardService
    {
        private static readonly (byte Minimum, byte Maximum, long Gold)[] Brackets =
        [
            (1, 25, 100),
            (20, 40, 1000),
            (35, 55, 3000),
            (50, 70, 5000),
            (65, 85, 10000),
            (80, Constants.MaxLevel, 20000),
        ];

        /// <inheritdoc />
        public int BracketCount => Brackets.Length;

        /// <inheritdoc />
        public byte GetLevelMinimum(int bracket)
        {
            return Brackets[bracket].Minimum;
        }

        /// <inheritdoc />
        public byte GetLevelMaximum(int bracket)
        {
            return Brackets[bracket].Maximum;
        }

        /// <inheritdoc />
        public long GetGold(int bracket)
        {
            return Brackets[bracket].Gold;
        }

        /// <inheritdoc />
        public long GetReputation(byte level)
        {
            return level * 10L;
        }
    }
}
