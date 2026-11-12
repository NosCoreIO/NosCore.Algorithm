//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Algorithm.MateHpService;
using NosCore.Algorithm.MateMpService;

namespace NosCore.Algorithm.MonsterStatService
{
    /// <summary>
    /// Calculates a monster's base statistics from its race, its level and the levels of its weapon and armour
    /// </summary>
    /// <remarks>
    /// Every curve is a race-specific share of the monster level, plus a fixed amount per equipment level,
    /// plus the equipment's own upgrade bonus. HP and MP are the pet curves without a growth factor, and HP
    /// is further multiplied in level tiers.
    /// </remarks>
    public class MonsterStatService(IMateHpService mateHpService, IMateMpService mateMpService) : IMonsterStatService
    {
        private const int ArmorDefencePerLevel = 2;
        private const int ArmorDodgePerLevel = 4;
        private const int WeaponMinimumDamagePerLevel = 3;
        private const int WeaponMaximumDamagePerLevel = 5;
        private const int WeaponHitRatePerLevel = 4;
        private const int MagicHitRate = 70;
        private const int CriticalChance = 4;
        private const int CriticalRate = 70;

        private static readonly (byte Level, int Tenths)[] HpTiers =
        [
            (82, 35),
            (72, 25),
            (62, 18),
            (52, 15),
            (37, 12),
        ];

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

        /// <inheritdoc />
        public long GetMaxHp(byte race, byte level)
        {
            var tenths = 10;
            foreach (var (tierLevel, tierTenths) in HpTiers)
            {
                if (level >= tierLevel)
                {
                    tenths = tierTenths;
                    break;
                }
            }

            return mateHpService.GetHp(race, level, 0) * tenths / 10;
        }

        /// <inheritdoc />
        public long GetMaxMp(byte race, byte level) => mateMpService.GetMp(race, level, 0);

        /// <inheritdoc />
        public int GetCloseDefence(byte race, byte level, byte armorLevel) =>
            For(race).Close.At(level) + (ArmorDefencePerLevel * armorLevel) + FloorDivide((2 * armorLevel) + 10, 25);

        /// <inheritdoc />
        public int GetDistanceDefence(byte race, byte level, byte armorLevel) =>
            For(race).Distance.At(level) + (ArmorDefencePerLevel * armorLevel) + FloorDivide((9 * armorLevel) + 20, 25);

        /// <inheritdoc />
        public int GetMagicDefence(byte race, byte level, byte armorLevel) =>
            For(race).Magic.At(level) + (ArmorDefencePerLevel * armorLevel) + FloorDivide(armorLevel + 5, 25);

        /// <inheritdoc />
        public int GetDodge(byte race, byte level, byte armorLevel) =>
            For(race).Dodge.At(level) + (ArmorDodgePerLevel * armorLevel);

        /// <inheritdoc />
        public int GetMinimumDamage(byte race, byte level, byte weaponLevel, MonsterAttackClass attackClass)
        {
            var curves = For(race);
            var curve = attackClass switch
            {
                MonsterAttackClass.Ranged => curves.RangedMinimum,
                MonsterAttackClass.Magic => curves.MagicMinimum,
                _ => curves.MeleeMinimum,
            };
            return curve.At(level) + (WeaponMinimumDamagePerLevel * weaponLevel) + WeaponUpgradeBonus(weaponLevel);
        }

        /// <inheritdoc />
        public int GetMaximumDamage(byte race, byte level, byte weaponLevel, MonsterAttackClass attackClass)
        {
            var curves = For(race);
            var curve = attackClass switch
            {
                MonsterAttackClass.Ranged => curves.RangedMaximum,
                MonsterAttackClass.Magic => curves.MagicMaximum,
                _ => curves.MeleeMaximum,
            };
            return curve.At(level) + (WeaponMaximumDamagePerLevel * weaponLevel) - WeaponUpgradeBonus(weaponLevel);
        }

        /// <inheritdoc />
        public int GetHitRate(byte race, byte level, byte weaponLevel, MonsterAttackClass attackClass)
        {
            var curves = For(race);
            return attackClass switch
            {
                MonsterAttackClass.Magic => MagicHitRate,
                MonsterAttackClass.Ranged => (2 * curves.MeleeHitRate.LevelShare(level)) + (WeaponHitRatePerLevel * weaponLevel) + curves.RangedHitRateConstant,
                _ => curves.MeleeHitRate.At(level) + (WeaponHitRatePerLevel * weaponLevel),
            };
        }

        /// <inheritdoc />
        public int GetCriticalChance() => CriticalChance;

        /// <inheritdoc />
        public int GetCriticalRate() => CriticalRate;

        private static RaceCurves For(byte race) => race < Races.Length ? Races[race] ?? Default : Default;

        private static int WeaponUpgradeBonus(byte weaponLevel) => FloorDivide(weaponLevel - 1, 5);

        private static int FloorDivide(int value, int divisor) =>
            value >= 0 ? value / divisor : -((-value + divisor - 1) / divisor);

        /// <summary>
        /// The race's share of the monster level, floor((numerator * level + offset) / denominator), plus a constant
        /// </summary>
        private readonly record struct Curve(int Numerator, int Denominator, int Offset, int Constant)
        {
            public int LevelShare(byte level) => FloorDivide((Numerator * level) + Offset, Denominator);

            public int At(byte level) => LevelShare(level) + Constant;
        }

        private sealed record RaceCurves(
            Curve Close, Curve Distance, Curve Magic, Curve Dodge,
            Curve MeleeMinimum, Curve MeleeMaximum, Curve MeleeHitRate,
            Curve RangedMinimum, Curve RangedMaximum, int RangedHitRateConstant,
            Curve MagicMinimum, Curve MagicMaximum);
    }
}
