//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.HeroExperienceService
{
    /// <summary>
    /// Service for calculating hero experience requirements
    /// </summary>
    public interface IHeroExperienceService
    {
        /// <summary>
        /// Gets the total experience required for a hero to reach a specific level
        /// </summary>
        /// <param name="level">The hero level</param>
        /// <returns>The total experience required</returns>
        long GetHeroExperience(byte level);
    }
}