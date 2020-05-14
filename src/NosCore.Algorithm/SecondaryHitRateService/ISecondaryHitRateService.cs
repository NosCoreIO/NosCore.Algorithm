using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.SecondaryHitRateService
{
    public interface ISecondaryHitRateService
    {
        long GetSecondaryHitRate(CharacterClassType entityClass, byte level);
    }
}
