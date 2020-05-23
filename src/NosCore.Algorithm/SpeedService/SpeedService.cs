//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System.Collections.Generic;
using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.SpeedService
{
    public class SpeedService : ISpeedService
    {
        private readonly Dictionary<CharacterClassType, byte> _data = new Dictionary<CharacterClassType, byte>();

        public SpeedService()
        {
            _data[CharacterClassType.Adventurer] = 11;
            _data[CharacterClassType.Swordman] = 11;
            _data[CharacterClassType.Archer] = 12;
            _data[CharacterClassType.Magician] = 10;
            _data[CharacterClassType.MartialArtist] = 11;
        }

        public byte GetSpeed(CharacterClassType entityClass)
        {
            return _data[entityClass];
        }
    }
}
