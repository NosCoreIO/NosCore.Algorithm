//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.MonsterLevelDamageService
{
    /// <summary>
    /// Provides the flat damage a monster of level 45 or more adds to every hit, so that a
    /// well armoured player still loses something to it
    /// </summary>
    public class MonsterLevelDamageService : IMonsterLevelDamageService
    {
        /// <inheritdoc />
        public int GetExtraDamage(byte monsterLevel)
        {
            return monsterLevel switch
            {
                < 45 => 0,
                < 55 => monsterLevel,
                < 60 => monsterLevel * 2,
                < 65 => monsterLevel * 3,
                < 70 => monsterLevel * 4,
                _ => monsterLevel * 5
            };
        }
    }
}
