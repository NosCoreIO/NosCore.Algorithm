//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;

namespace NosCore.Algorithm.MateHpService
{
    internal static class MateLevel
    {
        // A mate's growth factor makes it gain one extra level every 10 / factor levels.
        internal static int Effective(byte level, int factor, int bonus)
        {
            if (factor == 0)
            {
                return level;
            }

            return level + (int)Math.Floor(((level - 1) / (10.0 / factor)) + bonus);
        }
    }
}
