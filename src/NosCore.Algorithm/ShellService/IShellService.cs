//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System.Collections.Generic;
using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.ShellService
{
    /// <summary>
    /// Service for retrieving what a shell rolls when it is identified and what identifying it costs
    /// </summary>
    public interface IShellService
    {
        /// <summary>
        /// Gets the options a shell of a specific kind and rarity rolls, in roll order
        /// </summary>
        /// <param name="type">The shell kind</param>
        /// <param name="rarity">The shell rarity</param>
        /// <returns>The slots, or an empty list for a rarity no shell has</returns>
        IReadOnlyList<ShellSlot> GetSlots(ShellType type, byte rarity);

        /// <summary>
        /// Gets the options a weapon shell can roll at an option level
        /// </summary>
        /// <param name="level">The option level, 1 to 12</param>
        /// <returns>The options, or an empty list for a level no option has</returns>
        IReadOnlyList<ShellOption<WeaponShellOptionType>> GetWeaponOptions(byte level);

        /// <summary>
        /// Gets the options an armour shell can roll at an option level
        /// </summary>
        /// <param name="level">The option level, 1 to 12</param>
        /// <returns>The options, or an empty list for a level no option has</returns>
        IReadOnlyList<ShellOption<ArmorShellOptionType>> GetArmorOptions(byte level);

        /// <summary>
        /// Gets the value of an option from the per-mille it rolled
        /// </summary>
        /// <param name="perMille">The per-mille of the shell level the option rolled</param>
        /// <param name="shellLevel">The shell level</param>
        /// <returns>The option value, at least 1</returns>
        int GetValue(int perMille, byte shellLevel);

        /// <summary>
        /// Gets how many Rainbow Pearls identifying a shell costs
        /// </summary>
        /// <param name="shellLevel">The shell level</param>
        /// <param name="rarity">The shell rarity</param>
        /// <returns>The pearl count</returns>
        int GetIdentificationCost(byte shellLevel, byte rarity);
    }
}
