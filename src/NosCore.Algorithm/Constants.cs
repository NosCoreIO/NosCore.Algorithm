using System;
using System.Collections.Generic;
using System.Text;
using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm
{
    internal class Constants
    {
        internal const byte MaxLevel = 99;
        internal const byte MaxJobLevel = 80;
        internal static readonly int ClassCount = Enum.GetNames(typeof(CharacterClassType)).Length;
    }
}
