//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.PartnerAgilityService
{
    /// <summary>
    /// Service for the agility a partner's specialist card gains when its owner defeats a monster
    /// </summary>
    public interface IPartnerAgilityService
    {
        /// <summary>
        /// The agility a card needs before its partner can learn one of its skills
        /// </summary>
        byte MaxAgility { get; }

        /// <summary>
        /// Gets the agility gained for one defeated monster
        /// </summary>
        /// <param name="playerLevel">The owner's level</param>
        /// <param name="monsterLevel">The defeated monster's level</param>
        /// <returns>The agility points gained, 0 for a monster too far below the owner</returns>
        byte GetAgilityGain(byte playerLevel, byte monsterLevel);
    }
}
