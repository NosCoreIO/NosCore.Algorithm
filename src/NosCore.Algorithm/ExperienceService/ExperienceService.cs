using System;

namespace NosCore.Algorithm.ExperienceService
{
    public class ExperienceService : IExperienceService
    {
        private readonly double[]_xpData = new double[Constants.MaxLevel];

        public ExperienceService()
        {
            var v = new double[99];
            double var = 1;
            v[0] = 540;
            v[1] = 960;
            _xpData[1] = 300;
            for (var i = 1; i < v.Length; i++)
            {
                v[i] = v[i - 1] + 420 + 120 * (i - 1);
            }

            for (var i = 2; i < _xpData.Length; i++)
            {
                if (i < 79)
                {
                    if (i == 14)
                    {
                        var = 6 / 3d;
                    }
                    else if (i == 39)
                    {
                        var = 19 / 3d;
                    }
                    else if (i == 59)
                    {
                        var = 70 / 3d;
                    }

                    _xpData[i] = Convert.ToInt64(_xpData[i - 1] + var * v[i - 1]);
                }
                else
                {
                    if (i == 79)
                    {
                        var = 5000;
                    }
                    else if (i == 82)
                    {
                        var = 9000;
                    }
                    else if (i == 84)
                    {
                        var = 13000;
                    }

                    _xpData[i] = Convert.ToInt64(_xpData[i - 1] + var * (i + 2) * (i + 2));
                }
            }
        }
        public long GetExperience(byte level)
        {
            return (long)_xpData![level - 1];
        }
    }
}
