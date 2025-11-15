//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.SpExperienceService
{
    /// <summary>
    /// Service for calculating specialist card (SP) experience requirements
    /// </summary>
    public interface ISpExperienceService
    {
        /// <summary>
        /// Gets the experience required for a specialist card to reach a specific level
        /// </summary>
        /// <param name="level">The specialist card level</param>
        /// <param name="isSecondarySp">Whether this is a secondary specialist card</param>
        /// <returns>The experience required</returns>
        long GetSpExperience(byte level, bool isSecondarySp);
    }
}