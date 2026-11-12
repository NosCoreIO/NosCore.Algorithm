//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.MonsterStatService
{
    /// <summary>
    /// Service for calculating a monster's base statistics, before the flat modifiers of its monster entry
    /// </summary>
    public interface IMonsterStatService
    {
        /// <summary>
        /// Gets the maximum HP of a monster
        /// </summary>
        /// <param name="race">The race of the monster entry</param>
        /// <param name="level">The monster level</param>
        /// <returns>The HP value</returns>
        long GetMaxHp(byte race, byte level);

        /// <summary>
        /// Gets the maximum MP of a monster
        /// </summary>
        /// <param name="race">The race of the monster entry</param>
        /// <param name="level">The monster level</param>
        /// <returns>The MP value</returns>
        long GetMaxMp(byte race, byte level);

        /// <summary>
        /// Gets the close combat defence of a monster
        /// </summary>
        /// <param name="race">The race of the monster entry</param>
        /// <param name="level">The monster level</param>
        /// <param name="armorLevel">The level of the monster's armour</param>
        /// <returns>The defence value</returns>
        int GetCloseDefence(byte race, byte level, byte armorLevel);

        /// <summary>
        /// Gets the ranged defence of a monster
        /// </summary>
        /// <param name="race">The race of the monster entry</param>
        /// <param name="level">The monster level</param>
        /// <param name="armorLevel">The level of the monster's armour</param>
        /// <returns>The defence value</returns>
        int GetDistanceDefence(byte race, byte level, byte armorLevel);

        /// <summary>
        /// Gets the magic defence of a monster
        /// </summary>
        /// <param name="race">The race of the monster entry</param>
        /// <param name="level">The monster level</param>
        /// <param name="armorLevel">The level of the monster's armour</param>
        /// <returns>The defence value</returns>
        int GetMagicDefence(byte race, byte level, byte armorLevel);

        /// <summary>
        /// Gets the dodge of a monster, against close and ranged attacks alike
        /// </summary>
        /// <param name="race">The race of the monster entry</param>
        /// <param name="level">The monster level</param>
        /// <param name="armorLevel">The level of the monster's armour</param>
        /// <returns>The dodge value</returns>
        int GetDodge(byte race, byte level, byte armorLevel);

        /// <summary>
        /// Gets the minimum damage of a monster
        /// </summary>
        /// <param name="race">The race of the monster entry</param>
        /// <param name="level">The monster level</param>
        /// <param name="weaponLevel">The level of the monster's weapon</param>
        /// <param name="attackClass">How the monster attacks</param>
        /// <returns>The damage value</returns>
        int GetMinimumDamage(byte race, byte level, byte weaponLevel, MonsterAttackClass attackClass);

        /// <summary>
        /// Gets the maximum damage of a monster
        /// </summary>
        /// <param name="race">The race of the monster entry</param>
        /// <param name="level">The monster level</param>
        /// <param name="weaponLevel">The level of the monster's weapon</param>
        /// <param name="attackClass">How the monster attacks</param>
        /// <returns>The damage value</returns>
        int GetMaximumDamage(byte race, byte level, byte weaponLevel, MonsterAttackClass attackClass);

        /// <summary>
        /// Gets the hit rate of a monster
        /// </summary>
        /// <param name="race">The race of the monster entry</param>
        /// <param name="level">The monster level</param>
        /// <param name="weaponLevel">The level of the monster's weapon</param>
        /// <param name="attackClass">How the monster attacks</param>
        /// <returns>The hit rate value</returns>
        int GetHitRate(byte race, byte level, byte weaponLevel, MonsterAttackClass attackClass);

        /// <summary>
        /// Gets the critical hit chance of a monster, in percent
        /// </summary>
        /// <returns>The critical chance</returns>
        int GetCriticalChance();

        /// <summary>
        /// Gets the extra damage of a monster's critical hit, in percent
        /// </summary>
        /// <returns>The critical damage rate</returns>
        int GetCriticalRate();
    }
}
