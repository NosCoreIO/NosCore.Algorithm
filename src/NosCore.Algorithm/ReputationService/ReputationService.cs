//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.ReputationService
{
    public class ReputationService : IReputationService
    {
        private readonly long[] _reputData = new long[26];

        public ReputationService()
        {
            _reputData[(byte)ReputationType.GreenBeginner] = 50;
            _reputData[(byte)ReputationType.BlueBeginner] = 150;
            _reputData[(byte)ReputationType.RedBeginner] = 250;

            _reputData[(byte)ReputationType.GreenTrainee] = 500;
            _reputData[(byte)ReputationType.BlueTrainee] = 750;
            _reputData[(byte)ReputationType.RedTrainee] = 1000;

            _reputData[(byte)ReputationType.GreenExperienced] = 2250;
            _reputData[(byte)ReputationType.BlueExperienced] = 3500;
            _reputData[(byte)ReputationType.RedExperienced] = 5000;

            _reputData[(byte)ReputationType.GreenSoldier] = 9500;
            _reputData[(byte)ReputationType.BlueSoldier] = 19000;
            _reputData[(byte)ReputationType.RedSoldier] = 25000;

            _reputData[(byte)ReputationType.GreenExpert] = 40000;
            _reputData[(byte)ReputationType.BlueExpert] = 60000;
            _reputData[(byte)ReputationType.RedExpert] = 85000;

            _reputData[(byte)ReputationType.GreenLeader] = 115000;
            _reputData[(byte)ReputationType.BlueLeader] = 150000;
            _reputData[(byte)ReputationType.RedLeader] = 190000;

            _reputData[(byte)ReputationType.GreenMaster] = 235000;
            _reputData[(byte)ReputationType.BlueMaster] = 285000;
            _reputData[(byte)ReputationType.RedMaster] = 350000;

            _reputData[(byte)ReputationType.GreenNos] = 500000;
            _reputData[(byte)ReputationType.BlueNos] = 1500000;
            _reputData[(byte)ReputationType.RedNos] = 2500000;

            _reputData[(byte)ReputationType.GreenElite] = 3750000;
            _reputData[(byte)ReputationType.BlueElite] = 5000000;
            _reputData[(byte)ReputationType.RedElite] = long.MaxValue;
        }

        public byte GetLevelFromReputation(long reputation)
        {
            for (byte i = 0; i < _reputData.Length; i++)
            {
                if (_reputData[i] < reputation)
                {
                    return i;
                }
            }

            return (byte)ReputationType.RedElite;
        }

        public (long, long) GetReputation(byte level)
        {
            return (_reputData[level - 1] + level != 1 ? 1 : 0, _reputData[level]);
        }
    }
}
