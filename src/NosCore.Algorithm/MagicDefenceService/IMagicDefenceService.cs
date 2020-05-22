using NosCore.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NosCore.Algorithm.MagicDefenceService
{
    public interface IMagicDefenceService
    {
        long GetMagicDefence(CharacterClassType entityClass, byte level);
    }
}
