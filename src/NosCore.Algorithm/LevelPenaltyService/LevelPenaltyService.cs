//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.LevelPenaltyService
{
    /// <summary>
    /// Provides the reward multipliers for killing a monster below the player's level
    /// </summary>
    public class LevelPenaltyService : ILevelPenaltyService
    {
        /// <inheritdoc />
        public double GetExperiencePenalty(byte playerLevel, byte monsterLevel)
        {
            return (playerLevel - monsterLevel) switch
            {
                <= 5 => 1,
                6 => 0.9,
                7 => 0.7,
                8 => 0.5,
                9 => 0.3,
                _ => 0.1
            };
        }

        /// <inheritdoc />
        public double GetGoldPenalty(byte playerLevel, byte monsterLevel)
        {
            return (playerLevel - monsterLevel) switch
            {
                <= 4 => 1,
                5 => 0.9,
                6 => 0.7,
                7 => 0.5,
                8 => 0.3,
                9 => 0.2,
                <= 18 => 0.1,
                <= 29 => 0.05,
                _ => 0
            };
        }
    }
}
