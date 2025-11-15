//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;

namespace NosCore.Algorithm.HeroExperienceService
{
    /// <summary>
    /// Provides hero experience requirement calculations for different levels
    /// </summary>
    public class HeroExperienceService : IHeroExperienceService
    {
        private readonly long[] _heroXpData = new long[Constants.MaxHeroLevel];

        /// <summary>
        /// Initializes a new instance of the HeroExperienceService and pre-calculates experience requirements for all hero levels
        /// </summary>
        public HeroExperienceService()
        {
            var index = 1;
            var increment = 118980;
            var increment2 = 9120;
            var increment3 = 360;

            _heroXpData[0] = 949560;
            _heroXpData[54] = 33224190;
            for (var lvl = 1; lvl < Constants.MaxHeroLevel; lvl++)
            {
                if (lvl == 54)
                {
                    continue;
                }

                if (lvl > 54)
                {
                    _heroXpData[lvl] = (long)Math.Floor(_heroXpData[lvl - 1] * 1.15);
                    continue;
                }

                _heroXpData[lvl] = _heroXpData[lvl - 1] + increment;
                increment2 += increment3;
                increment += increment2;
                index++;
                if (index % 10 == 0)
                {
                    increment3 -= index / 10 < 3 ? index / 10 * 30 : 30;
                }
            }
        }

        /// <summary>
        /// Gets the total experience required for a hero to reach a specific level
        /// </summary>
        /// <param name="level">The hero level</param>
        /// <returns>The total experience required</returns>
        public long GetHeroExperience(byte level)
        {
            return _heroXpData![level - 1];
        }
    }
}
