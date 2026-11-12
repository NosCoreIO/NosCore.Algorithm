//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Algorithm.MonsterStatService;

namespace NosCore.Algorithm.MateStatService
{
    /// <summary>
    /// Calculates a pet's attack, defence and dodge at its own level
    /// </summary>
    /// <remarks>
    /// A pet follows the monster curves of its race with its weapon and armour at the pet's level, and grows each
    /// curve's level share by its growth factor: tenths per level above the first for dodge, damage and hit rate,
    /// twentieths for the defences.
    /// </remarks>
    public class MateStatService : IMateStatService
    {
        /// <inheritdoc />
        public int GetCloseDefence(byte race, byte level, MateGrowth growth) =>
            MonsterCurves.CloseDefence(race, level, level, growth.Melee);

        /// <inheritdoc />
        public int GetDistanceDefence(byte race, byte level, MateGrowth growth) =>
            MonsterCurves.DistanceDefence(race, level, level, growth.Ranged);

        /// <inheritdoc />
        public int GetMagicDefence(byte race, byte level, MateGrowth growth) =>
            MonsterCurves.MagicDefence(race, level, level, growth.Magic);

        /// <inheritdoc />
        public int GetDodge(byte race, byte level, MateGrowth growth) =>
            MonsterCurves.Dodge(race, level, level, growth.Ranged);

        /// <inheritdoc />
        public int GetMinimumDamage(byte race, byte level, MonsterAttackClass attackClass, MateGrowth growth) =>
            MonsterCurves.MinimumDamage(race, level, level, attackClass, AttackGrowth(attackClass, growth));

        /// <inheritdoc />
        public int GetMaximumDamage(byte race, byte level, MonsterAttackClass attackClass, MateGrowth growth) =>
            MonsterCurves.MaximumDamage(race, level, level, attackClass, AttackGrowth(attackClass, growth));

        /// <inheritdoc />
        public int GetHitRate(byte race, byte level, MonsterAttackClass attackClass, MateGrowth growth) =>
            MonsterCurves.HitRate(race, level, level, attackClass, growth.Ranged);

        private static int AttackGrowth(MonsterAttackClass attackClass, MateGrowth growth) => attackClass switch
        {
            MonsterAttackClass.Ranged => growth.Ranged,
            MonsterAttackClass.Magic => growth.Magic,
            _ => growth.Melee,
        };
    }
}
