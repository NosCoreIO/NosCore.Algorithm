using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.CloseDefenceService
{
    /// <summary>
    /// Provides close combat defence value calculations for different character classes and levels
    /// </summary>
    public class CloseDefenceService : ICloseDefenceService
    {
        private readonly long[,] _closeDefence = new long[Constants.ClassCount, Constants.MaxLevel];

        /// <summary>
        /// Initializes a new instance of the CloseDefenceService and pre-calculates close defence values for all character classes and levels
        /// </summary>
        public CloseDefenceService()
        {
            var adventurerDefence = 4;
            var swordmanDefence = 4;
            var archerDefence = 4;
            var mageDefence = 4;
            var fighterDefence = 4;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                adventurerDefence += i % 2 == 0 ? 1 : 0;
                _closeDefence[(byte)CharacterClassType.Adventurer, i] = adventurerDefence;

                swordmanDefence += (i % 2 == 0 || (i - 3) % 10 == 0 || (i - 5) % 10 == 0 || (i - 7) % 10 == 0 || (i - 9) % 10 == 0 || (i - 10) % 10 == 0) ? 1 : 0;
                _closeDefence[(byte)CharacterClassType.Swordsman, i] = swordmanDefence;

                bool plus = i > 10 && i < 20 || i > 30 && i < 40 || i > 50 && i < 60 || i > 70 && i < 80 || i > 90 && i < 99;

                archerDefence += plus ? ((i +1 - 2) % 10 == 0 || (i + 1 - 4) % 10 == 0 || (i + 1 - 5) % 5 == 0 || (i + 1 - 7) % 10 == 0 || (i + 1 - 8) % 10 == 0 ? 1 : 0) : (i - 2) % 10 == 0 || (i - 4) % 10 == 0 || (i - 5) % 5 == 0 || (i - 7) % 10 == 0 || (i - 8) % 10 == 0  ? 1 : 0;
                _closeDefence[(byte)CharacterClassType.Archer, i] = archerDefence;

                mageDefence += i % 2 == 0 ? 1 : 0;
                _closeDefence[(byte)CharacterClassType.Mage, i] = mageDefence;

                fighterDefence += ((i - 2) % 10 == 0 || (i - 3) % 20 == 0 || (i - 4) % 10 == 0 || (i - 6) % 10 == 0 || (i - 7) % 20 == 0 || (i - 8) % 10 == 0 || (i - 10) % 10 == 0 || i > 10 && (i - 11) % 20 == 0 || i > 10 && (i - 15) % 20 == 0 || i > 10 && (i - 19) % 20 == 0) ? 1 : 0;
                _closeDefence[(byte)CharacterClassType.MartialArtist, i] = fighterDefence;
            }
        }

        /// <summary>
        /// Gets the close defence value for a character class at a specific level
        /// </summary>
        /// <param name="class">The character class type</param>
        /// <param name="level">The character level</param>
        /// <returns>The close defence value</returns>
        public long GetCloseDefence(CharacterClassType @class, byte level)
        {
            return _closeDefence![(byte)@class, level - 1];
        }
    }
}
