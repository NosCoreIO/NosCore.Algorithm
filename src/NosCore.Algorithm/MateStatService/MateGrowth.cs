//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.MateStatService
{
    /// <summary>
    /// The growth factors of a pet's monster entry, in tenths of a stat point per level
    /// </summary>
    /// <param name="Melee">Grows close defence and melee damage</param>
    /// <param name="Ranged">Grows ranged defence, dodge, hit rate and ranged damage</param>
    /// <param name="Magic">Grows magic defence and magic damage</param>
    public readonly record struct MateGrowth(short Melee, short Ranged, short Magic);
}
