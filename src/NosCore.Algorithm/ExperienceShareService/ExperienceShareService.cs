//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

namespace NosCore.Algorithm.ExperienceShareService
{
    /// <summary>
    /// Provides the experience split of a group
    /// </summary>
    /// <remarks>
    /// Each extra member adds 15% experience and 25% job experience to the kill, and the total
    /// is divided equally: 100%, 57.5% and 43.33% each for experience, 100%, 62.5% and 50% each
    /// for job experience.
    /// </remarks>
    public class ExperienceShareService : IExperienceShareService
    {
        private const double ExperienceBonusPerMember = 0.15;
        private const double JobExperienceBonusPerMember = 0.25;

        /// <inheritdoc />
        public double GetExperienceShare(byte memberCount) => Share(memberCount, ExperienceBonusPerMember);

        /// <inheritdoc />
        public double GetJobExperienceShare(byte memberCount) => Share(memberCount, JobExperienceBonusPerMember);

        private static double Share(byte memberCount, double bonusPerMember)
        {
            var members = memberCount switch
            {
                0 => 1,
                > Constants.MaxGroupSize => Constants.MaxGroupSize,
                _ => memberCount
            };
            return (1 + bonusPerMember * (members - 1)) / members;
        }
    }
}
