using NosCore.Shared.Enumerations;
using System;

namespace NosCore.Algorithm
{
    internal class Constants
    {
        internal const byte MaxLevel = 99;
        internal const byte MaxFairyLevel = 80;
        internal const byte MaxJobLevel = 80;
        internal const byte MaxHeroLevel = 60;
        internal const byte MaxMateLevel = 99;
        internal const byte MaxFamilyLevel = 30;
        internal const byte MaxFamilyUpgradeLevel = 2;
        internal const byte MaxGroupSize = 3;
        internal const byte MaxCellonLevel = 10;
        internal const byte MaxSpUpgrade = 20;
        internal const byte MaxEquipmentUpgrade = 13;
        internal const short PityGaugeMaximum = 1000;
        internal const byte MaxShellOptionLevel = 12;
        internal const byte MinShellValueLevel = 30;
        internal const byte MaxSpPerfection = 100;
        internal const byte MaxSumLevel = 5;
        internal static readonly int ClassCount = Enum.GetNames(typeof(CharacterClassType)).Length;
    }
}
