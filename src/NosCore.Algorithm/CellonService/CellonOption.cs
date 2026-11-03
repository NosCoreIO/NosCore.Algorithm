//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.CellonService
{
    /// <summary>
    /// An option a cellon can roll, with the inclusive range its value is drawn from
    /// </summary>
    /// <param name="Type">The option type</param>
    /// <param name="Minimum">The lowest value the option can roll</param>
    /// <param name="Maximum">The highest value the option can roll</param>
    public sealed record CellonOption(CellonType Type, int Minimum, int Maximum);
}
