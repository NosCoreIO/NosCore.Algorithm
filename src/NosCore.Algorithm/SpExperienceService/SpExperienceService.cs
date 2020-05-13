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

            for (int i = 1; i < 20; i++)
            {
                _spXpData[1, i] = 10000;
            }

            for (int i = 20; i < 38; i++)
            {
                _spXpData[1, i] = 100000 + (i - 20) * 500;
            }

            //TODO finish SpXp
            for (int i = 38; i < 99; i++)
            {
                _spXpData[1, i] = 1;
            }
        }
        public long GetSpExperience(byte level, bool isSecondarySp)
        {
            return (long)_spXpData![isSecondarySp ? 1 : 0, level - 1];
        }
    }
}
