//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.TimeSpaceExperienceService
{
    /// <summary>
    /// Provides the experience awarded for clearing a time-space
    /// </summary>
    /// <remarks>
    /// Each monster killed is worth three times the time-space's minimum level in experience and
    /// 5.25 job experience, rounded down over the whole run. Neither depends on the character's
    /// level: the level penalty only reduces the points.
    /// </remarks>
    public class TimeSpaceExperienceService : ITimeSpaceExperienceService
    {
        /// <inheritdoc />
        public int GetExperience(byte levelMinimum, int monstersKilled)
        {
            return Constants.TimeSpaceExperiencePerLevel * levelMinimum * monstersKilled;
        }

        /// <inheritdoc />
        public int GetJobExperience(int monstersKilled)
        {
            return monstersKilled * Constants.TimeSpaceJobExperienceNumerator / Constants.TimeSpaceJobExperienceDenominator;
        }
    }
}
