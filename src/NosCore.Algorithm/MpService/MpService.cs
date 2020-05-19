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
        private readonly long[][] _mpData = new long[Constants.ClassCount][];

        public MpService()
        {
            _mpData[(byte)CharacterClassType.Archer] = new long[]
            {
                60, 69, 78, 87, 97, 108, 119, 130, 142, 155, 181, 195, 210, 225, 240, 256, 273, 290, 307, 325, 363, 382, 402, 423, 444, 465,
                487, 510, 533, 556, 605, 630, 655, 681, 708, 735, 762, 790, 819, 848, 907, 938, 969, 1000, 1032, 1065, 1098, 1131, 1165, 1200,
                1270, 1306, 1343, 1380, 1417, 1455, 1494, 1533, 1572, 1612, 1694, 1735, 1777, 1820, 1863, 1906, 1950, 1995, 2040, 2085, 2178,
                2225, 2272, 2320, 2369, 2418, 2467, 2517, 2568, 2619, 2722, 2775, 2828, 2881, 2935, 2990, 3045, 3100, 3156, 3213, 3327, 3385,
                3444, 3503, 3562, 3622, 3683, 3744, 3805
            };
            _mpData[(byte)CharacterClassType.MartialArtist] = new long[]
            {
                60, 69, 78, 87, 97, 119, 130, 142, 155, 168, 195, 210, 225, 240, 256, 290, 307, 325, 344, 363, 402, 423, 444, 465, 487, 533, 556,
                580, 605, 630, 681, 708, 735, 762, 790, 848, 877, 907, 938, 969, 1032, 1065, 1098, 1131, 1165, 1235, 1270, 1306, 1343, 1380, 1455, 1494,
                1533, 1572, 1612, 1694, 1735, 1777, 1820, 1863, 1950, 1995, 2040, 2085, 2131, 2225, 2272, 2320, 2369, 2418, 2517, 2568, 2619, 2670, 2722,
                2828, 2881, 2935, 2990, 3045, 3156, 3213, 3270, 3327, 3385, 3503, 3562, 3622, 3683, 3744, 3867, 3930, 3993, 4056, 4120, 4250, 4315, 4381, 4448
            };

            var adventurerMpAdd = 9;
            var magicianMpAdd = new[] { 9, 18, 21, 22, 25, 13, 27, 30, 31, 34 };

            _mpData[(byte)CharacterClassType.Adventurer] = new long[99];
            _mpData[(byte)CharacterClassType.Swordman] = new long[99];
            _mpData[(byte)CharacterClassType.Magician] = new long[99];

            _mpData[(byte)CharacterClassType.Adventurer][0] = 60;
            _mpData[(byte)CharacterClassType.Swordman][0] = 60;
            _mpData[(byte)CharacterClassType.Magician][0] = 60;
            var count = 9;
            var substract = true;
            for (var i = 1; i < 99; i++)
            {
                adventurerMpAdd += i % 4 == 0 ? 2 : 0;
                _mpData[(byte)CharacterClassType.Adventurer][i] =
                    _mpData[(byte)CharacterClassType.Adventurer][i - 1] + (i % 4 == 0 ? adventurerMpAdd - 1 : adventurerMpAdd);
                _mpData[(byte)CharacterClassType.Swordman][i] = _mpData[(byte)CharacterClassType.Adventurer][i];
                if ((i - 1) > 9)
                {
                    var switcher = !substract ? 1 : -1;
                    if ((i - 1) % 5 == 0)
                    {
                        count += !substract ? 1 : -1;
                        substract = count == 10 || count == 8 ? !substract : substract;
                        magicianMpAdd[(i - 1) % 10] = magicianMpAdd[(i - 1) % 10] + count;
                    }
                    else
                    {
                        magicianMpAdd[(i - 1) % 10] += 18 + switcher / ((i - 1) % 5 % 2 == 1 ? 1 : -1);
                    }

                }
                _mpData[(byte)CharacterClassType.Magician][i] =
                    _mpData[(byte)CharacterClassType.Magician][i - 1] + magicianMpAdd[(i - 1) % 10];
            }

        }
        public long GetMp(CharacterClassType @class, byte level)
        {
            return _mpData![(byte)@class][level - 1];
        }
    }
}
