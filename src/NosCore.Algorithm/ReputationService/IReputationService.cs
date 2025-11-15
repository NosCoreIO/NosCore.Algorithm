//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.ReputationService
{
    /// <summary>
    /// Service for calculating reputation levels and thresholds
    /// </summary>
    public interface IReputationService
    {
        /// <summary>
        /// Gets the reputation level type based on a reputation value
        /// </summary>
        /// <param name="reputation">The reputation value</param>
        /// <returns>The reputation level type</returns>
        ReputationType GetLevelFromReputation(long reputation);

        /// <summary>
        /// Gets the reputation value range for a specific reputation level
        /// </summary>
        /// <param name="level">The reputation level type</param>
        /// <returns>A tuple containing the minimum and maximum reputation values for the level</returns>
        (long, long) GetReputation(ReputationType level);
    }
}