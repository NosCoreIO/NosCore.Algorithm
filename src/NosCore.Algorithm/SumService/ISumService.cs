//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.SumService
{
    /// <summary>
    /// Service for retrieving summoning-related values including success rates, prices, and sand costs
    /// </summary>
    public interface ISumService
    {
        /// <summary>
        /// Gets the success rate for a summoning operation at a specific level
        /// </summary>
        /// <param name="level">The summoning level</param>
        /// <returns>The success rate as a percentage</returns>
        byte GetSuccessRate(byte level);

        /// <summary>
        /// Gets the price for a summoning operation at a specific level
        /// </summary>
        /// <param name="level">The summoning level</param>
        /// <returns>The price</returns>
        ushort GetPrice(byte level);

        /// <summary>
        /// Gets the sand cost for a summoning operation at a specific level
        /// </summary>
        /// <param name="level">The summoning level</param>
        /// <returns>The sand cost</returns>
        ushort GetSandCost(byte level);
    }
}
