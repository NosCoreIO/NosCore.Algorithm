//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.HitRateService
{
    /// <summary>
    /// Provides hit rate value calculations for different character classes and levels
    /// </summary>
    public class HitRateService : IHitRateService
    {
        private readonly long[,] _hitRate = new long[Constants.ClassCount, Constants.MaxLevel];

        /// <summary>
        /// Initializes a new instance of the HitRateService and pre-calculates hit rate values for all character classes and levels
        /// </summary>
        public HitRateService()
        {
            var archerHitRate = 31;
            var fighterHitRate = 8;
            var swordHitRate = 23;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                _hitRate[(byte)CharacterClassType.Adventurer, i] = i + 10;

                swordHitRate += (i - 5) % 5 == 0 ? 2 : 1;
                _hitRate[(byte)CharacterClassType.Swordsman, i] = swordHitRate;

                archerHitRate += i != 96 && i % 2 == 0 || i > 0 && i % 5 == 0 ? 4 : 2;
                _hitRate[(byte)CharacterClassType.Archer, i] = archerHitRate;

                _hitRate[(byte)CharacterClassType.Mage, i] = 0;

                fighterHitRate += i == 0 || (i - 4) % 10 == 0 || i > 0 && (i - 7) % 10 == 0 || i > 0 && (i - 10) % 10 == 0 ? 2 : 1;
                _hitRate[(byte)CharacterClassType.MartialArtist, i] = fighterHitRate;
            }
        }

        /// <summary>
        /// Gets the hit rate value for a character class at a specific level
        /// </summary>
        /// <param name="class">The character class type</param>
        /// <param name="level">The character level</param>
        /// <returns>The hit rate value</returns>
        public long GetHitRate(CharacterClassType @class, byte level)
        {
            return _hitRate![(byte)@class, level - 1];
        }
    }
}
