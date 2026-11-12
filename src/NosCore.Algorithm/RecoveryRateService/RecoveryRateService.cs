//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System.Collections.Generic;
using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.RecoveryRateService
{
    /// <inheritdoc />
    public class RecoveryRateService : IRecoveryRateService
    {
        private static readonly Dictionary<CharacterClassType, (int Hp, int Mp)> RestingRates = new()
        {
            [CharacterClassType.Adventurer] = (30, 10),
            [CharacterClassType.Swordsman] = (80, 30),
            [CharacterClassType.Archer] = (60, 50),
            [CharacterClassType.Mage] = (30, 80),
            [CharacterClassType.MartialArtist] = (70, 40),
        };

        /// <inheritdoc />
        public int GetRestingHpRate(CharacterClassType characterClass) => RestingRates[characterClass].Hp;

        /// <inheritdoc />
        public int GetRestingMpRate(CharacterClassType characterClass) => RestingRates[characterClass].Mp;

        /// <inheritdoc />
        /// <remarks>
        /// The factor is one half up to level 20 and steps down in bands after it. Multiply before
        /// dividing, or the band is lost to integer truncation.
        /// </remarks>
        public int GetStandingRate(int restingRate, byte level)
        {
            var percent = level <= 20 ? 50
                : level <= 40 ? 40
                : level <= 60 ? 30
                : 20;
            return restingRate * percent / 100;
        }
    }
}
