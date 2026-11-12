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
        public int GetCloseDefence(byte race, byte level, byte armorLevel) => MonsterCurves.CloseDefence(race, level, armorLevel);

        /// <inheritdoc />
        public int GetDistanceDefence(byte race, byte level, byte armorLevel) => MonsterCurves.DistanceDefence(race, level, armorLevel);

        /// <inheritdoc />
        public int GetMagicDefence(byte race, byte level, byte armorLevel) => MonsterCurves.MagicDefence(race, level, armorLevel);

        /// <inheritdoc />
        public int GetDodge(byte race, byte level, byte armorLevel) => MonsterCurves.Dodge(race, level, armorLevel);

        /// <inheritdoc />
        public int GetMinimumDamage(byte race, byte level, byte weaponLevel, MonsterAttackClass attackClass) =>
            MonsterCurves.MinimumDamage(race, level, weaponLevel, attackClass);

        /// <inheritdoc />
        public int GetMaximumDamage(byte race, byte level, byte weaponLevel, MonsterAttackClass attackClass) =>
            MonsterCurves.MaximumDamage(race, level, weaponLevel, attackClass);

        /// <inheritdoc />
        public int GetHitRate(byte race, byte level, byte weaponLevel, MonsterAttackClass attackClass) =>
            MonsterCurves.HitRate(race, level, weaponLevel, attackClass);

        /// <inheritdoc />
        public int GetCriticalChance() => CriticalChance;

        /// <inheritdoc />
        public int GetCriticalRate() => CriticalRate;
    }
}
