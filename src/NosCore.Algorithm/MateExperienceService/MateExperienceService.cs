//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.MateExperienceService
{
    /// <summary>
    /// Provides pet and partner experience requirement calculations for different levels
    /// </summary>
    /// <remarks>
    /// A pet needs a twentieth of the curve and a partner a fifth. Both divisors come from the
    /// XpLoad field of sc_p and sc_n, which match to the unit across eleven levels between 1
    /// and 88.
    /// </remarks>
    public class MateExperienceService : IMateExperienceService
    {
        private const int PetDivisor = 20;
        private const int PartnerDivisor = 5;

        private readonly long[] _mateXpData = new long[Constants.MaxMateLevel + 1];

        /// <summary>
        /// Initializes a new instance of the MateExperienceService and pre-calculates experience
        /// requirements for all mate levels
        /// </summary>
        public MateExperienceService()
        {
            var step = new double[_mateXpData.Length];
            step[0] = 540;
            step[1] = 960;
            for (var i = 2; i < step.Length; i++)
            {
                step[i] = step[i - 1] + 420 + 120 * (i - 1);
            }

            var factor = 1d;
            _mateXpData[0] = 300;
            for (var i = 1; i < _mateXpData.Length; i++)
            {
                if (i < 79)
                {
                    factor = i switch
                    {
                        14 => 6 / 3d,
                        39 => 19 / 3d,
                        59 => 70 / 3d,
                        _ => factor
                    };

                    _mateXpData[i] = (long)(_mateXpData[i - 1] + factor * step[i - 1]);
                    continue;
                }

                factor = i switch
                {
                    79 => 5000,
                    82 => 9000,
                    84 => 13000,
                    _ => factor
                };

                _mateXpData[i] = (long)(_mateXpData[i - 1] + factor * (i + 2) * (i + 2));
            }
        }

        /// <summary>
        /// Gets the experience a pet needs to leave a specific level
        /// </summary>
        /// <param name="level">The pet level</param>
        /// <returns>The experience required</returns>
        public long GetPetExperience(byte level)
        {
            return At(level) / PetDivisor;
        }

        /// <summary>
        /// Gets the experience a partner needs to leave a specific level
        /// </summary>
        /// <param name="level">The partner level</param>
        /// <returns>The experience required</returns>
        public long GetPartnerExperience(byte level)
        {
            return At(level) / PartnerDivisor;
        }

        private long At(byte level)
        {
            var index = level < 1 ? 0 : level - 1;
            return _mateXpData[index >= _mateXpData.Length ? _mateXpData.Length - 1 : index];
        }
    }
}
