//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.SpecialistPointService
{
    /// <summary>
    /// Service for the skill points of a specialist card and the stats they buy
    /// </summary>
    public interface ISpecialistPointService
    {
        /// <summary>
        /// Gets the skill points a specialist card has to spend
        /// </summary>
        /// <param name="specialistLevel">The card's level</param>
        /// <param name="upgrade">The card's upgrade (+0 to +15)</param>
        /// <returns>The points available</returns>
        int GetSpecialistPoints(byte specialistLevel, byte upgrade);

        /// <summary>
        /// Gets the attack level bought with the points spent on attack
        /// </summary>
        /// <param name="points">The points spent</param>
        /// <returns>The attack level</returns>
        int GetAttackLevel(short points);

        /// <summary>
        /// Gets the defence level bought with the points spent on defence
        /// </summary>
        /// <param name="points">The points spent</param>
        /// <returns>The defence level</returns>
        int GetDefenceLevel(short points);

        /// <summary>
        /// Gets the element level bought with the points spent on element
        /// </summary>
        /// <param name="points">The points spent</param>
        /// <returns>The element level</returns>
        int GetElementLevel(short points);

        /// <summary>
        /// Gets the HP/MP level bought with the points spent on HP/MP
        /// </summary>
        /// <param name="points">The points spent</param>
        /// <returns>The HP/MP level</returns>
        int GetHpMpLevel(short points);
    }
}
