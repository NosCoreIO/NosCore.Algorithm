using NosCore.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NosCore.Algorithm.DistanceDefenceService
{
    public interface IDistanceDefenceService
    {
        long GetDistanceDefence(CharacterClassType entityClass, byte level);
    }
}
