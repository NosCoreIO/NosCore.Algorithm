﻿//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Shared.Enumerations;
using System;

namespace NosCore.Algorithm.JobExperienceService
{
    public class JobExperienceService : IJobExperienceService
    {
        private readonly long[,] _jobXpData = new long[Enum.GetNames(typeof(CharacterClassType)).Length, Constants.MaxJobLevel];

        public JobExperienceService()
        {
            _jobXpData[(byte)CharacterClassType.Adventurer, 0] = 2200;
            _jobXpData[(byte)CharacterClassType.Archer, 0] = 14500;
            _jobXpData[(byte)CharacterClassType.Mage, 0] = 14500;
            _jobXpData[(byte)CharacterClassType.MartialArtist, 0] = 14500;
            _jobXpData[(byte)CharacterClassType.Swordsman, 0] = 14500;

            for (var i = 1; i < Constants.MaxJobLevel; i++)
            {
                if (i < 20)
                {
                    _jobXpData[(byte)CharacterClassType.Adventurer, i] = _jobXpData[(byte)CharacterClassType.Adventurer, i - 1] + 700;
                }

                _jobXpData[(byte)CharacterClassType.Archer, i] = _jobXpData[(byte)CharacterClassType.Archer, i - 1] + (i > 39 ? 15000 : 4500);

                _jobXpData[(byte)CharacterClassType.Mage, i] = _jobXpData[(byte)CharacterClassType.Archer, i];
                _jobXpData[(byte)CharacterClassType.MartialArtist, i] = _jobXpData[(byte)CharacterClassType.Archer, i];
                _jobXpData[(byte)CharacterClassType.Swordsman, i] = _jobXpData[(byte)CharacterClassType.Archer, i];
            }
        }
        public long GetJobExperience(CharacterClassType @class, byte level)
        {
            return _jobXpData![(byte)@class, level - 1];
        }
    }
}