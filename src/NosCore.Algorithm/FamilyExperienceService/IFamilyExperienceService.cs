//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.FamilyExperienceService
{
    /// <summary>
    /// Service for calculating family experience requirements
    /// </summary>
    public interface IFamilyExperienceService
    {
        /// <summary>
        /// Gets the experience a family needs to leave a specific level
        /// </summary>
        /// <param name="level">The family level</param>
        /// <returns>The experience required</returns>
        uint GetFamilyExperience(byte level);
    }
}
