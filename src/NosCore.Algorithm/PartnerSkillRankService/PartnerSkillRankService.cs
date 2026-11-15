//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.PartnerSkillRankService
{
    /// <summary>
    /// Provides how likely each rank is when a partner learns a skill of its specialist card
    /// </summary>
    public class PartnerSkillRankService : IPartnerSkillRankService
    {
        // F, E, D, C, B, A, S. They add up to 92 rather than 100, so they are read as weights; whether the
        // live rates still match them is not confirmed.
        internal static readonly int[] Weight = { 10, 15, 30, 20, 10, 5, 2 };

        /// <inheritdoc />
        public byte MinRank => 1;

        /// <inheritdoc />
        public byte MaxRank => Constants.MaxPartnerSkillRank;

        /// <inheritdoc />
        public int GetWeight(byte rank) => rank is >= 1 and <= Constants.MaxPartnerSkillRank ? Weight[rank - 1] : 0;
    }
}
