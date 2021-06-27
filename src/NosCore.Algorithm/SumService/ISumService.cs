//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.SumService
{
    public interface ISumService
    {
        byte GetSuccessRate(byte level);
        ushort GetPrice(byte level);
        ushort GetSandCost(byte level);
    }
}
