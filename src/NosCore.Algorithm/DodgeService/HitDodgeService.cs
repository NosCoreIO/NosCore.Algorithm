using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.HitDodgeService
{
    /// <summary>
    /// Provides close combat dodge value calculations for different character classes and levels
    /// </summary>
    public class HitDodgeService : IHitDodgeService
    {
        private readonly long[,] _hitDodge = new long[Constants.ClassCount, Constants.MaxLevel];

        /// <summary>
        /// Initializes a new instance of the HitDodgeService and pre-calculates close combat dodge values for all character classes and levels
        /// </summary>
        public HitDodgeService()
        {
            var swordmanDodge = 8;
            var archerDodge = 18;
            var mageDodge = 18;
            var fighterDodge = 28;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                _hitDodge[(byte)CharacterClassType.Adventurer, i] = i + 10;

                swordmanDodge += (i - 5) % 5 == 0 ? 2 : 1;
                _hitDodge[(byte)CharacterClassType.Swordsman, i] = swordmanDodge;

                archerDodge += ((i - 2) % 10 == 0 || (i - 4) % 10 == 0 || (i - 5) % 5 == 0 || (i - 7) % 10 == 0 || (i - 9) % 10 == 0 || (i - 10) % 10 == 0) ? 2 : 1;
                _hitDodge[(byte)CharacterClassType.Archer, i] = archerDodge;

                mageDodge += (i - 5) % 5 == 0 ? 2 : 1;
                _hitDodge[(byte)CharacterClassType.Mage, i] = mageDodge;

                fighterDodge += ((i - 4) % 10 == 0 || (i - 7) % 10 == 0 || (i - 10) % 10 == 0) ? 2 : 1;
                _hitDodge[(byte)CharacterClassType.MartialArtist, i] = fighterDodge;

            }
        }

        /// <summary>
        /// Gets the close combat dodge value for a character class at a specific level
        /// </summary>
        /// <param name="class">The character class type</param>
        /// <param name="level">The character level</param>
        /// <returns>The close combat dodge value</returns>
        public long GetHitDodge(CharacterClassType @class, byte level)
        {
            return _hitDodge![(byte)@class, level - 1];
        }
    }
}
