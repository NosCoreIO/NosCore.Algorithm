//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.DamageService
{
    public interface IDamageService
    {
        long GetMinDamage(byte entityClass, byte level);

        long GetMaxDamage(byte entityClass, byte level);
    }
}