//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;

namespace NosCore.Algorithm.ExperienceService
{
    public class ExperienceService : IExperienceService
    {
        private readonly double[] _xpData = new double[Constants.MaxLevel];

        public ExperienceService()
        {
            var v = new double[99];
            double var = 1;
            v[0] = 540;
            v[1] = 960;
            _xpData[0] = 300;

            for (var i = 1; i < _xpData.Length; i++)
            {
                v[i] = i == 1 ? v[i] : v[i - 1] + 420 + 120 * (i - 1);
                var = i switch
                {
                    14 => 6 / 3d,
                    39 => 19 / 3d,
                    59 => 70 / 3d,
                    79 => 5000,
                    82 => 9000,
                    84 => 13000,
                    96 => 15000,
                    _ => var
                };

                _xpData[i] = i < 79
                    ? Convert.ToInt64(_xpData[i - 1] + var * v[i - 1])
                    : Convert.ToInt64(_xpData[i - 1] + var * (i + 2) * (i + 2));
            }
        }
        public long GetExperience(byte level)
        {
            return (long)_xpData![level - 1];
        }
    }
}
