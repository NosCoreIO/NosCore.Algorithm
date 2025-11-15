//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;

namespace NosCore.Algorithm.ExperienceService
{
    /// <summary>
    /// Provides character experience requirement calculations for different levels
    /// </summary>
    public class ExperienceService : IExperienceService
    {
        private readonly long[] _xpData = new long[Constants.MaxLevel];

        /// <summary>
        /// Initializes a new instance of the ExperienceService and pre-calculates experience requirements for all levels
        /// </summary>
        public ExperienceService()
        {
            var v = new long[99];
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

        /// <summary>
        /// Gets the total experience required to reach a specific level
        /// </summary>
        /// <param name="level">The target level</param>
        /// <returns>The total experience required</returns>
        public long GetExperience(byte level)
        {
            return _xpData![level - 1];
        }
    }
}
