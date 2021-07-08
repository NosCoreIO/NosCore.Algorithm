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
        internal static readonly int[][] ClassConstants = new int[][] { new int[] { 0, 0, 0 }, new int[] { 8, 2, 0 }, new int[] { 3, 6, 1 }, new int[] { 0, 2, 8 }, new int[] { 5, 3, 2 } };
    }
}
