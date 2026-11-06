//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.ShellService
{
    /// <summary>
    /// One option a shell rolls when it is identified
    /// </summary>
    /// <param name="Level">The option level, 1 to 12: every four levels are one group (normal, special, PvP) ranked C, B, A, S</param>
    /// <param name="Guaranteed">Whether the option always rolls; otherwise it rolls half of the time</param>
    public sealed record ShellSlot(byte Level, bool Guaranteed);
}
