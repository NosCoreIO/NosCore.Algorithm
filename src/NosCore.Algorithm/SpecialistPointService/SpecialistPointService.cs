//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;

namespace NosCore.Algorithm.SpecialistPointService
{
    /// <summary>
    /// Provides specialist card skill points and the stat levels they buy
    /// </summary>
    /// <remarks>
    /// A card earns 3 points per level above 20, plus a bonus for its upgrade. Each stat is
    /// bought in bands: the first points buy one level each, later bands cost 2, 3, ... points
    /// per level, and the stat stops at the level reached with all the points a card can earn.
    /// </remarks>
    public class SpecialistPointService : ISpecialistPointService
    {
        private static readonly int[] UpgradeBonus = [0, 5, 10, 15, 20, 28, 36, 46, 56, 68, 80, 95, 110, 128, 148, 173];

        private static readonly (short UpTo, int Cost)[] AttackBands =
            [(10, 1), (28, 2), (88, 3), (168, 4), (268, 5), (334, 6), (383, 7), (391, 8), (400, 9), (410, 10)];

        // A 360-400 band that starts at level 97 instead of 94 is sometimes seen; it would make
        // 400 points worth more than 410, so the band is taken to continue from 94 like the others.
        private static readonly (short UpTo, int Cost)[] DefenceBands =
            [(10, 1), (48, 2), (81, 3), (161, 4), (236, 5), (290, 6), (360, 7), (400, 8), (410, 10)];

        private static readonly (short UpTo, int Cost)[] ElementBands =
            [(20, 1), (40, 2), (70, 3), (110, 4), (210, 5), (270, 6), (410, 7)];

        private static readonly (short UpTo, int Cost)[] HpMpBands =
            [(10, 1), (50, 2), (110, 3), (150, 4), (200, 5), (260, 6), (330, 7), (410, 8)];

        /// <inheritdoc />
        public int GetSpecialistPoints(byte specialistLevel, byte upgrade)
        {
            var points = specialistLevel > 20 ? (specialistLevel - 20) * 3 : 0;
            return points + (upgrade < UpgradeBonus.Length ? UpgradeBonus[upgrade] : UpgradeBonus[^1]);
        }

        /// <inheritdoc />
        public int GetAttackLevel(short points) => Level(AttackBands, points);

        /// <inheritdoc />
        public int GetDefenceLevel(short points) => Level(DefenceBands, points);

        /// <inheritdoc />
        public int GetElementLevel(short points) => Level(ElementBands, points);

        /// <inheritdoc />
        public int GetHpMpLevel(short points) => Level(HpMpBands, points);

        private static int Level((short UpTo, int Cost)[] bands, short points)
        {
            var level = 0;
            short from = 0;
            foreach (var (upTo, cost) in bands)
            {
                if (points <= upTo)
                {
                    return level + Math.Max(0, points - from) / cost;
                }

                level += (upTo - from) / cost;
                from = upTo;
            }

            return level;
        }
    }
}
