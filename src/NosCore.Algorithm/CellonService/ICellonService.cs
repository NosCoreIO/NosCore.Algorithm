//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System.Collections.Generic;

namespace NosCore.Algorithm.CellonService
{
    /// <summary>
    /// Service for retrieving the options a cellon can add to an accessory and what applying it costs
    /// </summary>
    public interface ICellonService
    {
        /// <summary>
        /// Gets the options a cellon of a specific level can roll
        /// </summary>
        /// <param name="level">The cellon level</param>
        /// <returns>The options, or an empty list for a level no cellon has</returns>
        IReadOnlyList<CellonOption> GetOptions(byte level);

        /// <summary>
        /// Gets the gold cost of applying a cellon of a specific level
        /// </summary>
        /// <param name="level">The cellon level</param>
        /// <returns>The gold cost</returns>
        long GetPrice(byte level);
    }
}
