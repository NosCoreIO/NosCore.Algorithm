//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.LowLevelBoostService
{
    /// <summary>
    /// Provides the experience multiplier young characters receive
    /// </summary>
    /// <remarks>
    /// Experience is tripled up to level 5 and doubled up to level 18. Job experience is
    /// tripled up to level 12 and doubled up to level 20. Both follow the character's level and
    /// multiply the level gap penalty.
    /// </remarks>
    public class LowLevelBoostService : ILowLevelBoostService
    {
        /// <inheritdoc />
        public byte GetExperienceBoost(byte level) => level switch
        {
            <= 5 => 3,
            <= 18 => 2,
            _ => 1,
        };

        /// <inheritdoc />
        public byte GetJobExperienceBoost(byte level) => level switch
        {
            <= 12 => 3,
            <= 20 => 2,
            _ => 1,
        };
    }
}
