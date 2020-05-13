using System;

namespace NosCore.Algorithm.HpService
{
    //TODO finish/fix this service
    public class HpService : IHpService
    {
        private readonly double[,] _hpData = new double[Constants.ClassCount, Constants.MaxLevel];

        public HpService()
        {
            // Adventurer HP
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                _hpData[0, i] = (int)(1 / 2.0 * i * i + 31 / 2.0 * i + 205);
            }

            // Swordsman HP
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                uint j = 16;
                var hp = 946;
                var inc = 85;
                while (j <= i)
                {
                    if (j % 5 == 2)
                    {
                        hp += inc / 2;
                        inc += 2;
                    }
                    else
                    {
                        hp += inc;
                        inc += 4;
                    }

                    ++j;
                }

                _hpData[1, i] = hp;
            }

            // Magician HP
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                _hpData[3, i] = (int)((i + 15) * (i + 15) + i + 15.0 - 465 + 550);
            }

            // Archer HP
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                var hp = 680;
                var inc = 35;
                uint j = 16;
                while (j <= i)
                {
                    hp += inc;
                    ++inc;
                    if ((j % 10 == 1) || (j % 10 == 5) || (j % 10 == 8))
                    {
                        hp += inc;
                        ++inc;
                    }

                    ++j;
                }

                _hpData[2, i] = hp;
            }

            // MartialArtist HP
            //TODO: Find real formula, this is currently the swordsman statistics
            for (var i = 0; i < Constants.MaxLevel; i++)
            {
                uint j = 16;
                var hp = 946;
                var inc = 85;
                while (j <= i)
                {
                    if (j % 5 == 2)
                    {
                        hp += inc / 2;
                        inc += 2;
                    }
                    else
                    {
                        hp += inc;
                        inc += 4;
                    }

                    ++j;
                }

                _hpData[4, i] = hp;
            }
        }
        public long GetHp(byte @class, byte level)
        {
            return (long)_hpData![@class, level-1];
        }
    }
}
