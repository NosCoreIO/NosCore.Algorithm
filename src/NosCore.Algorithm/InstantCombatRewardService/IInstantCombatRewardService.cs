//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.InstantCombatRewardService
{
    /// <summary>
    /// Service for what a player earns by clearing an Instant Combat
    /// </summary>
    public interface IInstantCombatRewardService
    {
        /// <summary>
        /// Gets the reputation earned by a winner
        /// </summary>
        /// <param name="level">The winner's level</param>
        /// <returns>The reputation</returns>
        long GetReputation(byte level);

        /// <summary>
        /// Gets the gold earned by a winner
        /// </summary>
        /// <param name="level">The winner's level</param>
        /// <returns>The gold</returns>
        long GetGold(byte level);

        /// <summary>
        /// Gets the additional SP points earned by a winner
        /// </summary>
        /// <param name="level">The winner's level</param>
        /// <returns>The additional SP points</returns>
        int GetSpAdditionPoints(byte level);
    }
}
