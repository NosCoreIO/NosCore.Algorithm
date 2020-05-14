//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.SpExperienceService
{
    public class SpExperienceService : ISpExperienceService
    {
        private readonly double[,] _spXpData = new double[2, Constants.MaxLevel];

        public SpExperienceService()
        {
            _spXpData[0, 0] = 15000;
            _spXpData[0, 19] = 218000;
            for (int i = 1; i < 19; i++)
            {
                _spXpData[0,i] = _spXpData[0, i - 1] + 10000;
            }
            for (int i = 20; i < _spXpData.GetLength(1); i++)
            {
                _spXpData[0, i] = _spXpData[0, i - 1] + 6 * (3 * i * (i + 1) + 1);
            }

            for (int i = 0; i < Constants.MaxLevel; i++)
            {
                if (i < 19)
                {
                    _spXpData[1, i] = 10000;
                } else if (i == 19)
                {
                    _spXpData[1, i] = 100000;
                }
                else if (i < 37)
                {
                    _spXpData[1, i] = _spXpData[1, i-1] + 5000;
                }
                else
                {
                    _spXpData[1, i] = 1;
                }

            }

        }
        public long GetSpExperience(byte level, bool isSecondarySp)
        {
            return (long)_spXpData![isSecondarySp ? 1 : 0, level - 1];
        }
    }
}
