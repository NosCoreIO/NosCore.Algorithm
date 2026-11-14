using System;

namespace NosCore.Algorithm.DodgeChanceService
{
    /// <inheritdoc />
    public class DodgeChanceService : IDodgeChanceService
    {
        /// <inheritdoc />
        /// <remarks>
        /// A cubic in the dodge to hit rate ratio, capped at 5: the chance rises sharply once the
        /// attacker's hit rate falls behind the defender's dodge by about twice.
        /// </remarks>
        public double GetDodgeChance(int dodge, int hitRate)
        {
            var ratio = Math.Min(5.0, dodge / (double)(hitRate + 1));
            return Math.Max(1.0, -0.25 * Math.Pow(ratio, 3) - 0.57 * Math.Pow(ratio, 2) + 25.3 * ratio - 1.41);
        }
    }
}
