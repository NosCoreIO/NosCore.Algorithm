//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;

namespace NosCore.Algorithm.TimeSpaceScoreService
{
    /// <summary>
    /// Provides the points a kill adds to a time-space's running score
    /// </summary>
    public class TimeSpaceScoreService : ITimeSpaceScoreService
    {
        /// <inheritdoc />
        public int GetKillPoints(byte monsterLevel, byte killerLevel, int chain)
        {
            var levelPoints = Math.Clamp(monsterLevel - killerLevel + Constants.TimeSpaceKillPointsAtSameLevel,
                1, Constants.MaxTimeSpaceKillLevelPoints);
            return levelPoints + Math.Max(0, chain) * Constants.TimeSpaceKillPointsPerChain;
        }
    }
}
