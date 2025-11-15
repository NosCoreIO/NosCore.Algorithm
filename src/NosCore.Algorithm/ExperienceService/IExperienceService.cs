//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.ExperienceService
{
    /// <summary>
    /// Service for calculating character experience requirements
    /// </summary>
    public interface IExperienceService
    {
        /// <summary>
        /// Gets the total experience required to reach a specific level
        /// </summary>
        /// <param name="level">The target level</param>
        /// <returns>The total experience required</returns>
        long GetExperience(byte level);
    }
}