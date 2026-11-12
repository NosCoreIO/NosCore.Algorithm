//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;
using NosCore.Algorithm.MateHpService;

namespace NosCore.Algorithm.MateMpService
{
    /// <summary>
    /// Calculates the maximum MP of a pet or partner from its race, level and MP growth factor
    /// </summary>
    public class MateMpService : IMateMpService
    {
        private const byte FixedRace = 8;
        private const long FixedMp = 4;

        /// <summary>
        /// Per race: the constant term, the growth added to the factor, the linear term offset
        /// and the extra level the factor gives
        /// </summary>
        private static readonly (double Constant, int Growth, int Linear, int Bonus)[] RaceConstants =
        {
            (4.75, 0, 0, 0),
            (178.75, 10, 8, 0),
            (50.75, -2, 4, 0),
            (50.75, 0, 4, 0),
            (385.75, 10, 6, 1),
            (23.75, -2, 2, 1),
            (705.75, 5, 14, 0),
        };

        /// <inheritdoc />
        public long GetMp(byte race, byte level, short mpFactor)
        {
            if (race == FixedRace)
            {
                return FixedMp;
            }

            var (constant, growth, linear, bonus) = race < RaceConstants.Length ? RaceConstants[race] : (0, 0, 0, 0);
            var x = MateLevel.Effective(level, mpFactor + growth, bonus);
            var steps = Math.Floor((x - 6) / 4.0);
            var mp = Math.Floor(((5.25 + linear) * x) + constant) + ((steps + 1) * 2 * (PositiveModulo(x - 2, 4) + 1 + (steps * 2)));
            return (long)Math.Floor(mp);
        }

        private static int PositiveModulo(int value, int modulo) => ((value % modulo) + modulo) % modulo;
    }
}
