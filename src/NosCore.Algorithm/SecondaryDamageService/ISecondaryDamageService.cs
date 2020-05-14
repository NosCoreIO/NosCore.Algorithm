//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.SecondaryDamageService
{
    public interface ISecondaryDamageService
    {
        long GetSecondaryMinDamage(CharacterClassType entityClass, byte level);
        long GetSecondaryMaxDamage(CharacterClassType entityClass, byte level);
    }
}
