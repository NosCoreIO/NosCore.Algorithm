//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System.Collections.Generic;
using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.SpeedService
{
    /// <summary>
    /// Provides base speed values for different character classes
    /// </summary>
    public class SpeedService : ISpeedService
    {
        private readonly Dictionary<CharacterClassType, byte> _data = new Dictionary<CharacterClassType, byte>();

        /// <summary>
        /// Initializes a new instance of the SpeedService and sets up base speed values for all character classes
        /// </summary>
        public SpeedService()
        {
            _data[CharacterClassType.Adventurer] = 11;
            _data[CharacterClassType.Swordsman] = 11;
            _data[CharacterClassType.Archer] = 12;
            _data[CharacterClassType.Mage] = 10;
            _data[CharacterClassType.MartialArtist] = 11;
        }

        /// <summary>
        /// Gets the base speed value for a character class
        /// </summary>
        /// <param name="entityClass">The character class type</param>
        /// <returns>The base speed value</returns>
        public byte GetSpeed(CharacterClassType entityClass)
        {
            return _data[entityClass];
        }
    }
}
