//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.JobExperienceService
{
    /// <summary>
    /// Service for calculating job experience requirements for different character classes
    /// </summary>
    public interface IJobExperienceService
    {
        /// <summary>
        /// Gets the total job experience required for a character class to reach a specific job level
        /// </summary>
        /// <param name="entityClass">The character class type</param>
        /// <param name="level">The job level</param>
        /// <returns>The total job experience required</returns>
        long GetJobExperience(CharacterClassType entityClass, byte level);
    }
}