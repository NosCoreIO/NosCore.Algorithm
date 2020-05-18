//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.SpExperienceService
{
    public class SpExperienceService : ISpExperienceService
    {
        private readonly long[,] _spXpData = new long[2, Constants.MaxLevel];

        public SpExperienceService()
        {
            _spXpData[1, 0] = 10000;
            _spXpData[0, 0] = 15000;
            _spXpData[0, 19] = 218000;
            _spXpData[1, 19] = 100000;
            for (var i = 1; i < 19; i++)
            {
                _spXpData[0, i] = _spXpData[0, i - 1] + 10000;
                _spXpData[1, i] = _spXpData[1, i - 1];
            }
            for (var i = 20; i < _spXpData.GetLength(1); i++)
            {
                _spXpData[0, i] = _spXpData[0, i - 1] + 6 * (3 * i * (i + 1) + 1);
                _spXpData[1, i] = i switch
                {
                    37 => 304000,
                    47 => 672000,
                    _ => _spXpData[1, i - 1] + (i < 37 ? 5000 : i < 47 ? 8000 : 14000)
                };
            }

        }
        public long GetSpExperience(byte level, bool isSecondarySp)
        {
            return (long)_spXpData![isSecondarySp ? 1 : 0, level - 1];
        }
    }
}
