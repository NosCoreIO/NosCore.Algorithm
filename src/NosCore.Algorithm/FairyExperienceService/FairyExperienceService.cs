//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.FairyExperienceService
{
    public class FairyExperienceService : IFairyExperienceService
    {
        private readonly int[] _fairyXpData = new int[Constants.MaxFairyLevel];

        public FairyExperienceService()
        {
            for (var i = 0; i < _fairyXpData.Length; i++)
            {
                _fairyXpData[i] = i < 40 ? i * i + 50 : (i * i + 50) * 3;
            }

        }
        public int GetFairyExperience(byte level)
        {
            return _fairyXpData![level];
        }
    }
}
