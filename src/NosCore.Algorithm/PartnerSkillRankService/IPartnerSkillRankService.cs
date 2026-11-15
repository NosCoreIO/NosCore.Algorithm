//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.PartnerSkillRankService
{
    /// <summary>
    /// Service for retrieving how likely each rank is when a partner learns a skill of its specialist card
    /// </summary>
    public interface IPartnerSkillRankService
    {
        /// <summary>
        /// The lowest rank a learned skill can get, F
        /// </summary>
        byte MinRank { get; }

        /// <summary>
        /// The highest rank a learned skill can get, S
        /// </summary>
        byte MaxRank { get; }

        /// <summary>
        /// Gets the weight of a rank against the other ranks' weights
        /// </summary>
        /// <param name="rank">The rank, from 1 (F) to 7 (S)</param>
        /// <returns>The weight, or 0 for a rank outside that range</returns>
        int GetWeight(byte rank);
    }
}
