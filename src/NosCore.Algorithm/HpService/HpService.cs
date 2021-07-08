//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;
using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.HpService
{
    public class HpService : IHpService
    {
        private readonly long[,] _hpData = new long[Constants.ClassCount, Constants.MaxLevel + 1];

        public HpService()
        {
            foreach (CharacterClassType classType in Enum.GetValues(typeof(CharacterClassType)))
            {
                for (var i = 1; i < Constants.MaxLevel + 1; i++)
                {
                    var hpx = i + Math.Floor((i - 1) * (double)(Constants.ClassConstants[(int)classType][0]) / 10);
                    var hp = (0.5 * Math.Pow(hpx, 2)) + (15.5 * hpx) + 205;
                    _hpData[(int)classType, i] = (long)hp;
                }
            }
        }
        public long GetHp(CharacterClassType @class, byte level)
        {
            return _hpData![(byte)@class, level];
        }
    }
}
