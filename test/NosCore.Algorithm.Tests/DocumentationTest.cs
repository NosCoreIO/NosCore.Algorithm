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
                    Assert.AreEqual(reput, reputationService.GetLevelFromReputation(result.Item1));
                    Assert.AreEqual(reput, reputationService.GetLevelFromReputation(result.Item2));
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
                Assert.AreEqual(dignity, dignityService.GetLevelFromDignity(result.Item1));
                Assert.AreEqual(dignity, dignityService.GetLevelFromDignity(result.Item2));
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
    }
}
