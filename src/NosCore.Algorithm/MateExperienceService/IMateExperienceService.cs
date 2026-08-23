//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.MateExperienceService
{
    /// <summary>
    /// Service for calculating pet and partner experience requirements
    /// </summary>
    public interface IMateExperienceService
    {
        /// <summary>
        /// Gets the experience a pet needs to leave a specific level
        /// </summary>
        /// <param name="level">The pet level</param>
        /// <returns>The experience required</returns>
        long GetPetExperience(byte level);

        /// <summary>
        /// Gets the experience a partner needs to leave a specific level
        /// </summary>
        /// <param name="level">The partner level</param>
        /// <returns>The experience required</returns>
        long GetPartnerExperience(byte level);
    }
}
