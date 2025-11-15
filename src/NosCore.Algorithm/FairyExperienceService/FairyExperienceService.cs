//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.FairyExperienceService
{
    /// <summary>
    /// Provides fairy experience requirement calculations for different levels
    /// </summary>
    public class FairyExperienceService : IFairyExperienceService
    {
        private readonly int[] _fairyXpData = new int[Constants.MaxFairyLevel];

        /// <summary>
        /// Initializes a new instance of the FairyExperienceService and pre-calculates experience requirements for all fairy levels
        /// </summary>
        public FairyExperienceService()
        {
            for (var i = 0; i < _fairyXpData.Length; i++)
            {
                _fairyXpData[i] = i < 40 ? i * i + 50 : (i * i + 50) * 3;
            }

        }

        /// <summary>
        /// Gets the experience required for a fairy to reach a specific level
        /// </summary>
        /// <param name="level">The fairy level</param>
        /// <returns>The experience required</returns>
        public int GetFairyExperience(byte level)
        {
            return _fairyXpData![level];
        }
    }
}
