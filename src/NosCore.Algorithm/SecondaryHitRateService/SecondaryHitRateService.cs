using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.SecondaryHitRateService
{
    /// <summary>
    /// Provides secondary weapon hit rate value calculations for different character classes and levels
    /// </summary>
    public class SecondaryHitRateService : ISecondaryHitRateService
    {
        private readonly long[,] _secondaryHitRate = new long[Constants.ClassCount, Constants.MaxLevel];

        /// <summary>
        /// Initializes a new instance of the SecondaryHitRateService and pre-calculates secondary hit rate values for all character classes and levels
        /// </summary>
        public SecondaryHitRateService()
        {
            var adventurerHit = 18;
            var adventurerHitUp = 2;
            var fighterHit = 16;
            var mageHit = 16;
            var archerHit = 23;
            var swordmanHit = 16;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                adventurerHit += adventurerHitUp;
                _secondaryHitRate[(byte)CharacterClassType.Adventurer, i] = adventurerHit;

                swordmanHit += (i - 5) % 5 == 0 ? 4 : 2;
                _secondaryHitRate[(byte)CharacterClassType.Swordsman, i] = swordmanHit;

                archerHit += i != 0 && ((i - 1) % 10 == 0 || (i - 3) % 10 == 0 || (i - 5) % 10 == 0 || (i - 8) % 10 == 0) ? 1 : 2;
                _secondaryHitRate[(byte)CharacterClassType.Archer, i] = archerHit;

                mageHit += (i - 5) % 5 == 0 ? 4 : 2;
                _secondaryHitRate[(byte)CharacterClassType.Mage, i] = mageHit;

                fighterHit += (i - 4) % 4 == 0 || (i - 10) % 10 == 0 ? 4 : 2;
                _secondaryHitRate[(byte)CharacterClassType.MartialArtist, i] = fighterHit;
            }
        }

        /// <summary>
        /// Gets the secondary weapon hit rate value for a character class at a specific level
        /// </summary>
        /// <param name="class">The character class type</param>
        /// <param name="level">The character level</param>
        /// <returns>The secondary weapon hit rate value</returns>
        public long GetSecondaryHitRate(CharacterClassType @class, byte level)
        {
            return (long)_secondaryHitRate![(byte)@class, level - 1];
        }
    }
}
