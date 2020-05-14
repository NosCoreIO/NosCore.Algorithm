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

            StringBuilder resultBuilder = new StringBuilder("# Experience Table");
            resultBuilder.AppendLine();

            for (byte level = 1; level < 100; level++)
            {
                resultBuilder.AppendLine(
                    $"- Level {level,2} - XP: {experienceService.GetExperience(level)}");
            }

            Approvals.Verify(WriterFactory.CreateTextWriter(resultBuilder.ToString(), "md"));
        }

        [TestMethod]
        public void SpExperienceDocumentation()
        {
            var experienceService = new SpExperienceService.SpExperienceService();

            StringBuilder resultBuilder = new StringBuilder("# SP Experience Table");
            

            for (int i = 0; i < 2; i++)
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
        public void HpDocumentation()
        {
            var experienceService = new HpService.HpService();

            StringBuilder resultBuilder = new StringBuilder("# HP Table");

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
        public void DamageDocumentation()
        {
            var damageService = new DamageService.DamageService();

            StringBuilder resultBuilder = new StringBuilder("# Damage Table");
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
        public void SecondaryDamageDocumentation()
        {
            var secondaryDamageService = new SecondaryDamageService.SecondaryDamageService();

            StringBuilder resultBuilder = new StringBuilder("# Secondary Damage Table");
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
        public void HitRateDocumentation()
        {
            var hitRateService = new HitRateService.HitRateService();

            StringBuilder resultBuilder = new StringBuilder("# HitRate Table");
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

            StringBuilder resultBuilder = new StringBuilder("# Secondary HitRate Table");
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
    }
}
