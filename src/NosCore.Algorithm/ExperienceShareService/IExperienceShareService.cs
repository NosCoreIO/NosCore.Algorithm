//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.ExperienceShareService
{
    /// <summary>
    /// Service for splitting monster experience between the members of a group
    /// </summary>
    public interface IExperienceShareService
    {
        /// <summary>
        /// Gets the share of a monster's experience each member receives
        /// </summary>
        /// <param name="memberCount">The number of group members sharing the kill</param>
        /// <returns>The fraction of the monster's experience given to each member</returns>
        double GetExperienceShare(byte memberCount);

        /// <summary>
        /// Gets the share of a monster's job experience each member receives
        /// </summary>
        /// <param name="memberCount">The number of group members sharing the kill</param>
        /// <returns>The fraction of the monster's job experience given to each member</returns>
        double GetJobExperienceShare(byte memberCount);
    }
}
