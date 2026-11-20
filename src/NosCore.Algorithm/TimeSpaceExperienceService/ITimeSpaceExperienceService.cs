//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.TimeSpaceExperienceService
{
    /// <summary>
    /// Service for the experience awarded for clearing a time-space
    /// </summary>
    public interface ITimeSpaceExperienceService
    {
        /// <summary>
        /// Gets the experience awarded for clearing a time-space, before any rate or bonus
        /// </summary>
        /// <param name="levelMinimum">The time-space's minimum level</param>
        /// <param name="monstersKilled">The number of monsters killed during the run</param>
        /// <returns>The experience shown in the score window</returns>
        int GetExperience(byte levelMinimum, int monstersKilled);

        /// <summary>
        /// Gets the job experience awarded for clearing a time-space, before any rate or bonus
        /// </summary>
        /// <param name="monstersKilled">The number of monsters killed during the run</param>
        /// <returns>The job experience shown in the score window</returns>
        int GetJobExperience(int monstersKilled);
    }
}
