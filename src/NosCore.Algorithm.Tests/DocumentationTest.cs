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
        public void HpDocumentation()
        {
            var experienceService = new HpService.HpService();

            StringBuilder resultBuilder = new StringBuilder("============ HP Table =============");
            resultBuilder.AppendLine();

            foreach (var @class in Enum.GetValues(typeof(CharacterClassType)).Cast<CharacterClassType>())
            {
                resultBuilder.AppendLine($"Class {@class}");
                for (byte level = 1; level < 100; level++)
                {
                    resultBuilder.AppendLine(
                        $"Level {level.ToString().PadRight(2)} - HP: {experienceService.GetHp((byte)@class, level)}");
                }
            }

            Approvals.Verify(resultBuilder);
        }
    }
}
