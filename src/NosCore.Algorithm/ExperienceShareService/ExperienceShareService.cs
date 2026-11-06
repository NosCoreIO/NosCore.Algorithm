//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;

namespace NosCore.Algorithm.ExperienceShareService
{
    /// <summary>
    /// Provides the experience split of a group
    /// </summary>
    /// <remarks>
    /// Every member who shares the kill receives the same fraction of the monster's experience
    /// and job experience: 100% alone, 75% each in a group of two and 70% each in a group of three.
    /// </remarks>
    public class ExperienceShareService : IExperienceShareService
    {
        private static readonly double[] Share = [1, 1, 0.75, 0.7];

        /// <inheritdoc />
        public double GetExperienceShare(byte memberCount) => Share[Members(memberCount)];

        /// <inheritdoc />
        public double GetJobExperienceShare(byte memberCount) => Share[Members(memberCount)];

        private static int Members(byte memberCount) => Math.Min(memberCount, Constants.MaxGroupSize);
    }
}
