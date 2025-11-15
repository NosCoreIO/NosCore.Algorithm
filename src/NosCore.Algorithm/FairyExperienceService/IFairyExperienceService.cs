//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.FairyExperienceService
{
    /// <summary>
    /// Service for calculating fairy experience requirements
    /// </summary>
    public interface IFairyExperienceService
    {
        /// <summary>
        /// Gets the experience required for a fairy to reach a specific level
        /// </summary>
        /// <param name="level">The fairy level</param>
        /// <returns>The experience required</returns>
        int GetFairyExperience(byte level);
    }
}