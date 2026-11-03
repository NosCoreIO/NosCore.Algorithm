//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.LevelPenaltyService
{
    /// <summary>
    /// Service for reducing the rewards of monsters far below the player's level
    /// </summary>
    public interface ILevelPenaltyService
    {
        /// <summary>
        /// Gets the multiplier applied to the experience of a monster
        /// </summary>
        /// <param name="playerLevel">The level the experience is for (level, job level or hero level)</param>
        /// <param name="monsterLevel">The monster's level</param>
        /// <returns>A multiplier between 0 and 1</returns>
        double GetExperiencePenalty(byte playerLevel, byte monsterLevel);

        /// <summary>
        /// Gets the multiplier applied to the chance of a monster dropping gold
        /// </summary>
        /// <param name="playerLevel">The player's level</param>
        /// <param name="monsterLevel">The monster's level</param>
        /// <returns>A multiplier between 0 and 1</returns>
        double GetGoldPenalty(byte playerLevel, byte monsterLevel);
    }
}
