using System;
using System.Collections.Generic;
using System.Text;

namespace NosCore.Algorithm.SecondaryDamageService
{
    public interface ISecondaryDamageService
    {
        long GetSecondaryMinDamage(byte entityClass, byte level);
        long GetSecondaryMaxDamage(byte entityClass, byte level);
    }
}
