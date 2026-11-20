//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.TimeSpacePenaltyService
{
    /// <summary>
    /// Service for reducing the points of a time-space finished by a character above its level range
    /// </summary>
    public interface ITimeSpacePenaltyService
    {
        /// <summary>
        /// Gets the share of the points lost for finishing a time-space above its minimum level
        /// </summary>
        /// <param name="level">The character's level when the time-space is finished</param>
        /// <param name="levelMinimum">The time-space's minimum level</param>
        /// <returns>The percentage of the points lost, from 0 to 100</returns>
        byte GetPointPenalty(byte level, byte levelMinimum);
    }
}
