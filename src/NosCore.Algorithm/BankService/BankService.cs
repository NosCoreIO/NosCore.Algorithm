//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System.Collections.Generic;
using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.BankService
{
    /// <summary>
    /// Provides the Cuarry Bank credit rating and withdrawal fee for each reputation level
    /// </summary>
    public class BankService : IBankService
    {
        private readonly Dictionary<ReputationType, (BankRankType Rank, long Fee)> _bankData = new()
        {
            [ReputationType.GreenBeginner] = (BankRankType.Bronze3, 528000),
            [ReputationType.BlueBeginner] = (BankRankType.Bronze3, 517000),
            [ReputationType.RedBeginner] = (BankRankType.Bronze3, 506000),
            [ReputationType.GreenTrainee] = (BankRankType.Bronze3, 495000),
            [ReputationType.BlueTrainee] = (BankRankType.Bronze3, 484000),
            [ReputationType.RedTrainee] = (BankRankType.Bronze3, 473000),
            [ReputationType.GreenExperienced] = (BankRankType.Bronze2, 420000),
            [ReputationType.BlueExperienced] = (BankRankType.Bronze2, 410000),
            [ReputationType.RedExperienced] = (BankRankType.Bronze2, 400000),
            [ReputationType.GreenSoldier] = (BankRankType.Bronze1, 351000),
            [ReputationType.BlueSoldier] = (BankRankType.Bronze1, 342000),
            [ReputationType.RedSoldier] = (BankRankType.Bronze1, 333000),
            [ReputationType.GreenExpert] = (BankRankType.Silver3, 288000),
            [ReputationType.BlueExpert] = (BankRankType.Silver3, 280000),
            [ReputationType.RedExpert] = (BankRankType.Silver3, 272000),
            [ReputationType.GreenLeader] = (BankRankType.Silver2, 231000),
            [ReputationType.BlueLeader] = (BankRankType.Silver2, 224000),
            [ReputationType.RedLeader] = (BankRankType.Silver2, 217000),
            [ReputationType.GreenMaster] = (BankRankType.Silver1, 180000),
            [ReputationType.BlueMaster] = (BankRankType.Silver1, 174000),
            [ReputationType.RedMaster] = (BankRankType.Silver1, 168000),
            [ReputationType.GreenNos] = (BankRankType.Gold3, 135000),
            [ReputationType.BlueNos] = (BankRankType.Gold3, 130000),
            [ReputationType.RedNos] = (BankRankType.Gold2, 125000),
            [ReputationType.GreenElite] = (BankRankType.Gold2, 96000),
            [ReputationType.BlueElite] = (BankRankType.Gold2, 92000),
            [ReputationType.RedElite] = (BankRankType.Gold1, 66000),
            [ReputationType.GreenLegend] = (BankRankType.Diamond2, 42000),
            [ReputationType.BlueLegend] = (BankRankType.Diamond1, 20000),
            [ReputationType.AncientHero] = (BankRankType.Vip, 0),
            [ReputationType.MysteriousHero] = (BankRankType.Vip, 0),
            [ReputationType.LegendaryHero] = (BankRankType.Vip, 0),
        };

        /// <summary>
        /// Gets the bank credit rating granted by a reputation level
        /// </summary>
        /// <param name="reputation">The reputation level</param>
        /// <returns>The bank rank</returns>
        public BankRankType GetRank(ReputationType reputation)
        {
            return _bankData[reputation].Rank;
        }

        /// <summary>
        /// Gets the flat gold fee charged on each withdrawal
        /// </summary>
        /// <param name="reputation">The reputation level</param>
        /// <returns>The fee in gold</returns>
        public long GetWithdrawalFee(ReputationType reputation)
        {
            return _bankData[reputation].Fee;
        }
    }
}
