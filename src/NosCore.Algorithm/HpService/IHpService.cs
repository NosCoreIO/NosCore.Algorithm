//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.HpService
{
    public interface IHpService
    {
        long GetHp(CharacterClassType entityClass, byte level);
    }
}