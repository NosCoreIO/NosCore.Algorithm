//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.ShellService
{
    /// <summary>
    /// An option a shell can roll at an option level, with the per-mille range its value is drawn from
    /// </summary>
    /// <typeparam name="TType">The weapon or armour option type</typeparam>
    /// <param name="Type">The option type</param>
    /// <param name="Minimum">The lowest per-mille of the shell level the option can roll</param>
    /// <param name="Maximum">The highest per-mille of the shell level the option can roll</param>
    public sealed record ShellOption<TType>(TType Type, int Minimum, int Maximum) where TType : struct;
}
