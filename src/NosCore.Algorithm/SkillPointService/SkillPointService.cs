//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.SkillPointService
{
    /// <summary>
    /// Provides the CP pool: two per job level, plus forty once the character has a class
    /// </summary>
    public class SkillPointService : ISkillPointService
    {
        private const int ClassBonus = 40;
        private const int PerJobLevel = 2;

        // Login traces of job level 80 characters show 200 CP once their active skills are
        // paid for, which fits this curve at its cap. No trace below the cap has been checked.
        /// <inheritdoc />
        public int GetSkillPoints(CharacterClassType @class, byte jobLevel)
        {
            return (@class == CharacterClassType.Adventurer ? 0 : ClassBonus) + PerJobLevel * jobLevel;
        }
    }
}
