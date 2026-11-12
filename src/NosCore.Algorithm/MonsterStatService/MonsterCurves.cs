//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.MonsterStatService
{
    /// <summary>
    /// The race curves shared by monsters and pets. A pet adds its growth factor, in tenths per level above the
    /// first, to the level share of each curve: half of it for the defences, all of it for dodge, damage and hit rate.
    /// </summary>
    internal static class MonsterCurves
    {
        private const int ArmorDefencePerLevel = 2;
        private const int ArmorDodgePerLevel = 4;
        private const int WeaponMinimumDamagePerLevel = 3;
        private const int WeaponMaximumDamagePerLevel = 5;
        private const int WeaponHitRatePerLevel = 4;
        private const int MagicHitRate = 70;
        private const int DefenceGrowthDivisor = 20;
        private const int AttackGrowthDivisor = 10;

        private static readonly RaceCurves Default = new(
            new(1, 2, 1, 15), new(1, 2, 0, 14), new(1, 2, 1, 10), new(1, 1, 0, 26),
            new(1, 1, 0, 28), new(1, 1, 0, 34), new(1, 1, 0, 22),
            new(1, 1, 0, 23), new(1, 1, 0, 29), 28,
            new(1, 1, 0, 18), new(1, 1, 0, 24));

        // Race 4 has two level 30 entries whose published stats fit none of these curves, so the low end
        // of that race is unconfirmed.
        private static readonly RaceCurves?[] Races =
        [
            Default,
            new(new(1, 1, 0, 19), new(1, 1, 0, 17), new(1, 1, 0, 18), new(2, 1, 0, 33),
                new(2, 1, 0, 35), new(2, 1, 0, 41), new(2, 1, 0, 29),
                new(2, 1, 0, 30), new(2, 1, 0, 36), 42,
                new(2, 1, 0, 33), new(2, 1, 0, 39)),
            new(new(3, 4, 1, 14), new(1, 2, 1, 15), new(2, 5, 3, 14), new(1, 1, 0, 29),
                new(3, 2, 1, 25), new(3, 2, 1, 31), new(1, 1, 0, 25),
                new(1, 1, 0, 26), new(1, 1, 0, 32), 34,
                new(4, 5, 1, 26), new(4, 5, 1, 32)),
            new(new(1, 2, 1, 14), new(1, 2, 1, 15), new(1, 2, 1, 14), new(1, 1, 0, 29),
                new(1, 1, 0, 26), new(1, 1, 0, 32), new(1, 1, 0, 25),
                new(1, 1, 0, 26), new(1, 1, 0, 32), 34,
                new(1, 1, 0, 26), new(1, 1, 0, 32)),
            new(new(3, 5, 4, 16), new(3, 5, 4, 17), new(1, 1, 0, 16), new(6, 5, 4, 33),
                new(6, 5, 4, 30), new(6, 5, 4, 36), new(6, 5, 4, 29),
                new(6, 5, 4, 30), new(6, 5, 4, 36), 42,
                new(2, 1, 0, 30), new(2, 1, 0, 36)),
            new(new(2, 5, 0, 13), new(2, 5, 0, 14), new(2, 5, 0, 13), new(4, 5, 1, 26),
                new(4, 5, 1, 23), new(4, 5, 1, 29), new(4, 5, 1, 22),
                new(4, 5, 1, 23), new(4, 5, 1, 29), 28,
                new(4, 5, 1, 23), new(4, 5, 1, 29)),
            new(new(1, 2, 0, 11), new(1, 2, 1, 15), new(3, 4, 1, 24), new(1, 1, 0, 29),
                new(1, 1, 0, 19), new(1, 1, 0, 25), new(1, 1, 0, 25),
                new(1, 1, 0, 26), new(1, 1, 0, 32), 34,
                new(3, 2, 1, 45), new(3, 2, 1, 51)),
            null,
            new(new(0, 1, 0, 10), new(0, 1, 0, 11), new(0, 1, 0, 10), new(0, 1, 0, 20),
                new(0, 1, 0, 17), new(0, 1, 0, 23), new(0, 1, 0, 16),
                new(0, 1, 0, 17), new(0, 1, 0, 23), 16,
                new(0, 1, 0, 17), new(0, 1, 0, 23)),
        ];

        public static int CloseDefence(byte race, byte level, byte armorLevel, int meleeGrowth = 0) =>
            For(race).Close.At(level, meleeGrowth, DefenceGrowthDivisor) + (ArmorDefencePerLevel * armorLevel) + FloorDivide((2 * armorLevel) + 10, 25);

        public static int DistanceDefence(byte race, byte level, byte armorLevel, int rangedGrowth = 0) =>
            For(race).Distance.At(level, rangedGrowth, DefenceGrowthDivisor) + (ArmorDefencePerLevel * armorLevel) + FloorDivide((9 * armorLevel) + 20, 25);

        public static int MagicDefence(byte race, byte level, byte armorLevel, int magicGrowth = 0) =>
            For(race).Magic.At(level, magicGrowth, DefenceGrowthDivisor) + (ArmorDefencePerLevel * armorLevel) + FloorDivide(armorLevel + 5, 25);

        public static int Dodge(byte race, byte level, byte armorLevel, int rangedGrowth = 0) =>
            For(race).Dodge.At(level, rangedGrowth, AttackGrowthDivisor) + (ArmorDodgePerLevel * armorLevel);

        public static int MinimumDamage(byte race, byte level, byte weaponLevel, MonsterAttackClass attackClass, int growth = 0)
        {
            var curves = For(race);
            var curve = attackClass switch
            {
                MonsterAttackClass.Ranged => curves.RangedMinimum,
                MonsterAttackClass.Magic => curves.MagicMinimum,
                _ => curves.MeleeMinimum,
            };
            return curve.At(level, growth, AttackGrowthDivisor) + (WeaponMinimumDamagePerLevel * weaponLevel) + WeaponUpgradeBonus(weaponLevel);
        }

        public static int MaximumDamage(byte race, byte level, byte weaponLevel, MonsterAttackClass attackClass, int growth = 0)
        {
            var curves = For(race);
            var curve = attackClass switch
            {
                MonsterAttackClass.Ranged => curves.RangedMaximum,
                MonsterAttackClass.Magic => curves.MagicMaximum,
                _ => curves.MeleeMaximum,
            };
            return curve.At(level, growth, AttackGrowthDivisor) + (WeaponMaximumDamagePerLevel * weaponLevel) - WeaponUpgradeBonus(weaponLevel);
        }

        public static int HitRate(byte race, byte level, byte weaponLevel, MonsterAttackClass attackClass, int rangedGrowth = 0)
        {
            var curves = For(race);
            return attackClass switch
            {
                MonsterAttackClass.Magic => MagicHitRate,
                MonsterAttackClass.Ranged => (2 * curves.MeleeHitRate.LevelShare(level, rangedGrowth, AttackGrowthDivisor)) + (WeaponHitRatePerLevel * weaponLevel) + curves.RangedHitRateConstant,
                _ => curves.MeleeHitRate.At(level, rangedGrowth, AttackGrowthDivisor) + (WeaponHitRatePerLevel * weaponLevel),
            };
        }

        private static RaceCurves For(byte race) => race < Races.Length ? Races[race] ?? Default : Default;

        private static int WeaponUpgradeBonus(byte weaponLevel) => FloorDivide(weaponLevel - 1, 5);

        private static int FloorDivide(int value, int divisor) =>
            value >= 0 ? value / divisor : -((-value + divisor - 1) / divisor);

        /// <summary>
        /// The race's share of the level, floor((numerator * level + offset) / denominator), plus a constant. A
        /// growth factor adds growth / growthDivisor per level above the first inside the same floor.
        /// </summary>
        private readonly record struct Curve(int Numerator, int Denominator, int Offset, int Constant)
        {
            public int LevelShare(byte level, int growth, int growthDivisor) =>
                FloorDivide((((Numerator * level) + Offset) * growthDivisor) + (Denominator * growth * (level - 1)), Denominator * growthDivisor);

            public int At(byte level, int growth, int growthDivisor) => LevelShare(level, growth, growthDivisor) + Constant;
        }

        private sealed record RaceCurves(
            Curve Close, Curve Distance, Curve Magic, Curve Dodge,
            Curve MeleeMinimum, Curve MeleeMaximum, Curve MeleeHitRate,
            Curve RangedMinimum, Curve RangedMaximum, int RangedHitRateConstant,
            Curve MagicMinimum, Curve MagicMaximum);
    }
}
