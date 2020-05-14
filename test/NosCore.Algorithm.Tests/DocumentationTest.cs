using System;
using System.Linq;
using System.Text;
using ApprovalTests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NosCore.Packets.Enumerations;

namespace NosCore.Algorithm.Tests
{
    [TestClass]
    public class DocumentationTest
    {
        [TestMethod]
        public void ExperienceDocumentation()
        {
            var experienceService = new ExperienceService.ExperienceService();

            StringBuilder resultBuilder = new StringBuilder("============ Experience Table =============");
            resultBuilder.AppendLine();

            for (byte level = 1; level < 100; level++)
            {
                resultBuilder.AppendLine(
                    $"Level {level.ToString().PadRight(2)} - XP: {experienceService.GetExperience(level)}");
            }

            Approvals.Verify(resultBuilder);
        }

        [TestMethod]
        public void SpExperienceDocumentation()
        {
            var experienceService = new SpExperienceService.SpExperienceService();

            StringBuilder resultBuilder = new StringBuilder("============ SP Experience Table =============");
            

            for (int i = 0; i < 2; i++)
            {
                resultBuilder.AppendLine();
                resultBuilder.AppendLine($"-------------- {(i == 0 ? "Primary" : "Secondary")} SP --------------");
                for (byte level = 1; level < 100; level++)
                {
                    resultBuilder.AppendLine(
                        $"Level {level.ToString().PadRight(2)} - XP: {experienceService.GetSpExperience(level, i == 1)}");
                }
            }
            Approvals.Verify(resultBuilder);
        }

        [TestMethod]
        public void HpDocumentation()
        {
            var experienceService = new HpService.HpService();

            StringBuilder resultBuilder = new StringBuilder("============ HP Table =============");

            foreach (var @class in Enum.GetValues(typeof(CharacterClassType)).Cast<CharacterClassType>())
            {
                resultBuilder.AppendLine();
                resultBuilder.AppendLine($"-------------- Class {@class} --------------");
                for (byte level = 1; level < 100; level++)
                {
                    resultBuilder.AppendLine(
                        $"Level {level.ToString().PadRight(2)} - HP: {experienceService.GetHp((byte)@class, level)}");
                }
            }

            Approvals.Verify(resultBuilder);
        }

        [TestMethod]
        public void DamageDocumentation()
        {
            var damageService = new DamageService.DamageService();

            StringBuilder resultBuilder = new StringBuilder("============ Damage Table =============");
            foreach (var @class in Enum.GetValues(typeof(CharacterClassType)).Cast<CharacterClassType>())
            {
                resultBuilder.AppendLine();
                resultBuilder.AppendLine($"-------------- Class {@class} --------------");
                for (byte level = 1; level < 100; level++)
                {
                    resultBuilder.AppendLine(
                        $"Level {level.ToString().PadRight(2)} - Damage Min: {damageService.GetMinDamage((byte)@class, level)} Damage Max: {damageService.GetMaxDamage((byte)@class, level)}");
                }
            }

            Approvals.Verify(resultBuilder);
        }

        [TestMethod]
        public void HitRateDocumentation()
        {
            var hitRateService = new HitRateService.HitRateService();

            StringBuilder resultBuilder = new StringBuilder("============ HitRate Table =============");
            foreach (var @class in Enum.GetValues(typeof(CharacterClassType)).Cast<CharacterClassType>())
            {
                resultBuilder.AppendLine();
                resultBuilder.AppendLine($"-------------- Class {@class} --------------");
                for (byte level = 1; level < 100; level++)
                {
                    resultBuilder.AppendLine(
                        $"Level {level.ToString().PadRight(2)} - HitRate: {hitRateService.GetHitRate((byte)@class, level)}");
                }
            }

            Approvals.Verify(resultBuilder);
        }
    }
}
