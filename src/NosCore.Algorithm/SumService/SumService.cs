//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.SumService
{
    /// <summary>
    /// Provides summoning-related values including success rates, prices, and sand costs
    /// </summary>
    public class SumService : ISumService
    {
        internal static readonly byte[] SuccessRate = { 100, 100, 85, 70, 50, 20 };
        internal static readonly ushort[] Price = { 1500, 3000, 6000, 12000, 24000, 48000 };
        internal static readonly byte[] SandCost = { 5, 10, 15, 20, 25, 30 };

        /// <summary>
        /// Gets the success rate for a summoning operation at a specific level
        /// </summary>
        /// <param name="level">The summoning level</param>
        /// <returns>The success rate as a percentage</returns>
        public byte GetSuccessRate(byte level)
        {
            return SuccessRate[level];
        }

        /// <summary>
        /// Gets the price for a summoning operation at a specific level
        /// </summary>
        /// <param name="level">The summoning level</param>
        /// <returns>The price</returns>
        public ushort GetPrice(byte level)
        {
            return Price[level];
        }

        /// <summary>
        /// Gets the sand cost for a summoning operation at a specific level
        /// </summary>
        /// <param name="level">The summoning level</param>
        /// <returns>The sand cost</returns>
        public ushort GetSandCost(byte level)
        {
            return SandCost[level];
        }
    }
}
