namespace NosCore.Algorithm.UpgradeBonusService
{
    /// <summary>
    /// Bonus the side ahead on upgrades gets in a hit: the weapon on damage, the armour on defence
    /// </summary>
    public interface IUpgradeBonusService
    {
        /// <summary>
        /// Gets the fraction added to the leading side's damage or defence
        /// </summary>
        /// <param name="upgradeLead">How many upgrade levels that side is ahead by</param>
        /// <returns>The fraction to add, 0 when neither side is ahead</returns>
        double GetUpgradeBonus(int upgradeLead);
    }
}
