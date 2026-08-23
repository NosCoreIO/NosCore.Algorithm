//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.FamilyExperienceService
{
    /// <summary>
    /// Provides family experience requirement calculations for different levels
    /// </summary>
    /// <remarks>
    /// A ginfo line puts a level 7 family's bar at 640 000 against the 1 900 000 here, so at
    /// least that row is suspect. One observation is not enough to rebuild the curve, so the
    /// table stands until more levels can be checked.
    /// </remarks>
    public class FamilyExperienceService : IFamilyExperienceService
    {
        private static readonly uint[] FamilyXpData =
        [
            100_000, 250_000, 370_000, 560_000, 840_000,
            1_260_000, 1_900_000, 2_850_000, 3_570_000, 3_830_000,
            4_150_000, 4_750_000, 5_500_000, 6_500_000, 7_000_000,
            8_500_000, 9_500_000, 10_000_000, 17_000_000
        ];

        /// <summary>
        /// Gets the experience a family needs to leave a specific level
        /// </summary>
        /// <param name="level">The family level</param>
        /// <returns>The experience required, or uint.MaxValue past the last known level</returns>
        public uint GetFamilyExperience(byte level)
        {
            return level >= 1 && level <= FamilyXpData.Length ? FamilyXpData[level - 1] : uint.MaxValue;
        }
    }
}
