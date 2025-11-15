//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.ReputationService
{
    /// <summary>
    /// Provides reputation level and threshold calculations
    /// </summary>
    public class ReputationService : IReputationService
    {
        private readonly Dictionary<ReputationType, long> _reputData = new Dictionary<ReputationType, long>();

        /// <summary>
        /// Initializes a new instance of the ReputationService and sets up reputation thresholds for each reputation type
        /// </summary>
        public ReputationService()
        {
            _reputData[ReputationType.GreenBeginner] = 50;
            _reputData[ReputationType.BlueBeginner] = 150;
            _reputData[ReputationType.RedBeginner] = 250;

            _reputData[ReputationType.GreenTrainee] = 500;
            _reputData[ReputationType.BlueTrainee] = 750;
            _reputData[ReputationType.RedTrainee] = 1000;

            _reputData[ReputationType.GreenExperienced] = 2250;
            _reputData[ReputationType.BlueExperienced] = 3500;
            _reputData[ReputationType.RedExperienced] = 5000;

            _reputData[ReputationType.GreenSoldier] = 9500;
            _reputData[ReputationType.BlueSoldier] = 19000;
            _reputData[ReputationType.RedSoldier] = 25000;

            _reputData[ReputationType.GreenExpert] = 40000;
            _reputData[ReputationType.BlueExpert] = 60000;
            _reputData[ReputationType.RedExpert] = 85000;

            _reputData[ReputationType.GreenLeader] = 115000;
            _reputData[ReputationType.BlueLeader] = 150000;
            _reputData[ReputationType.RedLeader] = 190000;

            _reputData[ReputationType.GreenMaster] = 235000;
            _reputData[ReputationType.BlueMaster] = 285000;
            _reputData[ReputationType.RedMaster] = 350000;

            _reputData[ReputationType.GreenNos] = 500000;
            _reputData[ReputationType.BlueNos] = 1500000;
            _reputData[ReputationType.RedNos] = 2500000;

            _reputData[ReputationType.GreenElite] = 3750000;
            _reputData[ReputationType.BlueElite] = 5000000;

            _reputData[ReputationType.RedElite] = long.MaxValue;
            _reputData[ReputationType.GreenLegend] = long.MaxValue;
            _reputData[ReputationType.BlueLegend] = long.MaxValue;
            _reputData[ReputationType.AncientHero] = long.MaxValue;
            _reputData[ReputationType.MysteriousHero] = long.MaxValue;
            _reputData[ReputationType.LegendaryHero] = long.MaxValue;
        }

        /// <summary>
        /// Gets the reputation level type based on a reputation value
        /// </summary>
        /// <param name="reputation">The reputation value</param>
        /// <returns>The reputation level type</returns>
        public ReputationType GetLevelFromReputation(long reputation)
        {
            foreach (var reput in Enum.GetValues(typeof(ReputationType)).Cast<ReputationType>())
            {
                if (_reputData[reput] >= reputation)
                {
                    return reput;
                }
            }

            return ReputationType.RedElite;
        }

        /// <summary>
        /// Gets the reputation value range for a specific reputation level
        /// </summary>
        /// <param name="level">The reputation level type</param>
        /// <returns>A tuple containing the minimum and maximum reputation values for the level</returns>
        public (long, long) GetReputation(ReputationType level)
        {
            return (level == ReputationType.GreenBeginner ? 0 : _reputData[level < ReputationType.RedElite ? (ReputationType)level - 1 : ReputationType.BlueElite] + 1, level < ReputationType.RedElite ? _reputData[level] : long.MaxValue);
        }
    }
}
