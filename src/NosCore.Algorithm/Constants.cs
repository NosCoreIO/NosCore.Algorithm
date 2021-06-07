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
        internal const byte HeroAlgosChange = 54;
        internal static readonly int ClassCount = Enum.GetNames(typeof(CharacterClassType)).Length;
    }
}
