//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.TimeSpaceScoreService
{
    /// <summary>
    /// Service for the points a kill adds to a time-space's running score
    /// </summary>
    public interface ITimeSpaceScoreService
    {
        /// <summary>
        /// Gets the points a kill adds to the running score
        /// </summary>
        /// <param name="monsterLevel">The level of the monster killed</param>
        /// <param name="killerLevel">The level of whoever killed it</param>
        /// <param name="chain">How many marked monsters in a row this kill completes, 0 for a monster that was not marked</param>
        /// <returns>The points added</returns>
        int GetKillPoints(byte monsterLevel, byte killerLevel, int chain);
    }
}
