//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Algorithm.MonsterStatService;

namespace NosCore.Algorithm.MateStatService
{
    /// <summary>
    /// Service for calculating a pet's attack, defence and dodge at its own level, before the flat modifiers of its
    /// monster entry
    /// </summary>
    public interface IMateStatService
    {
        /// <summary>
        /// Gets the close combat defence of a pet
        /// </summary>
        /// <param name="race">The race of the pet's monster entry</param>
        /// <param name="level">The pet level</param>
        /// <param name="growth">The growth factors of the pet's monster entry</param>
        /// <returns>The defence value</returns>
        int GetCloseDefence(byte race, byte level, MateGrowth growth);

        /// <summary>
        /// Gets the ranged defence of a pet
        /// </summary>
        /// <param name="race">The race of the pet's monster entry</param>
        /// <param name="level">The pet level</param>
        /// <param name="growth">The growth factors of the pet's monster entry</param>
        /// <returns>The defence value</returns>
        int GetDistanceDefence(byte race, byte level, MateGrowth growth);

        /// <summary>
        /// Gets the magic defence of a pet
        /// </summary>
        /// <param name="race">The race of the pet's monster entry</param>
        /// <param name="level">The pet level</param>
        /// <param name="growth">The growth factors of the pet's monster entry</param>
        /// <returns>The defence value</returns>
        int GetMagicDefence(byte race, byte level, MateGrowth growth);

        /// <summary>
        /// Gets the dodge of a pet, against close and ranged attacks alike
        /// </summary>
        /// <param name="race">The race of the pet's monster entry</param>
        /// <param name="level">The pet level</param>
        /// <param name="growth">The growth factors of the pet's monster entry</param>
        /// <returns>The dodge value</returns>
        int GetDodge(byte race, byte level, MateGrowth growth);

        /// <summary>
        /// Gets the minimum damage of a pet
        /// </summary>
        /// <param name="race">The race of the pet's monster entry</param>
        /// <param name="level">The pet level</param>
        /// <param name="attackClass">Whether the pet attacks in melee, at range or with magic</param>
        /// <param name="growth">The growth factors of the pet's monster entry</param>
        /// <returns>The damage value</returns>
        int GetMinimumDamage(byte race, byte level, MonsterAttackClass attackClass, MateGrowth growth);

        /// <summary>
        /// Gets the maximum damage of a pet
        /// </summary>
        /// <param name="race">The race of the pet's monster entry</param>
        /// <param name="level">The pet level</param>
        /// <param name="attackClass">Whether the pet attacks in melee, at range or with magic</param>
        /// <param name="growth">The growth factors of the pet's monster entry</param>
        /// <returns>The damage value</returns>
        int GetMaximumDamage(byte race, byte level, MonsterAttackClass attackClass, MateGrowth growth);

        /// <summary>
        /// Gets the hit rate of a pet
        /// </summary>
        /// <param name="race">The race of the pet's monster entry</param>
        /// <param name="level">The pet level</param>
        /// <param name="attackClass">Whether the pet attacks in melee, at range or with magic</param>
        /// <param name="growth">The growth factors of the pet's monster entry</param>
        /// <returns>The hit rate value</returns>
        int GetHitRate(byte race, byte level, MonsterAttackClass attackClass, MateGrowth growth);
    }
}
