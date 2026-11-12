//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;
using System.Collections.Generic;
using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.ShellService
{
    /// <summary>
    /// Provides what a shell rolls when it is identified and what identifying it costs
    /// </summary>
    public class ShellService : IShellService
    {
        internal static readonly ShellSlot[][][] Slots =
        {
            // Half
            new[]
            {
                Array.Empty<ShellSlot>(),
                new ShellSlot[] { new(1, true) },
                new ShellSlot[] { new(1, true), new(1, true) },
                new ShellSlot[] { new(1, true), new(2, true) },
                new ShellSlot[] { new(1, true), new(2, true), new(2, true) },
                new ShellSlot[] { new(1, true), new(2, true), new(3, true) },
                new ShellSlot[] { new(1, true), new(2, true), new(3, true), new(3, true) },
                new ShellSlot[] { new(1, true), new(1, true), new(2, true), new(2, true), new(3, true), new(3, true) },
            },
            // Full
            new[]
            {
                Array.Empty<ShellSlot>(),
                new ShellSlot[] { new(1, true) },
                new ShellSlot[] { new(1, true), new(1, true) },
                new ShellSlot[] { new(1, true), new(2, true) },
                new ShellSlot[] { new(1, true), new(2, true), new(2, true) },
                new ShellSlot[] { new(1, true), new(2, true), new(3, true) },
                new ShellSlot[] { new(1, true), new(2, true), new(3, true), new(3, true) },
                new ShellSlot[] { new(1, true), new(2, true), new(3, true), new(3, true), new(4, true) },
            },
            // Special
            new[]
            {
                Array.Empty<ShellSlot>(),
                new ShellSlot[] { new(1, true), new(5, true) },
                new ShellSlot[] { new(1, true), new(1, true), new(5, true) },
                new ShellSlot[] { new(1, true), new(2, true), new(6, true) },
                new ShellSlot[] { new(1, true), new(2, true), new(2, true), new(6, true) },
                new ShellSlot[] { new(1, true), new(2, true), new(3, true), new(7, true) },
                new ShellSlot[] { new(1, true), new(2, true), new(3, true), new(3, true), new(7, true) },
                new ShellSlot[] { new(1, true), new(2, true), new(3, true), new(3, true), new(4, true), new(7, true) },
            },
            // Pvp
            new[]
            {
                Array.Empty<ShellSlot>(),
                new ShellSlot[] { new(1, true), new(9, true) },
                new ShellSlot[] { new(1, true), new(1, true), new(9, true) },
                new ShellSlot[] { new(1, true), new(2, true), new(10, false) },
                new ShellSlot[] { new(1, true), new(2, true), new(2, true), new(10, false), new(10, false) },
                new ShellSlot[] { new(1, true), new(2, true), new(3, true), new(11, true), new(10, false) },
                new ShellSlot[] { new(1, true), new(2, true), new(3, true), new(3, true), new(11, true), new(11, true), new(10, false) },
                new ShellSlot[] { new(1, true), new(2, true), new(3, true), new(3, true), new(4, true), new(12, true), new(12, true), new(11, true), new(11, true), new(10, false) },
            },
            // Perfect
            new[]
            {
                Array.Empty<ShellSlot>(),
                new ShellSlot[] { new(1, true), new(5, false), new(9, false) },
                new ShellSlot[] { new(1, true), new(1, true), new(5, false), new(9, false) },
                new ShellSlot[] { new(1, true), new(1, true), new(2, true), new(6, false), new(10, false) },
                new ShellSlot[] { new(1, true), new(1, true), new(2, true), new(2, true), new(6, false), new(10, false), new(10, false) },
                new ShellSlot[] { new(1, true), new(1, true), new(2, true), new(2, true), new(3, true), new(7, false), new(11, false), new(10, false) },
                new ShellSlot[] { new(1, true), new(1, true), new(2, true), new(2, true), new(3, true), new(3, true), new(7, false), new(11, false), new(11, false), new(10, false) },
                new ShellSlot[] { new(1, true), new(1, true), new(2, true), new(2, true), new(3, true), new(3, true), new(4, true), new(7, false), new(12, false), new(12, false), new(11, false) },
            },
        };

        internal static readonly ShellOption<WeaponShellOptionType>[][] WeaponOptions =
        {
            Array.Empty<ShellOption<WeaponShellOptionType>>(),
            new ShellOption<WeaponShellOptionType>[] { new(WeaponShellOptionType.EnhancedDamage, 835, 1156), new(WeaponShellOptionType.MinorBleeding, 18, 52), new(WeaponShellOptionType.Blackout, 18, 52), new(WeaponShellOptionType.IncreasedDamageToPlants, 60, 104), new(WeaponShellOptionType.IncreasedDamageToAnimals, 60, 104), new(WeaponShellOptionType.IncreasedDamageToMonsters, 60, 104), new(WeaponShellOptionType.IncreasedCriticalChance, 30, 104), new(WeaponShellOptionType.IncreasedCriticalDamage, 342, 645), new(WeaponShellOptionType.UndisturbedWhenCasting, 0, 0), new(WeaponShellOptionType.ReducedMpConsumption, 70, 118) },
            new ShellOption<WeaponShellOptionType>[] { new(WeaponShellOptionType.EnhancedDamage, 1187, 1502), new(WeaponShellOptionType.Bleeding, 18, 52), new(WeaponShellOptionType.Freeze, 18, 52), new(WeaponShellOptionType.IncreasedDamageToPlants, 110, 204), new(WeaponShellOptionType.IncreasedDamageToAnimals, 110, 204), new(WeaponShellOptionType.IncreasedDamageToMonsters, 110, 204), new(WeaponShellOptionType.IncreasedDamageToUndead, 60, 104), new(WeaponShellOptionType.IncreasedDamageToSmallAnimals, 60, 104), new(WeaponShellOptionType.IncreasedFireElement, 482, 802), new(WeaponShellOptionType.IncreasedWaterElement, 482, 802), new(WeaponShellOptionType.IncreasedLightElement, 482, 802), new(WeaponShellOptionType.IncreasedShadowElement, 482, 802), new(WeaponShellOptionType.ReducedMpConsumption, 162, 232), new(WeaponShellOptionType.HpRecoveryPerKill, 1468, 1504), new(WeaponShellOptionType.MpRecoveryPerKill, 1468, 1504), new(WeaponShellOptionType.IncreasedSlDamage, 88, 123), new(WeaponShellOptionType.IncreasedSlDefence, 88, 123), new(WeaponShellOptionType.IncreasedSlElement, 88, 123), new(WeaponShellOptionType.IncreasedSlEnergy, 88, 123) },
            new ShellOption<WeaponShellOptionType>[] { new(WeaponShellOptionType.EnhancedDamage, 1468, 2101), new(WeaponShellOptionType.HeavyBleeding, 2, 18), new(WeaponShellOptionType.DeadlyBlackout, 18, 52), new(WeaponShellOptionType.IncreasedDamageToUndead, 110, 204), new(WeaponShellOptionType.IncreasedDamageToSmallAnimals, 110, 204), new(WeaponShellOptionType.IncreasedFireElement, 915, 1545), new(WeaponShellOptionType.IncreasedWaterElement, 915, 1545), new(WeaponShellOptionType.IncreasedLightElement, 915, 1545), new(WeaponShellOptionType.IncreasedShadowElement, 915, 1545), new(WeaponShellOptionType.HpRecoveryPerKill, 1961, 2004), new(WeaponShellOptionType.MpRecoveryPerKill, 1961, 2004), new(WeaponShellOptionType.IncreasedSlDamage, 130, 177), new(WeaponShellOptionType.IncreasedSlDefence, 130, 177), new(WeaponShellOptionType.IncreasedSlElement, 130, 177), new(WeaponShellOptionType.IncreasedSlEnergy, 130, 177) },
            new ShellOption<WeaponShellOptionType>[] { new(WeaponShellOptionType.IncreasedDamage, 88, 212), new(WeaponShellOptionType.IncreasedDamageToMapBosses, 229, 256), new(WeaponShellOptionType.IncreasedAllElements, 1187, 1778), new(WeaponShellOptionType.IncreasedSlAll, 88, 118) },
            new ShellOption<WeaponShellOptionType>[] { new(WeaponShellOptionType.IncreasedGold, 46, 102) },
            new ShellOption<WeaponShellOptionType>[] { new(WeaponShellOptionType.IncreasedGold, 130, 177), new(WeaponShellOptionType.IncreasedCombatExperience, 60, 104) },
            new ShellOption<WeaponShellOptionType>[] { new(WeaponShellOptionType.IncreasedGold, 224, 347), new(WeaponShellOptionType.IncreasedCombatExperience, 88, 156), new(WeaponShellOptionType.IncreasedJobExperience, 88, 156) },
            Array.Empty<ShellOption<WeaponShellOptionType>>(),
            new ShellOption<WeaponShellOptionType>[] { new(WeaponShellOptionType.PvpIncreasedDamage, 88, 118), new(WeaponShellOptionType.PvpReducedEnemyDefence, 88, 115), new(WeaponShellOptionType.PvpDamageAtFifteenPercent, 483, 602), new(WeaponShellOptionType.PvpDrainMp, 88, 190) },
            new ShellOption<WeaponShellOptionType>[] { new(WeaponShellOptionType.PvpIncreasedDamage, 39, 104), new(WeaponShellOptionType.PvpReducedEnemyDefence, 88, 152), new(WeaponShellOptionType.PvpReducedEnemyFireResistance, 18, 77), new(WeaponShellOptionType.PvpReducedEnemyWaterResistance, 18, 77), new(WeaponShellOptionType.PvpReducedEnemyLightResistance, 18, 77), new(WeaponShellOptionType.PvpReducedEnemyShadowResistance, 18, 77), new(WeaponShellOptionType.PvpDrainMp, 229, 304) },
            new ShellOption<WeaponShellOptionType>[] { new(WeaponShellOptionType.PvpIncreasedDamage, 88, 177), new(WeaponShellOptionType.PvpReducedEnemyDefence, 113, 204), new(WeaponShellOptionType.PvpReducedEnemyFireResistance, 60, 147), new(WeaponShellOptionType.PvpReducedEnemyWaterResistance, 60, 147), new(WeaponShellOptionType.PvpReducedEnemyLightResistance, 60, 147), new(WeaponShellOptionType.PvpReducedEnemyShadowResistance, 60, 147), new(WeaponShellOptionType.PvpDrainMp, 360, 502) },
            new ShellOption<WeaponShellOptionType>[] { new(WeaponShellOptionType.PvpIncreasedDamage, 187, 340), new(WeaponShellOptionType.PvpReducedEnemyDefence, 212, 347), new(WeaponShellOptionType.PvpReducedEnemyAllResistances, 88, 178) },
        };

        internal static readonly ShellOption<ArmorShellOptionType>[][] ArmorOptions =
        {
            Array.Empty<ShellOption<ArmorShellOptionType>>(),
            new ShellOption<ArmorShellOptionType>[] { new(ArmorShellOptionType.EnhancedMeleeDefence, 384, 690), new(ArmorShellOptionType.EnhancedRangedDefence, 384, 690), new(ArmorShellOptionType.EnhancedMagicDefence, 384, 690), new(ArmorShellOptionType.ReducedMinorBleeding, 187, 477), new(ArmorShellOptionType.ReducedBlackout, 187, 477), new(ArmorShellOptionType.ReducedBlind, 285, 502), new(ArmorShellOptionType.ReducedShock, 384, 602), new(ArmorShellOptionType.ReducedParalysis, 384, 602), new(ArmorShellOptionType.IncreasedHpRecoveryWhileResting, 384, 604), new(ArmorShellOptionType.IncreasedMpRecoveryWhileResting, 384, 604), new(ArmorShellOptionType.ReducedCriticalChanceReceived, 46, 102) },
            new ShellOption<ArmorShellOptionType>[] { new(ArmorShellOptionType.EnhancedMeleeDefence, 680, 1204), new(ArmorShellOptionType.EnhancedRangedDefence, 680, 1204), new(ArmorShellOptionType.EnhancedMagicDefence, 680, 1204), new(ArmorShellOptionType.ReducedBleeding, 187, 477), new(ArmorShellOptionType.ReducedAllBlackouts, 187, 404), new(ArmorShellOptionType.ReducedHandOfDeath, 285, 502), new(ArmorShellOptionType.ReducedFreeze, 187, 304), new(ArmorShellOptionType.ReducedBlind, 384, 602), new(ArmorShellOptionType.ReducedBind, 384, 602), new(ArmorShellOptionType.ReducedWeakenDefence, 384, 602), new(ArmorShellOptionType.IncreasedHpRecoveryWhileResting, 490, 1004), new(ArmorShellOptionType.IncreasedMpRecoveryWhileResting, 490, 1004), new(ArmorShellOptionType.ReducedCriticalChanceReceived, 110, 167), new(ArmorShellOptionType.IncreasedFireResistance, 60, 104), new(ArmorShellOptionType.IncreasedWaterResistance, 60, 104), new(ArmorShellOptionType.IncreasedLightResistance, 60, 104), new(ArmorShellOptionType.IncreasedShadowResistance, 60, 104) },
            new ShellOption<ArmorShellOptionType>[] { new(ArmorShellOptionType.EnhancedMeleeDefence, 1471, 2002), new(ArmorShellOptionType.EnhancedRangedDefence, 1471, 2002), new(ArmorShellOptionType.EnhancedMagicDefence, 1471, 2002), new(ArmorShellOptionType.ReducedAllBleeding, 187, 477), new(ArmorShellOptionType.ReducedAllBlackouts, 285, 504), new(ArmorShellOptionType.ReducedHandOfDeath, 384, 602), new(ArmorShellOptionType.ReducedFreeze, 360, 602), new(ArmorShellOptionType.IncreasedNaturalHpRecovery, 482, 1002), new(ArmorShellOptionType.IncreasedNaturalMpRecovery, 482, 1002), new(ArmorShellOptionType.IncreasedFireResistance, 88, 204), new(ArmorShellOptionType.IncreasedWaterResistance, 88, 204), new(ArmorShellOptionType.IncreasedLightResistance, 88, 204), new(ArmorShellOptionType.IncreasedShadowResistance, 88, 204) },
            new ShellOption<ArmorShellOptionType>[] { new(ArmorShellOptionType.IncreasedOverallDefence, 187, 256), new(ArmorShellOptionType.ReducedAllNegativeEffects, 285, 402), new(ArmorShellOptionType.RecoverDamageTakenAsHp, 384, 702), new(ArmorShellOptionType.IncreasedAllResistances, 201, 278) },
            new ShellOption<ArmorShellOptionType>[] { new(ArmorShellOptionType.ReducedDignityLoss, 510, 590), new(ArmorShellOptionType.ReducedProductionPointConsumption, 508, 577) },
            new ShellOption<ArmorShellOptionType>[] { new(ArmorShellOptionType.ReducedProductionPointConsumption, 471, 602), new(ArmorShellOptionType.IncreasedMinigameRewards, 490, 602), new(ArmorShellOptionType.IncreasedItemRecovery, 187, 290) },
            new ShellOption<ArmorShellOptionType>[] { new(ArmorShellOptionType.IncreasedMinigameRewards, 693, 904), new(ArmorShellOptionType.IncreasedItemRecovery, 482, 604) },
            Array.Empty<ShellOption<ArmorShellOptionType>>(),
            new ShellOption<ArmorShellOptionType>[] { new(ArmorShellOptionType.PvpIncreasedOverallDefence, 88, 118) },
            new ShellOption<ArmorShellOptionType>[] { new(ArmorShellOptionType.PvpDodgeMelee, 39, 78), new(ArmorShellOptionType.PvpDodgeRanged, 39, 78), new(ArmorShellOptionType.PvpDodgeMagic, 39, 78), new(ArmorShellOptionType.PvpIncreasedOverallDefence, 125, 177) },
            new ShellOption<ArmorShellOptionType>[] { new(ArmorShellOptionType.PvpIncreasedOverallDefence, 187, 252), new(ArmorShellOptionType.PvpDodgeMelee, 88, 145), new(ArmorShellOptionType.PvpDodgeRanged, 88, 145), new(ArmorShellOptionType.PvpDodgeMagic, 88, 145), new(ArmorShellOptionType.PvpProtectionAgainstManaDamage, 0, 0) },
            new ShellOption<ArmorShellOptionType>[] { new(ArmorShellOptionType.PvpIncreasedOverallDefence, 273, 404), new(ArmorShellOptionType.PvpDodgeAll, 130, 212) },
        };

        /// <inheritdoc />
        public IReadOnlyList<ShellSlot> GetSlots(ShellType type, byte rarity)
        {
            var byRarity = (int)type < Slots.Length ? Slots[(int)type] : Array.Empty<ShellSlot[]>();
            return rarity < byRarity.Length ? Array.AsReadOnly(byRarity[rarity]) : Array.Empty<ShellSlot>();
        }

        /// <inheritdoc />
        public IReadOnlyList<ShellOption<WeaponShellOptionType>> GetWeaponOptions(byte level)
        {
            return level <= Constants.MaxShellOptionLevel ? Array.AsReadOnly(WeaponOptions[level]) : Array.Empty<ShellOption<WeaponShellOptionType>>();
        }

        /// <inheritdoc />
        public IReadOnlyList<ShellOption<ArmorShellOptionType>> GetArmorOptions(byte level)
        {
            return level <= Constants.MaxShellOptionLevel ? Array.AsReadOnly(ArmorOptions[level]) : Array.Empty<ShellOption<ArmorShellOptionType>>();
        }

        /// <inheritdoc />
        public int GetValue(int perMille, byte shellLevel)
        {
            var level = Math.Max(shellLevel, Constants.MinShellValueLevel);
            return Math.Max(1, (int)Math.Round(perMille * level / 1000d));
        }

        /// <inheritdoc />
        public int GetIdentificationCost(byte shellLevel, byte rarity)
        {
            return shellLevel / 10 + rarity;
        }

        /// <inheritdoc />
        public int GetPerfumeCost(byte itemLevel, byte rarity, bool heroic)
        {
            if (heroic)
            {
                return itemLevel + HeroicPerfumePerRarity * rarity;
            }

            var bracket = Array.FindLastIndex(PerfumeLevels, l => l <= itemLevel);
            return bracket < 0 || rarity >= PerfumeByRarity[bracket].Length ? 0 : PerfumeByRarity[bracket][rarity];
        }

        /// <inheritdoc />
        public int GetPerfumeGoldCost(byte itemLevel)
        {
            var bracket = Array.FindLastIndex(PerfumeLevels, l => l <= itemLevel);
            return bracket < 0 ? 0 : PerfumeGold[bracket];
        }

        private const int HeroicPerfumePerRarity = 40;

        // The client's perfume window computes both costs itself. Each entry is the first item level
        // of a bracket; level 100 and above costs nothing, like level 0.
        private static readonly byte[] PerfumeLevels = { 1, 11, 21, 40, 50, 60, 70, 80, 90, 100 };

        private static readonly int[] PerfumeGold = { 1000, 2000, 5000, 8000, 10000, 12500, 15000, 17500, 20000, 0 };

        // By rarity 0 to 7; rarity 8 and above costs no perfume.
        private static readonly int[][] PerfumeByRarity =
        {
            new[] { 0, 0, 0, 0, 0, 0, 0, 0 },
            new[] { 0, 0, 0, 0, 0, 0, 0, 0 },
            new[] { 0, 0, 0, 0, 5, 5, 5, 10 },
            new[] { 0, 0, 0, 5, 5, 10, 20, 40 },
            new[] { 0, 0, 5, 10, 10, 20, 40, 80 },
            new[] { 0, 5, 10, 10, 20, 40, 80, 120 },
            new[] { 0, 10, 10, 20, 40, 80, 120, 160 },
            new[] { 0, 10, 20, 40, 80, 120, 160, 200 },
            new[] { 0, 20, 40, 80, 120, 160, 200, 300 },
            Array.Empty<int>(),
        };
    }
}
