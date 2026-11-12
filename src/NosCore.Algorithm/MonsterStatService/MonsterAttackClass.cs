//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.MonsterStatService
{
    /// <summary>
    /// How a monster attacks, which decides its damage and hit rate curves
    /// </summary>
    public enum MonsterAttackClass : byte
    {
        /// <summary>Close combat</summary>
        Melee = 0,

        /// <summary>Ranged physical attacks</summary>
        Ranged = 1,

        /// <summary>Magic attacks, which have a flat hit rate</summary>
        Magic = 2
    }
}
