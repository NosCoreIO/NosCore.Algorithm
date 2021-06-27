//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.UpgradeService
{
    /// <summary>
    /// Interface for UpgradeService
    /// </summary>
    public interface IUpgradeService
    {
        /// <summary>
        /// Method to get sum success by upgrades
        /// </summary>
        /// <param name="sourceUpgrade">Source upgrade</param>
        /// <param name="targetUpgrade">Target upgrade</param>
        /// <returns>Value or 0 if fail</returns>
        byte GetSumSucess(byte sourceUpgrade, byte targetUpgrade);

        /// <summary>
        /// Method to get sum price by upgrades
        /// </summary>
        /// <param name="sourceUpgrade">Source upgrade</param>
        /// <param name="targetUpgrade">Target upgrade</param>
        /// <returns>Value or 0 if fail</returns>
        ushort GetSumPrice(byte sourceUpgrade, byte targetUpgrade);

        /// <summary>
        /// Method to get sum sand cost by upgrades
        /// </summary>
        /// <param name="sourceUpgrade">Source upgrade</param>
        /// <param name="targetUpgrade">Target upgrade</param>
        /// <returns>Value or 0 if fail</returns>
        ushort GetSumSand(byte sourceUpgrade, byte targetUpgrade);

        /// <summary>
        /// Method to get sum sand vnum
        /// </summary>
        /// <returns>Value</returns>
        short GetSumSandVNum();
    }
}
