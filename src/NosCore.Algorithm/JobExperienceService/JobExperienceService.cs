//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.JobExperienceService
{
    public class JobExperienceService : IJobExperienceService
    {
        private readonly long[,] _jobXpData = new long[Constants.ClassCount, Constants.MaxJobLevel];

        public JobExperienceService()
        {
            _jobXpData[(byte)CharacterClassType.Adventurer, 0] = 2200;
            _jobXpData[(byte)CharacterClassType.Archer, 0] = 14500;
            _jobXpData[(byte)CharacterClassType.Magician, 0] = 14500;
            _jobXpData[(byte)CharacterClassType.MartialArtist, 0] = 14500;
            _jobXpData[(byte)CharacterClassType.Swordman, 0] = 14500;

            for (var i = 1; i < Constants.MaxJobLevel; i++)
            {
                if (i < 20)
                {
                    _jobXpData[(byte)CharacterClassType.Adventurer, i] = _jobXpData[(byte)CharacterClassType.Adventurer, i - 1] + 700;
                }

                _jobXpData[(byte)CharacterClassType.Archer, i] = _jobXpData[(byte)CharacterClassType.Archer, i - 1] + ((i > 39) ? 15000 : 4500);

                _jobXpData[(byte)CharacterClassType.Magician, i] = _jobXpData[(byte)CharacterClassType.Archer, i];
                _jobXpData[(byte)CharacterClassType.MartialArtist, i] = _jobXpData[(byte)CharacterClassType.Archer, i];
                _jobXpData[(byte)CharacterClassType.Swordman, i] = _jobXpData[(byte)CharacterClassType.Archer, i];
            }
        }
        public long GetJobExperience(CharacterClassType @class, byte level)
        {
            return (long)_jobXpData![(byte)@class, level - 1];
        }
    }
}