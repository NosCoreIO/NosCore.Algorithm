//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.MateMpService
{
    /// <summary>
    /// Service for calculating the maximum MP of a pet or partner
    /// </summary>
    public interface IMateMpService
    {
        /// <summary>
        /// Gets the maximum MP of a pet or partner, before the flat MP its monster entry adds
        /// </summary>
        /// <param name="race">The race of the mate's monster entry</param>
        /// <param name="level">The mate level</param>
        /// <param name="mpFactor">The MP growth factor of the mate's monster entry</param>
        /// <returns>The MP value</returns>
        long GetMp(byte race, byte level, short mpFactor);
    }
}
