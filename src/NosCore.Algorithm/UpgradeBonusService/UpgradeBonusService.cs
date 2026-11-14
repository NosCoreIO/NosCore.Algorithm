using System;

namespace NosCore.Algorithm.UpgradeBonusService
{
    /// <inheritdoc />
    public class UpgradeBonusService : IUpgradeBonusService
    {
        private static readonly double[] Bonus = [0.0, 0.1, 0.15, 0.22, 0.32, 0.43, 0.54, 0.65, 0.9, 1.2, 2.0];

        /// <inheritdoc />
        public double GetUpgradeBonus(int upgradeLead) => upgradeLead <= 0 ? 0.0 : Bonus[Math.Min(upgradeLead, Bonus.Length - 1)];
    }
}
