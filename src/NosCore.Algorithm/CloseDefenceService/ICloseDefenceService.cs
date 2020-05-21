using NosCore.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NosCore.Algorithm.CloseDefenceService
{
    public interface ICloseDefenceService
    {
        long GetCloseDefence(CharacterClassType entityClass, byte level);
    }
}
