using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.DistanceDodgeService
{
    public class DistanceDodgeService : IDistanceDodgeService
    {
        private readonly long[,] _distanceDodge = new long[5, Constants.MaxLevel];

        public DistanceDodgeService()
        {
            var swordmanDodge = 8;
            var archerDodge = 18;
            var mageDodge = 8;
            var fighterDodge = 18;
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                _distanceDodge[(byte)CharacterClassType.Adventurer, i] = i + 10;

                swordmanDodge += (i - 5) % 5 == 0 ? 2 : 1;
                _distanceDodge[(byte)CharacterClassType.Swordsman, i] = swordmanDodge;

                archerDodge += ((i - 2) % 10 == 0 || (i - 4) % 10 == 0 || (i - 5) % 5 == 0 || (i - 7) % 10 == 0 || (i - 9) % 10 == 0 || (i - 10) % 10 == 0) ? 2 : 1;
                _distanceDodge[(byte)CharacterClassType.Archer, i] = archerDodge;

                mageDodge += (i - 5) % 5 == 0 ? 2 : 1;
                _distanceDodge[(byte)CharacterClassType.Mage, i] = mageDodge;

                fighterDodge += ((i - 4) % 10 == 0 || (i - 7) % 10 == 0 || (i - 10) % 10 == 0) ? 2 : 1;
                _distanceDodge[(byte)CharacterClassType.MartialArtist, i] = fighterDodge;

            }
        }

        public long GetDistanceDodge(CharacterClassType @class, byte level)
        {
            return _distanceDodge![(byte)@class, level - 1];
        }
    }
}
