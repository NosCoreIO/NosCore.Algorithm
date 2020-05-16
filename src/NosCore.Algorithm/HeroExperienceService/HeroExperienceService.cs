//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;
using NosCore.Algorithm.ExperienceService;

namespace NosCore.Algorithm.HeroExperienceService
{
    public class HeroExperienceService : IHeroExperienceService
    {
        private readonly double[] _heroXpData = new double[Constants.MaxHeroLevel];

        public HeroExperienceService()
        {
            var index = 1;
            var increment = 118980;
            var increment2 = 9120;
            var increment3 = 360;

            _heroXpData[0] = 949560;
            for (var lvl = 1; lvl < Constants.MaxHeroLevel; lvl++)
            {
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
        public long GetHeroExperience(byte level)
        {
            return (long)_heroXpData![level - 1];
        }
    }
}
