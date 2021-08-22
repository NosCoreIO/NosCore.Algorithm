//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;

namespace NosCore.Algorithm.HeroExperienceService
{
    public class HeroExperienceService : IHeroExperienceService
    {
        private readonly long[] _heroXpData = new long[Constants.MaxHeroLevel];

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
        public long GetHeroExperience(byte level)
        {
            return _heroXpData![level - 1];
        }
    }
}
