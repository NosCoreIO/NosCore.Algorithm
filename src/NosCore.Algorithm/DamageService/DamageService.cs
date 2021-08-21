//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.DamageService
{
    public class DamageService : IDamageService
    {
        private readonly long[,] _minDamage = new long[5, Constants.MaxLevel];

        public DamageService()
        {
            _minDamage[(byte)CharacterClassType.Adventurer, 0] = 10;
            _minDamage[(byte)CharacterClassType.Swordsman, 0] = 10;
            _minDamage[(byte)CharacterClassType.Archer, 0] = 60;
            _minDamage[(byte)CharacterClassType.Mage, 0] = 10;
            _minDamage[(byte)CharacterClassType.MartialArtist, 0] = 10;

            var swordmanMinUp = 2;
            var mageMinUp = 2;
            var fighterMinUp = 2;
            for (var i = 1; i < Constants.MaxLevel; i++)
            {
                _minDamage[(byte)CharacterClassType.Adventurer, i] = i + 10;

                if ((i - 2) % 10 == 0 || (i - 7) % 10 == 0)
                {
                    swordmanMinUp++;
                }
                else if ((i - 1) % 10 == 0 || (i - 6) % 10 == 0)
                {
                    swordmanMinUp--;
                }

                _minDamage[(byte)CharacterClassType.Swordsman, i] = _minDamage[(byte)CharacterClassType.Swordsman, i - 1] + swordmanMinUp;

                int archerMinUp;
                if ((i - 1) % 10 == 0 || (i - 3) % 10 == 0 || (i - 5) % 10 == 0 || (i - 8) % 10 == 0)
                {
                    archerMinUp = 1;
                }
                else
                {
                    archerMinUp = 2;
                }

                _minDamage[(byte)CharacterClassType.Archer, i] = _minDamage[(byte)CharacterClassType.Archer, i - 1] + archerMinUp;


                if ((i - 2) % 10 == 0 || (i - 7) % 10 == 0)
                {
                    mageMinUp++;
                }
                else if ((i - 1) % 10 == 0 || (i - 6) % 10 == 0)
                {
                    mageMinUp--;
                }

                _minDamage[(byte)CharacterClassType.Mage, i] = _minDamage[(byte)CharacterClassType.Mage, i - 1] + mageMinUp;


                if ((i - 2) % 10 == 0 || (i - 4) % 10 == 0 || (i - 6) % 10 == 0 || (i - 8) % 10 == 0 || (i - 10) % 10 == 0)
                {
                    fighterMinUp++;
                }
                else if ((i - 1) % 10 == 0 || (i - 3) % 10 == 0 || (i - 5) % 10 == 0 || (i - 7) % 10 == 0 || (i - 9) % 10 == 0)
                {
                    fighterMinUp--;
                }

                _minDamage[(byte)CharacterClassType.MartialArtist, i] = _minDamage[(byte)CharacterClassType.MartialArtist, i - 1] + fighterMinUp;
            }
        }

        public long GetMinDamage(CharacterClassType @class, byte level)
        {
            return _minDamage![(byte)@class, level - 1];
        }

        public long GetMaxDamage(CharacterClassType @class, byte level) => GetMinDamage(@class, level);
    }
}
