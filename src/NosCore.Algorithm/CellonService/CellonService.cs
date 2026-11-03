//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;
using System.Collections.Generic;
using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.CellonService
{
    /// <summary>
    /// Provides the options a cellon can add to an accessory and what applying it costs
    /// </summary>
    public class CellonService : ICellonService
    {
        internal static readonly long[] Price =
            { 0, 700, 1400, 3000, 5000, 10000, 20000, 32000, 58000, 95000, 134900 };

        internal static readonly CellonOption[][] Options =
        {
            Array.Empty<CellonOption>(),
            new CellonOption[] { new(CellonType.Hp, 30, 100), new(CellonType.Mp, 50, 120), new(CellonType.HpRecovery, 5, 10), new(CellonType.MpRecovery, 8, 15) },
            new CellonOption[] { new(CellonType.Hp, 120, 200), new(CellonType.Mp, 150, 250), new(CellonType.HpRecovery, 14, 20), new(CellonType.MpRecovery, 16, 25) },
            new CellonOption[] { new(CellonType.Hp, 220, 300), new(CellonType.Mp, 280, 330), new(CellonType.HpRecovery, 22, 28), new(CellonType.MpRecovery, 28, 35) },
            new CellonOption[] { new(CellonType.Hp, 330, 400), new(CellonType.Mp, 350, 420), new(CellonType.HpRecovery, 30, 38), new(CellonType.MpRecovery, 38, 45) },
            new CellonOption[] { new(CellonType.Hp, 430, 550), new(CellonType.Mp, 450, 550), new(CellonType.HpRecovery, 40, 50), new(CellonType.MpRecovery, 50, 60) },
            new CellonOption[] { new(CellonType.Hp, 600, 750), new(CellonType.Mp, 600, 750), new(CellonType.HpRecovery, 55, 70), new(CellonType.MpRecovery, 65, 80), new(CellonType.MpConsumption, 1, 7), new(CellonType.CriticalDamageDecrease, 1, 10) },
            new CellonOption[] { new(CellonType.Hp, 800, 1000), new(CellonType.Mp, 800, 1000), new(CellonType.HpRecovery, 75, 90), new(CellonType.MpRecovery, 75, 90), new(CellonType.MpConsumption, 8, 12), new(CellonType.CriticalDamageDecrease, 11, 20) },
            new CellonOption[] { new(CellonType.Hp, 1000, 1300), new(CellonType.Mp, 1000, 1300), new(CellonType.HpRecovery, 100, 120), new(CellonType.MpRecovery, 100, 120), new(CellonType.MpConsumption, 13, 17), new(CellonType.CriticalDamageDecrease, 21, 35) },
            new CellonOption[] { new(CellonType.Hp, 1100, 1500), new(CellonType.Mp, 1100, 1500), new(CellonType.HpRecovery, 110, 135), new(CellonType.MpRecovery, 110, 135), new(CellonType.MpConsumption, 14, 21), new(CellonType.CriticalDamageDecrease, 22, 45) },
            new CellonOption[] { new(CellonType.Hp, 1200, 1700), new(CellonType.Mp, 1200, 1700), new(CellonType.HpRecovery, 120, 150), new(CellonType.MpRecovery, 120, 150), new(CellonType.MpConsumption, 15, 25), new(CellonType.CriticalDamageDecrease, 23, 55) },
        };

        /// <summary>
        /// Gets the options a cellon of a specific level can roll
        /// </summary>
        /// <param name="level">The cellon level</param>
        /// <returns>The options, or an empty list for a level no cellon has</returns>
        public IReadOnlyList<CellonOption> GetOptions(byte level)
        {
            return level <= Constants.MaxCellonLevel ? Options[level] : Array.Empty<CellonOption>();
        }

        /// <summary>
        /// Gets the gold cost of applying a cellon of a specific level
        /// </summary>
        /// <param name="level">The cellon level</param>
        /// <returns>The gold cost</returns>
        public long GetPrice(byte level)
        {
            return Price[level];
        }
    }
}
