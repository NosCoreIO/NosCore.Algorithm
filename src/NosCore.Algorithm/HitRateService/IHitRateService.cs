using System;
using System.Collections.Generic;
using System.Text;

namespace NosCore.Algorithm.HitRateService
{
    public interface IHitRateService
    {
        long GetHitRate(byte entityClass, byte level);
    }
}
