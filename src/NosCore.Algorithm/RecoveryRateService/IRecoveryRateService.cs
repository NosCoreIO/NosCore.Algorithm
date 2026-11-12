//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.RecoveryRateService
{
    /// <summary>
    /// HP and MP points a character recovers per regeneration tick
    /// </summary>
    public interface IRecoveryRateService
    {
        /// <summary>
        /// Gets the HP recovered per tick while sitting
        /// </summary>
        int GetRestingHpRate(CharacterClassType characterClass);

        /// <summary>
        /// Gets the MP recovered per tick while sitting
        /// </summary>
        int GetRestingMpRate(CharacterClassType characterClass);

        /// <summary>
        /// Gets the rate recovered per tick while standing, derived from the resting rate
        /// </summary>
        /// <param name="restingRate">The resting HP or MP rate</param>
        /// <param name="level">The character level</param>
        int GetStandingRate(int restingRate, byte level);
    }
}
