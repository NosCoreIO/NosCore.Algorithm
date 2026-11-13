//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.MonsterLevelDamageService
{
    /// <summary>
    /// Service for the flat damage a high level monster adds to every hit it lands
    /// </summary>
    public interface IMonsterLevelDamageService
    {
        /// <summary>
        /// Gets the damage added to a monster's hit after the defence is taken off
        /// </summary>
        /// <param name="monsterLevel">The attacking monster's level</param>
        /// <returns>The damage to add, 0 below level 45</returns>
        int GetExtraDamage(byte monsterLevel);
    }
}
