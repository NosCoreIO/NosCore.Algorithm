using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.MagicDefenceService
{
    public class MagicDefenceService : IMagicDefenceService
    {
        private readonly long[,] _magicDefence = new long[Constants.ClassCount, Constants.MaxLevel];

        public MagicDefenceService()
        {
            var adventurerDefence = 4;
            var swordmanDefence = 4;
            var archerDefence = 4;
            var mageDefence = 4;
            var fighterDefence = 4;

            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                adventurerDefence += i % 2 == 0 ? 1 : 0;
                _magicDefence[(byte)CharacterClassType.Adventurer, i] = adventurerDefence;

                swordmanDefence += (i % 2 == 0) ? 1 : 0;
                _magicDefence[(byte)CharacterClassType.Swordsman, i] = swordmanDefence;

                bool plus = i > 10 && i < 20 || i > 30 && i < 40 || i > 50 && i < 60 || i > 70 && i < 80 || i > 90 && i < 99;
                archerDefence += plus ? ((i + 1) % 2 == 0 ? 1 : 0) : i % 2 == 0 ? 1 : 0;
                _magicDefence[(byte)CharacterClassType.Archer, i] = archerDefence;

                mageDefence += (i % 2 == 0 || (i - 3) % 10 == 0 || (i - 5) % 5 == 0 || (i - 7) % 10 == 0 || (i - 9) % 10 == 0) ? 1 : 0;
                _magicDefence[(byte)CharacterClassType.Mage, i] = mageDefence;

                fighterDefence += ((i - 2) % 10 == 0 || (i - 4) % 10 == 0 || (i - 5) % 5 == 0 || (i - 7) % 10 == 0 || (i - 9) % 10 == 0) ? 1 : 0;
                _magicDefence[(byte)CharacterClassType.MartialArtist, i] = fighterDefence;
            }
        }

        public long GetMagicDefence(CharacterClassType @class, byte level)
        {
            return _magicDefence![(byte)@class, level - 1];
        }
    }
}
