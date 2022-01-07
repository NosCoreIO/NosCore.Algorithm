//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Shared.Enumerations;
using System;

namespace NosCore.Algorithm.MpService
{
    public class MpService : IMpService
    {
        private readonly long[,] _mpData = new long[Constants.ClassCount, Constants.MaxLevel];
        public readonly int[][] ClassConstants = new int[][] { new int[] { 0 }, new int[] { 0 }, new int[] { 1 }, new int[] { 8 }, new int[] { 2 } };

        public MpService()
        {
            foreach (CharacterClassType classType in Enum.GetValues(typeof(CharacterClassType)))
            {
                for (var i = 0; i < Constants.MaxLevel; i++)
                {
                    var mpx = i + 1 + Math.Floor(i * (double)ClassConstants[(int)classType][0] / 10);
                    var mp = Math.Floor(9.25 * mpx + 50.75) + ((int)((mpx - 2) / 4) * 2) * (Modulus(mpx - 2, 4) + 1 + (int)((mpx - 6) / 4) * 2);
                    _mpData[(int)classType, i] = (long)mp;
                }
            }
        }

        private static double Modulus(double dividend, double divisor)
        {
            double modulus = (Math.Abs(dividend) - (Math.Abs(divisor) * Math.Floor(Math.Abs(dividend) / Math.Abs(divisor)))) * Math.Sign(dividend);
            return modulus;
        }

        public long GetMp(CharacterClassType @class, byte level)
        {
            return _mpData![(byte)@class, level - 1];
        }
    }
}
