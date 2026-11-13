//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.InstantCombatRewardService
{
    /// <summary>
    /// Provides what a player earns by clearing an Instant Combat, scaled by the player's level
    /// </summary>
    public class InstantCombatRewardService : IInstantCombatRewardService
    {
        /// <summary>
        /// Gets the reputation earned by a winner
        /// </summary>
        /// <param name="level">The winner's level</param>
        /// <returns>The reputation</returns>
        public long GetReputation(byte level)
        {
            return level * 50L;
        }

        /// <summary>
        /// Gets the gold earned by a winner
        /// </summary>
        /// <param name="level">The winner's level</param>
        /// <returns>The gold</returns>
        public long GetGold(byte level)
        {
            return level * 1000L;
        }

        /// <summary>
        /// Gets the additional SP points earned by a winner
        /// </summary>
        /// <param name="level">The winner's level</param>
        /// <returns>The additional SP points</returns>
        public int GetSpAdditionPoints(byte level)
        {
            return level * 100;
        }
    }
}
