//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.RarityPointService
{
    /// <summary>
    /// Provides the rarity points of equipment
    /// </summary>
    /// <remarks>
    /// Each rarity has a base value that is multiplied by one plus a fifth of the item level.
    /// </remarks>
    public class RarityPointService : IRarityPointService
    {
        /// <inheritdoc />
        public int GetRarityPoint(sbyte rarity, byte itemLevel)
        {
            var points = rarity switch
            {
                >= 0 and <= 5 => rarity,
                6 => 7,
                7 => 10,
                8 => 15,
                _ => rarity * 2
            };
            return points * (itemLevel / 5 + 1);
        }
    }
}
