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

        private static readonly (int UpTo, int PerLevel)[] AttackDamageBands =
            [(10, 5), (20, 6), (30, 7), (40, 8), (50, 9), (60, 10), (70, 11), (80, 13), (90, 14), (94, 15), (95, 16), (97, 17), (100, 20)];

        private static readonly (int UpTo, int PerLevel)[] DefenceCurveBands =
            [(10, 1), (20, 2), (30, 3), (40, 4), (50, 5), (60, 6), (70, 7), (80, 8), (90, 9), (100, 10)];

        private static readonly (int UpTo, int PerLevel)[] DoublingAfterFifty = [(50, 1), (100, 2)];

        private static readonly (int Level, SpecialistPointBonus Bonus)[] AttackMilestones =
        [
            (1, new(Damage: 5)),
            (10, new(HitRate: 10)),
            (20, new(CriticalChance: 2)),
            (30, new(Damage: 5, HitRate: 10)),
            (40, new(CriticalRate: 10)),
            (50, new(Hp: 200, Mp: 200)),
            (60, new(HitRate: 15)),
            (70, new(Damage: 5, HitRate: 15)),
            (80, new(CriticalChance: 3)),
            (90, new(CriticalRate: 20)),
            (100, new(Damage: 5, HitRate: 20, CriticalChance: 3, CriticalRate: 20, Hp: 200, Mp: 200)),
        ];

        private static readonly (int Level, SpecialistPointBonus Bonus)[] DefenceMilestones =
        [
            (10, new(Dodge: 5)),
            (20, new(CriticalDodge: 2)),
            (30, new(Hp: 100)),
            (40, new(CriticalDodge: 2)),
            (50, new(Dodge: 5)),
            (60, new(Hp: 200)),
            (70, new(CriticalDodge: 3)),
            (75, new(Resistance: 2)),
            (80, new(Dodge: 10, CriticalDodge: 3)),
            (90, new(Resistance: 3)),
            (95, new(Hp: 300)),
            (100, new(Dodge: 20, Resistance: 5)),
        ];

        private static readonly (int Level, SpecialistPointBonus Bonus)[] ElementMilestones =
        [
            (1, new(ElementRate: 2)),
            (10, new(Mp: 100)),
            (20, new(MagicDefence: 5)),
            (30, new(Resistance: 2, ElementRate: 2)),
            (40, new(Mp: 100)),
            (50, new(MagicDefence: 5)),
            (60, new(Resistance: 3, ElementRate: 2)),
            (70, new(Mp: 100)),
            (80, new(MagicDefence: 5)),
            (90, new(Resistance: 4, ElementRate: 2)),
            (100, new(Resistance: 6, MagicDefence: 5, Mp: 200, ElementRate: 2)),
        ];

        private static readonly (int Level, SpecialistPointBonus Bonus)[] HpMpMilestones =
        [
            (5, new(Damage: 5)),
            (10, new(Damage: 5)),
            (15, new(Damage: 5)),
            (20, new(Damage: 5, Defence: 10)),
            (25, new(Damage: 5)),
            (30, new(Damage: 5)),
            (35, new(Damage: 5)),
            (40, new(Damage: 5, Defence: 15)),
            (45, new(Damage: 10)),
            (50, new(Damage: 10, Resistance: 2)),
            (55, new(Damage: 10)),
            (60, new(Damage: 10)),
            (65, new(Damage: 10)),
            (70, new(Damage: 10, Defence: 20)),
            (75, new(Damage: 15)),
            (80, new(Damage: 15)),
            (85, new(Damage: 15, CriticalDodge: 1)),
            (86, new(CriticalDodge: 1)),
            (87, new(CriticalDodge: 1)),
            (88, new(CriticalDodge: 1)),
            (90, new(Damage: 15, Defence: 25)),
            (91, new(Dodge: 2)),
            (92, new(Dodge: 2)),
            (93, new(Dodge: 2)),
            (94, new(Dodge: 2)),
            (95, new(Damage: 20, Dodge: 2)),
            (96, new(Dodge: 2)),
            (97, new(Dodge: 2)),
            (98, new(Dodge: 2)),
            (99, new(Dodge: 2)),
            (100, new(Damage: 20, Defence: 30, Dodge: 2, CriticalDodge: 1, Resistance: 3)),
        ];

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

        // Attack and defence add ten per level on top of their curve, which puts attack 100 at
        // over 2 000 damage. No in-game value confirms the sum yet, so both terms are suspect.
        /// <inheritdoc />
        public SpecialistPointBonus GetAttackBonus(int level)
        {
            level = Clamp(level);
            return Milestones(AttackMilestones, level) + new SpecialistPointBonus(Damage: level * 10 + Curve(AttackDamageBands, level));
        }

        /// <inheritdoc />
        public SpecialistPointBonus GetDefenceBonus(int level)
        {
            level = Clamp(level);
            return Milestones(DefenceMilestones, level) + new SpecialistPointBonus(Defence: level * 10 + Curve(DefenceCurveBands, level));
        }

        /// <inheritdoc />
        public SpecialistPointBonus GetElementBonus(int level)
        {
            level = Clamp(level);
            return Milestones(ElementMilestones, level) + new SpecialistPointBonus(ElementRate: Curve(DoublingAfterFifty, level));
        }

        /// <inheritdoc />
        public SpecialistPointBonus GetHpMpBonus(int level)
        {
            level = Clamp(level);
            return Milestones(HpMpMilestones, level) + new SpecialistPointBonus(HpMpPercent: Curve(DoublingAfterFifty, level));
        }

        private static int Clamp(int level) => Math.Clamp(level, 0, 100);

        private static SpecialistPointBonus Milestones((int Level, SpecialistPointBonus Bonus)[] milestones, int level)
        {
            var bonus = new SpecialistPointBonus();
            foreach (var milestone in milestones)
            {
                if (milestone.Level > level)
                {
                    break;
                }

                bonus += milestone.Bonus;
            }

            return bonus;
        }

        private static int Curve((int UpTo, int PerLevel)[] bands, int level)
        {
            var total = 0;
            var from = 0;
            foreach (var (upTo, perLevel) in bands)
            {
                if (level <= from)
                {
                    break;
                }

                total += (Math.Min(level, upTo) - from) * perLevel;
                from = upTo;
            }

            return total;
        }

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
