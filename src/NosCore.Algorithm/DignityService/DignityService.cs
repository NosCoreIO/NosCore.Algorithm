//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using NosCore.Algorithm.DignityService;
using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.DignityService
{
    public class DignityService : IDignityService
    {
        private readonly Dictionary<DignityType, short> _dignityData = new Dictionary<DignityType, short>();

        public DignityService()
        {
            _dignityData[DignityType.Default] = -99;
            _dignityData[DignityType.Dubious] = -200;
            _dignityData[DignityType.Dreadful] = -400;
            _dignityData[DignityType.Unqualified] = -600;
            _dignityData[DignityType.Useless] = -800;
            _dignityData[DignityType.Failed] = -1000;
        }

        public DignityType GetLevelFromDignity(short dignity)
        {
            foreach (var reput in Enum.GetValues(typeof(DignityType)).Cast<DignityType>())
            {
                if (_dignityData[reput] <= dignity)
                {
                    return reput;
                }
            }

            return DignityType.Failed;
        }

        public (short, short) GetDignity(DignityType level)
        {
            return (level == DignityType.Default ? (short)200 : (short)(_dignityData[level - 1] - 1), _dignityData[level]);
        }
    }
}
