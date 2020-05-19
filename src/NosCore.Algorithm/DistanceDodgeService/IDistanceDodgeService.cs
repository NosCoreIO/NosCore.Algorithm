using NosCore.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NosCore.Algorithm.DistanceDodgeService
{
    public interface IDistanceDodgeService
    {
        long GetDistanceDodge(CharacterClassType entityClass, byte level);
    }
}
