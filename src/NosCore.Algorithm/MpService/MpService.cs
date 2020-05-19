//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;
using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.MpService
{
    public class MpService : IMpService
    {
        private readonly long[,] _mpData = new long[Constants.ClassCount, Constants.MaxLevel];

        public MpService()
        {
            var adventurerMpAdd = 9;
            var magicianMpAdd = new[] { 9, 18, 21, 22, 25, 13, 27, 30, 31, 34 };
            var martialArtistMpAdd = new[] { 9, 9, 9, 10, 22, 11, 12, 13, 13, 27 };
            var archerMpAdd = new[] { 9, 9, 9, 10, 11, 11, 11, 12, 13, 26 };

            _mpData[(byte)CharacterClassType.Adventurer, 0] = 60;
            _mpData[(byte)CharacterClassType.Swordman, 0] = 60;
            _mpData[(byte)CharacterClassType.Magician, 0] = 60;
            _mpData[(byte)CharacterClassType.MartialArtist, 0] = 60;
            _mpData[(byte)CharacterClassType.Archer, 0] = 60;
            var countMagician = 9;
            var countArcher = 11;
            var substractMagician = true;
            var substractArcher = false;
            var reverseArcher = 0;
            for (var i = 1; i < 99; i++)
            {
                adventurerMpAdd += i % 4 == 0 ? 2 : 0;
                _mpData[(byte)CharacterClassType.Adventurer, i] =
                    _mpData[(byte)CharacterClassType.Adventurer, i - 1] + (i % 4 == 0 ? adventurerMpAdd - 1 : adventurerMpAdd);
                _mpData[(byte)CharacterClassType.Swordman, i] = _mpData[(byte)CharacterClassType.Adventurer, i];
                if (i - 1 > 9)
                {
                    var switcher = !substractMagician ? 1 : -1;
                    if ((i - 1) % 5 == 0)
                    {
                        countMagician += !substractMagician ? 1 : -1;
                        substractMagician = countMagician == 10 || countMagician == 8 ? !substractMagician : substractMagician;
                        magicianMpAdd[(i - 1) % 10] = magicianMpAdd[(i - 1) % 10] + countMagician;
                    }
                    else
                    {
                        magicianMpAdd[(i - 1) % 10] += 18 + switcher / ((i - 1) % 5 % 2 == 1 ? 1 : -1);
                    }

                    if (i % 10 == 0)
                    {
                        countArcher += !substractArcher ? 1 : -1;
                        substractArcher = countArcher == 12 || countArcher == 10 ? !substractArcher : substractArcher;
                        archerMpAdd[(i - 1) % 10] = archerMpAdd[(i - 1) % 10] + countArcher;
                        reverseArcher++;
                    }
                    else
                    {
                        var switcherArcher = reverseArcher % 4 == 2 || reverseArcher % 4 == 3 ? -1 : 1;
                        archerMpAdd[(i - 1) % 10] += (switcherArcher == -1 ? 6 : 5) +
                                                     (i % 20 < 10
                                                         ? i % 4 == 2 || i % 4 == 1 ? 0 : switcherArcher
                                                         : i % 4 == 0 || i % 4 == 1 ? switcherArcher : 0);

                    }

                    martialArtistMpAdd[(i - 1) % 10] += (i - 1) % 5 == 4 ? 12 : 6;
                }
                _mpData[(byte)CharacterClassType.Magician, i] =
                    _mpData[(byte)CharacterClassType.Magician, i - 1] + magicianMpAdd[(i - 1) % 10];

                _mpData[(byte)CharacterClassType.MartialArtist, i] =
                    _mpData[(byte)CharacterClassType.MartialArtist, i - 1] + martialArtistMpAdd[(i - 1) % 10];

                _mpData[(byte)CharacterClassType.Archer, i] =
                    _mpData[(byte)CharacterClassType.Archer, i - 1] + archerMpAdd[(i - 1) % 10];
            }

        }
        public long GetMp(CharacterClassType @class, byte level)
        {
            return _mpData![(byte)@class, level - 1];
        }
    }
}
