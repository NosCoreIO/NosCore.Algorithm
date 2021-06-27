using System;
using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm
{
    internal class Constants
    {
        internal const byte MaxLevel = 99;
        internal const byte MaxFairyLevel = 80;
        internal const byte MaxJobLevel = 80;
        internal const byte MaxHeroLevel = 60;
        internal static readonly int ClassCount = Enum.GetNames(typeof(CharacterClassType)).Length;
        // Sums
        internal const short SumSandVNum = 1027;
        internal static readonly byte[] SumSuccess = { 100, 100, 85, 70, 50, 20 };
        internal static readonly ushort[] SumPrice = { 1500, 3000, 6000, 12000, 24000, 48000 };
        internal static readonly byte[] SumSand = { 5, 10, 15, 20, 25, 30 };
    }
}
