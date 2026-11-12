//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.SkillPointService
{
    /// <summary>
    /// Service for the skill points (CP) a character spends on class skills
    /// </summary>
    public interface ISkillPointService
    {
        /// <summary>
        /// Gets the CP a character has before any skill is learned
        /// </summary>
        /// <param name="class">The character's class</param>
        /// <param name="jobLevel">The character's job level</param>
        /// <returns>The CP pool</returns>
        int GetSkillPoints(CharacterClassType @class, byte jobLevel);
    }
}
