//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------
namespace NosCore.Algorithm.MonsterGoldService
{
    /// <summary>
    /// Provides the gold a monster is worth
    /// </summary>
    public class MonsterGoldService : IMonsterGoldService
    {
        /// <summary>
        /// Gets the range of gold a monster drops when killed
        /// </summary>
        /// <param name="monsterLevel">The monster's level</param>
        /// <returns>The minimum and maximum gold, both inclusive</returns>
        public (int Min, int Max) GetGoldDrop(byte monsterLevel)
        {
            return (6 * monsterLevel, 12 * monsterLevel);
        }
    }
}
