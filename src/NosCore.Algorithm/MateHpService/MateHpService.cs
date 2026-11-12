//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;

namespace NosCore.Algorithm.MateHpService
{
    /// <summary>
    /// Calculates the maximum HP of a pet or partner from its race, level and HP growth factor
    /// </summary>
    public class MateHpService : IMateHpService
    {
        private const byte FixedRace = 8;
        private const long FixedHp = 7;

        /// <summary>
        /// Per race: the growth added to the factor, the linear term offset and the constant term
        /// </summary>
        private static readonly (int Growth, int Linear, int Constant)[] RaceConstants =
        {
            (0, 2, 138),
            (10, 10, 610),
            (5, 0, 105),
            (0, 0, 205),
            (2, 5, 695),
            (-2, -3, 263),
            (0, -7, 21),
        };

        /// <inheritdoc />
        public long GetHp(byte race, byte level, short hpFactor)
        {
            if (race == FixedRace)
            {
                return FixedHp;
            }

            var (growth, linear, constant) = race < RaceConstants.Length ? RaceConstants[race] : (0, 0, 0);
            var x = MateLevel.Effective(level, hpFactor + growth, 0);
            return (long)Math.Floor((0.5 * x * x) + ((15.5 + linear) * x) + constant);
        }
    }
}
