//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.UpgradeService
{
    /// <summary>
    /// Service implementation of IUpgradeService
    /// </summary>
    public class UpgradeService : IUpgradeService
    {
        /// <summary>
        /// Method to get sum success by upgrades
        /// </summary>
        /// <param name="sourceUpgrade">Source upgrade</param>
        /// <param name="targetUpgrade">Target upgrade</param>
        /// <returns>Value</returns>
        public byte GetSumSucess(byte sourceUpgrade, byte targetUpgrade)
        {
            if (sourceUpgrade + targetUpgrade + 1 > Constants.SumSuccess.Length)
            {
                return 0;
            }
            return Constants.SumSuccess[sourceUpgrade + targetUpgrade];
        }

        /// <summary>
        /// Method to get sum price by upgrades
        /// </summary>
        /// <param name="sourceUpgrade">Source upgrade</param>
        /// <param name="targetUpgrade">Target upgrade</param>
        /// <returns>Value or 0 if fail</returns>
        public ushort GetSumPrice(byte sourceUpgrade, byte targetUpgrade)
        {
            if (sourceUpgrade + targetUpgrade + 1 > Constants.SumPrice.Length)
            {
                return 0;
            }
            return Constants.SumPrice[sourceUpgrade + targetUpgrade];
        }

        /// <summary>
        /// Method to get sum sand cost by upgrades
        /// </summary>
        /// <param name="sourceUpgrade">Source upgrade</param>
        /// <param name="targetUpgrade">Target upgrade</param>
        /// <returns>Value or 0 if fail</returns>
        public ushort GetSumSand(byte sourceUpgrade, byte targetUpgrade)
        {
            if (sourceUpgrade + targetUpgrade + 1 > Constants.SumSand.Length)
            {
                return 0;
            }
            return Constants.SumSand[sourceUpgrade + targetUpgrade];
        }

        /// <summary>
        /// Method to get sum sand cost by upgrades
        /// </summary>
        /// <returns>Value or 0 if fail</returns>
        public short GetSumSandVNum()
        {
            return Constants.SumSandVNum;
        }
    }
}
