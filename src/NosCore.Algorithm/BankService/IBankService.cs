//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.BankService
{
    /// <summary>
    /// Service for the Cuarry Bank credit rating and withdrawal fee
    /// </summary>
    public interface IBankService
    {
        /// <summary>
        /// Gets the bank credit rating granted by a reputation level
        /// </summary>
        /// <param name="reputation">The reputation level</param>
        /// <returns>The bank rank</returns>
        BankRankType GetRank(ReputationType reputation);

        /// <summary>
        /// Gets the flat gold fee charged on each withdrawal
        /// </summary>
        /// <param name="reputation">The reputation level</param>
        /// <returns>The fee in gold</returns>
        long GetWithdrawalFee(ReputationType reputation);
    }
}
