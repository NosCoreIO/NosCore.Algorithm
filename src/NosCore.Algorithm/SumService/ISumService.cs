//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.UpgradeService
{
    public interface ISumService
    {
        byte GetSuccessRate(byte sourceUpgrade, byte targetUpgrade);
        ushort GetSumPrice(byte sourceUpgrade, byte targetUpgrade);
        ushort GetSandCost(byte sourceUpgrade, byte targetUpgrade);
    }
}
