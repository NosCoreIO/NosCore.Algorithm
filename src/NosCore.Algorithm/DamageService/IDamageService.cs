//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.DamageService
{
    public interface IDamageService
    {
        long GetMinDamage(CharacterClassType entityClass, byte level);

        long GetMaxDamage(CharacterClassType entityClass, byte level);
    }
}