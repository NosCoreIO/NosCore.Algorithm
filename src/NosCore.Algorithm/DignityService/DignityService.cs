//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.DignityService
{
    /// <summary>
    /// Provides dignity level and threshold calculations
    /// </summary>
    public class DignityService : IDignityService
    {
        private readonly Dictionary<DignityType, short> _dignityData = new Dictionary<DignityType, short>();

        /// <summary>
        /// Initializes a new instance of the DignityService and sets up dignity thresholds for each dignity type
        /// </summary>
        public DignityService()
        {
            _dignityData[DignityType.Default] = -99;
            _dignityData[DignityType.Dubious] = -200;
            _dignityData[DignityType.Dreadful] = -400;
            _dignityData[DignityType.Unqualified] = -600;
            _dignityData[DignityType.Useless] = -800;
            _dignityData[DignityType.Failed] = -1000;
        }

        /// <summary>
        /// Gets the dignity level type based on a dignity value
        /// </summary>
        /// <param name="dignity">The dignity value</param>
        /// <returns>The dignity level type</returns>
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

        /// <summary>
        /// Gets the dignity value range for a specific dignity level
        /// </summary>
        /// <param name="level">The dignity level type</param>
        /// <returns>A tuple containing the maximum and minimum dignity values for the level</returns>
        public (short, short) GetDignity(DignityType level)
        {
            return (level == DignityType.Default ? (short)200 : (short)(_dignityData[level - 1] - 1), _dignityData[level]);
        }
    }
}
