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
    /// From level 20 the curve is the previous requirement plus a tenth, compounded on the
    /// unrounded value and floored, which is why the last rows are not round numbers.
    /// </remarks>
    public class FamilyExperienceService : IFamilyExperienceService
    {
        private static readonly uint[] FamilyXpData =
        [
            80_000, 96_000, 120_000, 152_000, 224_000,
            336_000, 512_000, 760_000, 1_136_000, 1_472_000,
            1_800_000, 2_240_000, 2_968_000, 3_848_000, 5_000_000,
            6_816_000, 9_672_000, 14_192_000, 20_000_000, 22_000_000,
            24_200_000, 26_620_000, 29_282_000, 32_210_200, 35_431_220,
            38_974_342, 42_871_776, 47_158_953, 51_874_849, 57_062_334
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
