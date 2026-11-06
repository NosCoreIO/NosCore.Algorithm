//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------

using System;
using System.Linq;
using System.Text;
using ApprovalTests;
using ApprovalTests.Writers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.Tests
{
    [TestClass]
    public class DocumentationTest
    {
        [TestMethod]
        public void ExperienceDocumentation()
        {
            var experienceService = new ExperienceService.ExperienceService();

            var resultBuilder = new StringBuilder("# Experience Table");
            resultBuilder.AppendLine();

            for (byte level = 1; level < 100; level++)
            {
                resultBuilder.AppendLine(
                    $"- Level {level,2} - XP: {experienceService.GetExperience(level)}");
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void HeroExperienceDocumentation()
        {
            var heroExperienceService = new HeroExperienceService.HeroExperienceService();

            var resultBuilder = new StringBuilder("# Hero Experience Table");
            resultBuilder.AppendLine();

            for (byte level = 1; level < 61; level++)
            {
                resultBuilder.AppendLine(
                    $"- Level {level,2} - XP: {heroExperienceService.GetHeroExperience(level)}");
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void SpExperienceDocumentation()
        {
            var experienceService = new SpExperienceService.SpExperienceService();

            var resultBuilder = new StringBuilder("# SP Experience Table");


            for (var i = 0; i < 2; i++)
            {
                resultBuilder.AppendLine();
                resultBuilder.AppendLine($"## {(i == 0 ? "Primary" : "Secondary")} SP");
                for (byte level = 1; level < 100; level++)
                {
                    resultBuilder.AppendLine(
                        $"- Level {level,2} - XP: {experienceService.GetSpExperience(level, i == 1)}");
                }
            }
            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void FairyExperienceDocumentation()
        {
            var experienceService = new FairyExperienceService.FairyExperienceService();

            var resultBuilder = new StringBuilder("# Fairy Experience Table");
            resultBuilder.AppendLine();

            for (byte level = 0; level < 80; level++)
            {
                resultBuilder.AppendLine(
                    $"- {level,2}% -> {level + 1,2}% - XP: {experienceService.GetFairyExperience(level)}");
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }


        [TestMethod]
        public void HpDocumentation()
        {
            var experienceService = new HpService.HpService();

            var resultBuilder = new StringBuilder("# HP Table");

            foreach (var @class in Enum.GetValues(typeof(CharacterClassType)).Cast<CharacterClassType>())
            {
                resultBuilder.AppendLine();
                resultBuilder.AppendLine($"## Class {@class}");
                for (byte level = 1; level < 100; level++)
                {
                    resultBuilder.AppendLine(
                        $"- Level {level,2} - HP: {experienceService.GetHp(@class, level)}");
                }
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void MpDocumentation()
        {
            var experienceService = new MpService.MpService();

            var resultBuilder = new StringBuilder("# MP Table");

            foreach (var @class in Enum.GetValues(typeof(CharacterClassType)).Cast<CharacterClassType>())
            {
                resultBuilder.AppendLine();
                resultBuilder.AppendLine($"## Class {@class}");
                for (byte level = 1; level < 100; level++)
                {
                    resultBuilder.AppendLine(
                        $"- Level {level,2} - MP: {experienceService.GetMp(@class, level)}");
                }
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void DamageDocumentation()
        {
            var damageService = new DamageService.DamageService();

            var resultBuilder = new StringBuilder("# Damage Table");
            foreach (var @class in Enum.GetValues(typeof(CharacterClassType)).Cast<CharacterClassType>())
            {
                resultBuilder.AppendLine();
                resultBuilder.AppendLine($"## Class {@class}");
                for (byte level = 1; level < 100; level++)
                {
                    resultBuilder.AppendLine(
                        $"- Level {level,2} - Damage Min: {damageService.GetMinDamage(@class, level)} Damage Max: {damageService.GetMaxDamage(@class, level)}");
                }
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void ReputationDocumentation()
        {
            var reputationService = new ReputationService.ReputationService();

            var resultBuilder = new StringBuilder("# Reputation Table");
            resultBuilder.AppendLine();
            foreach (var reput in Enum.GetValues(typeof(ReputationType)).Cast<ReputationType>())
            {
                var result = reputationService.GetReputation(reput);
                resultBuilder.AppendLine($"- {(byte)reput,2} {reput.ToString().PadRight(16)} - Min: {result.Item1} Max: {result.Item2}");
                if (reput < ReputationType.GreenLegend)
                {
                    var actualFromMin = reputationService.GetLevelFromReputation(result.Item1);
                    var actualFromMax = reputationService.GetLevelFromReputation(result.Item2);
                    Assert.AreEqual(reput, actualFromMin);
                    Assert.AreEqual(reput, actualFromMax);
                }
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void DignityDocumentation()
        {
            var dignityService = new DignityService.DignityService();

            var resultBuilder = new StringBuilder("# Dignity Table");
            resultBuilder.AppendLine();
            foreach (var dignity in Enum.GetValues(typeof(DignityType)).Cast<DignityType>())
            {
                var result = dignityService.GetDignity(dignity);
                resultBuilder.AppendLine($"- {(byte)dignity,2} {dignity.ToString().PadRight(11)} - Max: {result.Item1} Min: {result.Item2}");
                var actualFromMax = dignityService.GetLevelFromDignity(result.Item1);
                var actualFromMin = dignityService.GetLevelFromDignity(result.Item2);
                Assert.AreEqual(dignity, actualFromMax);
                Assert.AreEqual(dignity, actualFromMin);
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void SecondaryDamageDocumentation()
        {
            var secondaryDamageService = new SecondaryDamageService.SecondaryDamageService();

            var resultBuilder = new StringBuilder("# Secondary Damage Table");
            foreach (var @class in Enum.GetValues(typeof(CharacterClassType)).Cast<CharacterClassType>())
            {
                resultBuilder.AppendLine();
                resultBuilder.AppendLine($"## Class {@class}");
                for (byte level = 1; level < 100; level++)
                {
                    resultBuilder.AppendLine(
                        $"- Level {level,2} - Secondary Damage Min: {secondaryDamageService.GetSecondaryMinDamage(@class, level)} Secondary Damage Max: {secondaryDamageService.GetSecondaryMaxDamage(@class, level)}");
                }
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void SpeedDocumentation()
        {
            var speedService = new SpeedService.SpeedService();

            var resultBuilder = new StringBuilder("# Speed Table");
            resultBuilder.AppendLine();
            foreach (var @class in Enum.GetValues(typeof(CharacterClassType)).Cast<CharacterClassType>())
            {
                resultBuilder.AppendLine($"- {@class} : {speedService.GetSpeed(@class)}");
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void HitRateDocumentation()
        {
            var hitRateService = new HitRateService.HitRateService();

            var resultBuilder = new StringBuilder("# HitRate Table");
            foreach (var @class in Enum.GetValues(typeof(CharacterClassType)).Cast<CharacterClassType>())
            {
                resultBuilder.AppendLine();
                resultBuilder.AppendLine($"## Class {@class}");
                for (byte level = 1; level < 100; level++)
                {
                    resultBuilder.AppendLine(
                        $"- Level {level,2} - HitRate: {hitRateService.GetHitRate(@class, level)}");
                }
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void SecondaryHitRateDocumentation()
        {
            var secondaryHitRateService = new SecondaryHitRateService.SecondaryHitRateService();

            var resultBuilder = new StringBuilder("# Secondary HitRate Table");
            foreach (var @class in Enum.GetValues(typeof(CharacterClassType)).Cast<CharacterClassType>())
            {
                resultBuilder.AppendLine();
                resultBuilder.AppendLine($"## Class {@class}");
                for (byte level = 1; level < 100; level++)
                {
                    resultBuilder.AppendLine(
                        $"- Level {level,2} - HitRate: {secondaryHitRateService.GetSecondaryHitRate(@class, level)}");
                }
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void JobExperienceDocumentation()
        {
            var jobExperienceService = new JobExperienceService.JobExperienceService();

            var resultBuilder = new StringBuilder("# Job Experience Table");
            foreach (var @class in Enum.GetValues(typeof(CharacterClassType)).Cast<CharacterClassType>())
            {
                resultBuilder.AppendLine();
                resultBuilder.AppendLine($"## Class {@class}");
                for (byte level = 1; level < (@class == CharacterClassType.Adventurer ? 21 : 81); level++)
                {
                    resultBuilder.AppendLine(
                        $"- Level {level,2} - XP: {jobExperienceService.GetJobExperience(@class, level)}");
                }
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void HitDodgeDocumentation()
        {
            var hitDodgeService = new HitDodgeService.HitDodgeService();

            var resultBuilder = new StringBuilder("# Hit Dodge Table");
            foreach (var @class in Enum.GetValues(typeof(CharacterClassType)).Cast<CharacterClassType>())
            {
                resultBuilder.AppendLine();
                resultBuilder.AppendLine($"## Class {@class}");
                for (byte level = 1; level < 100; level++)
                {
                    resultBuilder.AppendLine(
                        $"- Level {level,2} - Hit Dodge: {hitDodgeService.GetHitDodge(@class, level)}");
                }
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void DistanceDodgeDocumentation()
        {
            var distanceDodgeService = new DistanceDodgeService.DistanceDodgeService();

            var resultBuilder = new StringBuilder("# Distance Dodge Table");
            foreach (var @class in Enum.GetValues(typeof(CharacterClassType)).Cast<CharacterClassType>())
            {
                resultBuilder.AppendLine();
                resultBuilder.AppendLine($"## Class {@class}");
                for (byte level = 1; level < 100; level++)
                {
                    resultBuilder.AppendLine(
                        $"- Level {level,2} - Distance Dodge: {distanceDodgeService.GetDistanceDodge(@class, level)}");
                }
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void DistanceDefenceDocumentation()
        {
            var distanceDefenceService = new DistanceDefenceService.DistanceDefenceService();

            var resultBuilder = new StringBuilder("# Distance Defence Table");
            foreach (var @class in Enum.GetValues(typeof(CharacterClassType)).Cast<CharacterClassType>())
            {
                resultBuilder.AppendLine();
                resultBuilder.AppendLine($"## Class {@class}");
                for (byte level = 1; level < 100; level++)
                {
                    resultBuilder.AppendLine(
                        $"- Level {level,2} - Distance Defence: {distanceDefenceService.GetDistanceDefence(@class, level)}");
                }
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void MagicDefenceDocumentation()
        {
            var magicDefenceService = new MagicDefenceService.MagicDefenceService();

            var resultBuilder = new StringBuilder("# Magic Defence Table");
            foreach (var @class in Enum.GetValues(typeof(CharacterClassType)).Cast<CharacterClassType>())
            {
                resultBuilder.AppendLine();
                resultBuilder.AppendLine($"## Class {@class}");
                for (byte level = 1; level < 100; level++)
                {
                    resultBuilder.AppendLine(
                        $"- Level {level,2} - Magic Defence: {magicDefenceService.GetMagicDefence(@class, level)}");
                }
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void CloseDefenceDocumentation()
        {
            var closeDefenceService = new CloseDefenceService.CloseDefenceService();

            var resultBuilder = new StringBuilder("# Close Defence Table");
            foreach (var @class in Enum.GetValues(typeof(CharacterClassType)).Cast<CharacterClassType>())
            {
                resultBuilder.AppendLine();
                resultBuilder.AppendLine($"## Class {@class}");
                for (byte level = 1; level < 100; level++)
                {
                    resultBuilder.AppendLine(
                        $"- Level {level,2} - Close Defence: {closeDefenceService.GetCloseDefence(@class, level)}");
                }
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void SumDocumentation()
        {
            var sumService = new SumService.SumService();

            var resultBuilder = new StringBuilder($"# Sum Table");
            resultBuilder.AppendLine();
            for (byte i = 0; i < 6; i++)
            {
                resultBuilder.AppendLine(
                    $"- Sum {i + 1} - Rate: {sumService.GetSuccessRate(i)}% - Cost: {sumService.GetPrice(i)} - Sand: {sumService.GetSandCost(i)}");
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void SpUpgradeDocumentation()
        {
            var spUpgradeService = new SpUpgradeService.SpUpgradeService();

            var resultBuilder = new StringBuilder("# Specialist Card Upgrade Table");
            resultBuilder.AppendLine();
            for (byte upgrade = 0; upgrade < spUpgradeService.MaxUpgrade; upgrade++)
            {
                resultBuilder.AppendLine(
                    $"- +{upgrade} to +{upgrade + 1} - Success: {spUpgradeService.GetSuccessRate(upgrade)}% - Soul destroyed: {spUpgradeService.GetDestructionRate(upgrade)}% - Gold: {spUpgradeService.GetGoldCost(upgrade)} - Feathers: {spUpgradeService.GetFeatherCost(upgrade)} - Full moons: {spUpgradeService.GetFullMoonCost(upgrade)} - Souls: {spUpgradeService.GetSoulCost(upgrade)} - Dragon Gems: {spUpgradeService.GetDragonGemCost(upgrade)} - Dimensiolith Shards (other dimensions): {spUpgradeService.GetShardCost(upgrade)} - Job level: {spUpgradeService.GetMinimumJobLevel(upgrade)}");
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void EquipmentUpgradeDocumentation()
        {
            var equipmentUpgradeService = new EquipmentUpgradeService.EquipmentUpgradeService();

            var resultBuilder = new StringBuilder("# Equipment Upgrade Table");
            resultBuilder.AppendLine();
            for (byte upgrade = 0; upgrade < equipmentUpgradeService.MaxUpgrade; upgrade++)
            {
                resultBuilder.AppendLine(
                    $"- +{upgrade} to +{upgrade + 1} - Success: {equipmentUpgradeService.GetSuccessRate(upgrade)}% - Fixed: {equipmentUpgradeService.GetFixedRate(upgrade)}% - Failure: {equipmentUpgradeService.GetFailureRate(upgrade)}% - Gold: {equipmentUpgradeService.GetGoldCost(upgrade)} - Cella Powder: {equipmentUpgradeService.GetCellaCost(upgrade)} - {equipmentUpgradeService.GetGemType(upgrade)}: {equipmentUpgradeService.GetGemCost(upgrade)} - Dimensiolith Shards: {equipmentUpgradeService.GetShardCost(upgrade)} - Pity gauge per miss: {equipmentUpgradeService.GetPityGaugeGain(upgrade)}/{equipmentUpgradeService.PityGaugeMaximum}");
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void SpPerfectionDocumentation()
        {
            var spPerfectionService = new SpPerfectionService.SpPerfectionService();

            var resultBuilder = new StringBuilder("# Specialist Card Perfection Table");
            resultBuilder.AppendLine();
            for (byte perfection = 0; perfection < spPerfectionService.MaxPerfection; perfection++)
            {
                resultBuilder.AppendLine(
                    $"- {perfection} to {perfection + 1} - Success: {spPerfectionService.GetSuccessRate(perfection)}% - Gold: {spPerfectionService.GetGoldCost(perfection)} - Stones: {spPerfectionService.GetStoneCost(perfection)} - Gain: {spPerfectionService.GetMinimumGain(perfection)} to {spPerfectionService.GetMaximumGain(perfection)}");
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void CellonDocumentation()
        {
            var cellonService = new CellonService.CellonService();

            var resultBuilder = new StringBuilder("# Cellon Table");
            for (byte level = 1; level <= 10; level++)
            {
                resultBuilder.AppendLine();
                resultBuilder.AppendLine($"## Cellon {level} - Cost: {cellonService.GetPrice(level)}");
                foreach (var option in cellonService.GetOptions(level))
                {
                    resultBuilder.AppendLine($"- {option.Type}: {option.Minimum} - {option.Maximum}");
                }
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void NoCellonLevelHasNoOptions()
        {
            var cellonService = new CellonService.CellonService();

            Assert.AreEqual(0, cellonService.GetOptions(0).Count);
            Assert.AreEqual(0, cellonService.GetOptions(11).Count);
        }

        [TestMethod]
        public void ShellDocumentation()
        {
            var shellService = new ShellService.ShellService();

            var resultBuilder = new StringBuilder("# Shell Table");
            resultBuilder.AppendLine();
            resultBuilder.AppendLine("## Slots");
            foreach (var type in Enum.GetValues<ShellType>())
            {
                for (byte rarity = 1; rarity <= 7; rarity++)
                {
                    var slots = shellService.GetSlots(type, rarity).Select(s => s.Guaranteed ? $"{s.Level}" : $"{s.Level}?");
                    resultBuilder.AppendLine($"- {type} R{rarity}: {string.Join(" ", slots)}");
                }
            }

            for (byte level = 1; level <= 12; level++)
            {
                resultBuilder.AppendLine();
                resultBuilder.AppendLine($"## Option level {level}");
                foreach (var option in shellService.GetWeaponOptions(level))
                {
                    resultBuilder.AppendLine($"- Weapon {option.Type}: {option.Minimum} - {option.Maximum}");
                }

                foreach (var option in shellService.GetArmorOptions(level))
                {
                    resultBuilder.AppendLine($"- Armor {option.Type}: {option.Minimum} - {option.Maximum}");
                }
            }

            resultBuilder.AppendLine();
            resultBuilder.AppendLine("## Identification cost");
            for (byte level = 10; level <= 90; level += 10)
            {
                resultBuilder.AppendLine($"- Level {level,2}: {string.Join(" ", Enumerable.Range(1, 7).Select(r => shellService.GetIdentificationCost(level, (byte)r)))}");
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void ShellValueScalesWithLevelFromThirty()
        {
            var shellService = new ShellService.ShellService();

            Assert.AreEqual(25, shellService.GetValue(835, 30));
            Assert.AreEqual(25, shellService.GetValue(835, 10));
            Assert.AreEqual(50, shellService.GetValue(835, 60));
            Assert.AreEqual(1, shellService.GetValue(0, 60));
        }

        [TestMethod]
        public void NoShellRarityOrOptionLevelHasNothing()
        {
            var shellService = new ShellService.ShellService();

            Assert.AreEqual(0, shellService.GetSlots(ShellType.Full, 0).Count);
            Assert.AreEqual(0, shellService.GetSlots(ShellType.Full, 8).Count);
            Assert.AreEqual(0, shellService.GetWeaponOptions(13).Count);
            Assert.AreEqual(0, shellService.GetArmorOptions(0).Count);
        }

        [TestMethod]
        public void MateExperienceDocumentation()
        {
            var mateExperienceService = new MateExperienceService.MateExperienceService();

            var resultBuilder = new StringBuilder("# Mate Experience Table");
            resultBuilder.AppendLine();

            for (byte level = 1; level < 100; level++)
            {
                resultBuilder.AppendLine(
                    $"- Level {level,2} - Pet: {mateExperienceService.GetPetExperience(level)} - Partner: {mateExperienceService.GetPartnerExperience(level)}");
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void FamilyExperienceDocumentation()
        {
            var familyExperienceService = new FamilyExperienceService.FamilyExperienceService();

            var resultBuilder = new StringBuilder("# Family Experience Table");
            resultBuilder.AppendLine();

            for (byte level = 1; level <= 30; level++)
            {
                resultBuilder.AppendLine(
                    $"- Level {level,2} - XP: {familyExperienceService.GetFamilyExperience(level)}");
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void FamilyUpgradeDocumentation()
        {
            var familyUpgradeService = new FamilyUpgradeService.FamilyUpgradeService();

            var resultBuilder = new StringBuilder("# Family Upgrade Table");
            resultBuilder.AppendLine();

            for (byte level = 0; level <= 2; level++)
            {
                resultBuilder.AppendLine(
                    $"- Level {level} - Warehouse slots: {familyUpgradeService.GetWarehouseSize(level),2} Member limit: {familyUpgradeService.GetMemberLimit(level)}");
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void BankDocumentation()
        {
            var bankService = new BankService.BankService();

            var resultBuilder = new StringBuilder("# Bank Table");
            resultBuilder.AppendLine();
            foreach (var reputation in Enum.GetValues(typeof(ReputationType)).Cast<ReputationType>())
            {
                resultBuilder.AppendLine($"- {(byte)reputation,2} {reputation,-16} - Rank: {bankService.GetRank(reputation),-8} Withdrawal fee: {bankService.GetWithdrawalFee(reputation)}");
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void DignityShopPriceDocumentation()
        {
            var dignityService = new DignityService.DignityService();

            var resultBuilder = new StringBuilder("# Dignity Shop Price Table");
            resultBuilder.AppendLine();
            foreach (var dignity in Enum.GetValues(typeof(DignityType)).Cast<DignityType>())
            {
                resultBuilder.AppendLine($"- {dignity,-11} - Price: x{dignityService.GetShopPriceMultiplier(dignity)}");
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void LowLevelBoostDocumentation()
        {
            var lowLevelBoostService = new LowLevelBoostService.LowLevelBoostService();

            var resultBuilder = new StringBuilder("# Low Level Experience Boost Table");
            resultBuilder.AppendLine();
            for (byte level = 1; level <= 22; level++)
            {
                resultBuilder.AppendLine(
                    $"- Level {level,2} - XP: x{lowLevelBoostService.GetExperienceBoost(level)} Job XP: x{lowLevelBoostService.GetJobExperienceBoost(level)}");
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void ExperienceShareDocumentation()
        {
            var experienceShareService = new ExperienceShareService.ExperienceShareService();

            var resultBuilder = new StringBuilder("# Group Experience Share Table");
            resultBuilder.AppendLine();
            for (byte members = 1; members <= 3; members++)
            {
                resultBuilder.AppendLine(
                    $"- {members} member(s) - XP: {experienceShareService.GetExperienceShare(members):P2} Job XP: {experienceShareService.GetJobExperienceShare(members):P2}");
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void LevelPenaltyDocumentation()
        {
            var levelPenaltyService = new LevelPenaltyService.LevelPenaltyService();

            var resultBuilder = new StringBuilder("# Level Penalty Table");
            resultBuilder.AppendLine();
            for (var difference = -5; difference <= 35; difference++)
            {
                const byte playerLevel = 50;
                var monsterLevel = (byte)(playerLevel - difference);
                resultBuilder.AppendLine(
                    $"- Player {difference,3} level(s) above the monster - XP: x{levelPenaltyService.GetExperiencePenalty(playerLevel, monsterLevel)} Gold: x{levelPenaltyService.GetGoldPenalty(playerLevel, monsterLevel)}");
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void RarityPointDocumentation()
        {
            var rarityPointService = new RarityPointService.RarityPointService();

            var resultBuilder = new StringBuilder("# Rarity Point Table");
            for (sbyte rarity = -2; rarity <= 8; rarity++)
            {
                resultBuilder.AppendLine();
                resultBuilder.AppendLine($"## Rarity {rarity}");
                for (byte level = 0; level < 100; level += 5)
                {
                    resultBuilder.AppendLine($"- Item level {level,2}-{level + 4,2} - Points: {rarityPointService.GetRarityPoint(rarity, level)}");
                }
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void SpecialistPointDocumentation()
        {
            var specialistPointService = new SpecialistPointService.SpecialistPointService();

            var resultBuilder = new StringBuilder("# Specialist Point Table");
            resultBuilder.AppendLine();
            resultBuilder.AppendLine("## Points by level (+0)");
            for (byte level = 1; level < 100; level++)
            {
                resultBuilder.AppendLine($"- Level {level,2} - Points: {specialistPointService.GetSpecialistPoints(level, 0)}");
            }

            resultBuilder.AppendLine();
            resultBuilder.AppendLine("## Points at level 99 by upgrade");
            for (byte upgrade = 0; upgrade <= 20; upgrade++)
            {
                resultBuilder.AppendLine($"- +{upgrade,-2} - Points: {specialistPointService.GetSpecialistPoints(99, upgrade)} - Highest stat level: {specialistPointService.GetMaximumStatLevel(upgrade)}");
            }

            resultBuilder.AppendLine();
            resultBuilder.AppendLine("## Stat level by points spent");
            for (short points = 0; points <= 490; points += 5)
            {
                resultBuilder.AppendLine(
                    $"- {points,3} points - Attack: {specialistPointService.GetAttackLevel(points)} Defence: {specialistPointService.GetDefenceLevel(points)} Element: {specialistPointService.GetElementLevel(points)} HP/MP: {specialistPointService.GetHpMpLevel(points)}");
            }

            resultBuilder.AppendLine();
            resultBuilder.AppendLine("## Bonus by stat level");
            for (var level = 0; level <= 120; level++)
            {
                resultBuilder.AppendLine($"- Level {level,3}");
                resultBuilder.AppendLine($"  - Attack: {specialistPointService.GetAttackBonus(level)}");
                resultBuilder.AppendLine($"  - Defence: {specialistPointService.GetDefenceBonus(level)}");
                resultBuilder.AppendLine($"  - Element: {specialistPointService.GetElementBonus(level)}");
                resultBuilder.AppendLine($"  - HP/MP: {specialistPointService.GetHpMpBonus(level)}");
            }

            Assert.AreEqual(1000 + 20, specialistPointService.GetAttackBonus(100).Damage);
            Assert.AreEqual(550, specialistPointService.GetDefenceBonus(100).Defence);
            Assert.AreEqual(5, specialistPointService.GetDefenceBonus(100).DamageReduction);
            Assert.AreEqual(150 + 10, specialistPointService.GetElementBonus(100).ElementRate);
            Assert.AreEqual(150, specialistPointService.GetHpMpBonus(100).HpMpPercent);
            Assert.AreEqual(1350 + 40, specialistPointService.GetAttackBonus(120).Damage);
            Assert.AreEqual(810, specialistPointService.GetDefenceBonus(120).Defence);
            Assert.AreEqual(190 + 14, specialistPointService.GetElementBonus(120).ElementRate);
            Assert.AreEqual(190, specialistPointService.GetHpMpBonus(120).HpMpPercent);
            Assert.AreEqual(120, specialistPointService.GetAttackLevel(486));
            Assert.AreEqual(specialistPointService.GetAttackBonus(120), specialistPointService.GetAttackBonus(130));

            for (short points = 1; points <= 500; points++)
            {
                Assert.IsTrue(specialistPointService.GetAttackLevel(points) >= specialistPointService.GetAttackLevel((short)(points - 1)));
                Assert.IsTrue(specialistPointService.GetDefenceLevel(points) >= specialistPointService.GetDefenceLevel((short)(points - 1)));
                Assert.IsTrue(specialistPointService.GetElementLevel(points) >= specialistPointService.GetElementLevel((short)(points - 1)));
                Assert.IsTrue(specialistPointService.GetHpMpLevel(points) >= specialistPointService.GetHpMpLevel((short)(points - 1)));
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }
    }
}
