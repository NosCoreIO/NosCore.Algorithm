//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------
namespace NosCore.Algorithm.MonsterGoldService
{
    /// <summary>
    /// Service for the gold a monster is worth
    /// </summary>
    public interface IMonsterGoldService
    {
        /// <summary>
        /// Gets the range of gold a monster drops when killed
        /// </summary>
        /// <param name="monsterLevel">The monster's level</param>
        /// <returns>The minimum and maximum gold, both inclusive</returns>
        (int Min, int Max) GetGoldDrop(byte monsterLevel);
    }
}
