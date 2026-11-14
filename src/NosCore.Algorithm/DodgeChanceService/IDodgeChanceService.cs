namespace NosCore.Algorithm.DodgeChanceService
{
    /// <summary>
    /// Chance that a monster dodges a hit, from its dodge against the attacker's hit rate
    /// </summary>
    public interface IDodgeChanceService
    {
        /// <summary>
        /// Gets the dodge chance in percent
        /// </summary>
        /// <param name="dodge">The defender's dodge</param>
        /// <param name="hitRate">The attacker's hit rate</param>
        /// <returns>The chance in percent, at least 1</returns>
        double GetDodgeChance(int dodge, int hitRate);
    }
}
