using NosCore.Shared.Enumerations;
using System;
using System.Collections.Generic;
using System.Text;

namespace NosCore.Algorithm.HitDodgeService
{
    public interface IHitDodgeService
    {
        long GetHitDodge(CharacterClassType entityClass, byte level);
    }
}
