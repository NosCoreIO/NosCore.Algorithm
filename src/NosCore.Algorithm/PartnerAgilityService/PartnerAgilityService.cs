//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.PartnerAgilityService
{
    /// <summary>
    /// Provides the agility a partner's specialist card gains when its owner defeats a monster
    /// </summary>
    public class PartnerAgilityService : IPartnerAgilityService
    {
        // Whether the live game still uses these steps is not confirmed.
        private const byte FullGainLevelGap = 15;
        private const byte HalfGainLevelGap = 30;

        /// <inheritdoc />
        public byte MaxAgility => Constants.MaxPartnerAgility;

        /// <inheritdoc />
        public byte GetAgilityGain(byte playerLevel, byte monsterLevel) =>
            playerLevel < monsterLevel + FullGainLevelGap ? (byte)2
            : playerLevel < monsterLevel + HalfGainLevelGap ? (byte)1
            : (byte)0;
    }
}
