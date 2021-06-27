//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.UpgradeService
{
    public class SumService : ISumService
    {
        internal static readonly byte[] SumSuccess = { 100, 100, 85, 70, 50, 20 };
        internal static readonly ushort[] SumPrice = { 1500, 3000, 6000, 12000, 24000, 48000 };
        internal static readonly byte[] SumSand = { 5, 10, 15, 20, 25, 30 };

        public byte GetSuccessRate(byte sourceUpgrade, byte targetUpgrade)
        {
            return SumSuccess[sourceUpgrade + targetUpgrade];
        }

        public ushort GetSumPrice(byte sourceUpgrade, byte targetUpgrade)
        {
            return SumPrice[sourceUpgrade + targetUpgrade];
        }

        public ushort GetSandCost(byte sourceUpgrade, byte targetUpgrade)
        {
            return SumSand[sourceUpgrade + targetUpgrade];
        }
    }
}
