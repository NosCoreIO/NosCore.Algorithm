//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.SpPerfectionService
{
    /// <summary>
    /// Service for retrieving what perfecting a specialist card costs, how likely each attempt is to succeed and how many points a success adds
    /// </summary>
    public interface ISpPerfectionService
    {
        /// <summary>
        /// Gets the highest perfection a specialist card can reach
        /// </summary>
        byte MaxPerfection { get; }

        /// <summary>
        /// Gets the chance that an attempt from a specific perfection succeeds
        /// </summary>
        /// <param name="perfection">The card's current perfection</param>
        /// <returns>The success rate as a percentage</returns>
        byte GetSuccessRate(byte perfection);

        /// <summary>
        /// Gets the gold cost of an attempt from a specific perfection
        /// </summary>
        /// <param name="perfection">The card's current perfection</param>
        /// <returns>The gold cost</returns>
        long GetGoldCost(byte perfection);

        /// <summary>
        /// Gets the number of perfection stones an attempt from a specific perfection consumes
        /// </summary>
        /// <param name="perfection">The card's current perfection</param>
        /// <returns>The stone cost</returns>
        short GetStoneCost(byte perfection);

        /// <summary>
        /// Gets the fewest points a successful attempt from a specific perfection adds to the rolled stat
        /// </summary>
        /// <param name="perfection">The card's current perfection</param>
        /// <returns>The minimum gain</returns>
        byte GetMinimumGain(byte perfection);

        /// <summary>
        /// Gets the most points a successful attempt from a specific perfection adds to the rolled stat
        /// </summary>
        /// <param name="perfection">The card's current perfection</param>
        /// <returns>The maximum gain</returns>
        byte GetMaximumGain(byte perfection);
    }
}
