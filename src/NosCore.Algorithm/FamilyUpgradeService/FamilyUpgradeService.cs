//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;

namespace NosCore.Algorithm.FamilyUpgradeService
{
    /// <summary>
    /// Provides the capacities that family upgrades unlock
    /// </summary>
    public class FamilyUpgradeService : IFamilyUpgradeService
    {
        private static readonly byte[] WarehouseSizes = [0, 21, 49];

        private static readonly byte[] MemberLimits = [50, 70, 100];

        /// <inheritdoc />
        public byte GetWarehouseSize(byte level)
        {
            return WarehouseSizes[Math.Min(level, Constants.MaxFamilyUpgradeLevel)];
        }

        /// <inheritdoc />
        public byte GetMemberLimit(byte level)
        {
            return MemberLimits[Math.Min(level, Constants.MaxFamilyUpgradeLevel)];
        }
    }
}
