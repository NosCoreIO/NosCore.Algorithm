//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.MateHpService
{
    /// <summary>
    /// Service for calculating the maximum HP of a pet or partner
    /// </summary>
    public interface IMateHpService
    {
        /// <summary>
        /// Gets the maximum HP of a pet or partner, before the flat HP its monster entry adds
        /// </summary>
        /// <param name="race">The race of the mate's monster entry</param>
        /// <param name="level">The mate level</param>
        /// <param name="hpFactor">The HP growth factor of the mate's monster entry</param>
        /// <returns>The HP value</returns>
        long GetHp(byte race, byte level, short hpFactor);
    }
}
