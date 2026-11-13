//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.IceBreakerRewardService
{
    /// <summary>
    /// Service for the level brackets of the Icebreaker and what its winners earn
    /// </summary>
    public interface IIceBreakerRewardService
    {
        /// <summary>
        /// Gets the number of level brackets the Icebreaker cycles through
        /// </summary>
        int BracketCount { get; }

        /// <summary>
        /// Gets the lowest level allowed in a bracket
        /// </summary>
        /// <param name="bracket">The bracket, from 0</param>
        /// <returns>The lowest level</returns>
        byte GetLevelMinimum(int bracket);

        /// <summary>
        /// Gets the highest level allowed in a bracket
        /// </summary>
        /// <param name="bracket">The bracket, from 0</param>
        /// <returns>The highest level</returns>
        byte GetLevelMaximum(int bracket);

        /// <summary>
        /// Gets the gold earned by a winner of a bracket
        /// </summary>
        /// <param name="bracket">The bracket, from 0</param>
        /// <returns>The gold</returns>
        long GetGold(int bracket);

        /// <summary>
        /// Gets the reputation earned by a winner
        /// </summary>
        /// <param name="level">The winner's level</param>
        /// <returns>The reputation</returns>
        long GetReputation(byte level);
    }
}
