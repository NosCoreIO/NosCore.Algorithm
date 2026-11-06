//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.LowLevelBoostService
{
    /// <summary>
    /// Service for the experience multiplier young characters receive
    /// </summary>
    public interface ILowLevelBoostService
    {
        /// <summary>
        /// Gets the experience multiplier for a character's level
        /// </summary>
        /// <param name="level">The character's level</param>
        /// <returns>The multiplier applied to experience from monsters</returns>
        byte GetExperienceBoost(byte level);

        /// <summary>
        /// Gets the job experience multiplier for a character's level
        /// </summary>
        /// <param name="level">The character's level, not its job level</param>
        /// <returns>The multiplier applied to job experience from monsters</returns>
        byte GetJobExperienceBoost(byte level);
    }
}
