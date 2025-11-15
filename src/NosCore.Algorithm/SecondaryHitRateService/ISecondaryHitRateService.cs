using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.SecondaryHitRateService
{
    /// <summary>
    /// Service for calculating secondary weapon hit rate values for different character classes
    /// </summary>
    public interface ISecondaryHitRateService
    {
        /// <summary>
        /// Gets the secondary weapon hit rate value for a character class at a specific level
        /// </summary>
        /// <param name="entityClass">The character class type</param>
        /// <param name="level">The character level</param>
        /// <returns>The secondary weapon hit rate value</returns>
        long GetSecondaryHitRate(CharacterClassType entityClass, byte level);
    }
}
