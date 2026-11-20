//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;

namespace NosCore.Algorithm.TimeSpacePenaltyService
{
    /// <summary>
    /// Provides the points lost for finishing a time-space above its minimum level
    /// </summary>
    public class TimeSpacePenaltyService : ITimeSpacePenaltyService
    {
        /// <inheritdoc />
        public byte GetPointPenalty(byte level, byte levelMinimum)
        {
            return (byte)Math.Clamp((level - levelMinimum) * Constants.TimeSpacePenaltyPerLevel, 0, Constants.MaxTimeSpacePenalty);
        }
    }
}
