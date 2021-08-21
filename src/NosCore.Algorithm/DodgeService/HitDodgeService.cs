using NosCore.Shared.Enumerations;
using System;

namespace NosCore.Algorithm.HitDodgeService
{
    public class HitDodgeService : IHitDodgeService
    {
        private readonly long[,] _hitDodge = new long[Enum.GetNames(typeof(CharacterClassType)).Length, Constants.MaxLevel];

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

        public long GetHitDodge(CharacterClassType @class, byte level)
        {
            return _hitDodge![(byte)@class, level - 1];
        }
    }
}
