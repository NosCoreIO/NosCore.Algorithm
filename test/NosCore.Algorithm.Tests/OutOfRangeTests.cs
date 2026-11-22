//  __  _  __    __   ___ __  ___ ___
// |  \| |/__\ /' _/ / _//__\| _ \ __|
// | | ' | \/ |`._`.| \_| \/ | v / _|
// |_|\__|\__/ |___/ \__/\__/|_|_\___|
// -----------------------------------
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NosCore.Algorithm.DignityService;
using NosCore.Algorithm.MateExperienceService;
using NosCore.Algorithm.MonsterStatService;
using NosCore.Algorithm.PartnerSkillRankService;
using NosCore.Algorithm.ReputationService;
using NosCore.Algorithm.ShellService;
using NosCore.Algorithm.SpecialistPointService;
using NosCore.Algorithm.SumService;
using NosCore.Shared.Enumerations;

namespace NosCore.Algorithm.Tests
{
    [TestClass]
    public class OutOfRangeTests
    {
        [TestMethod]
        public void ReputationAboveEveryRankIsTheTopRank()
        {
            Assert.AreEqual(ReputationType.RedElite, new ReputationService.ReputationService().GetLevelFromReputation(long.MaxValue));
        }

        [TestMethod]
        public void DignityBelowEveryRankIsTheBottomRank()
        {
            Assert.AreEqual(DignityType.Failed, new DignityService.DignityService().GetLevelFromDignity(short.MinValue));
        }

        [TestMethod]
        [DataRow(DignityType.Default, 1.5)]
        [DataRow(DignityType.Dreadful, 1.6)]
        [DataRow(DignityType.Unqualified, 1.7)]
        [DataRow(DignityType.Useless, 2.0)]
        [DataRow(DignityType.Failed, 2.0)]
        public void GlacernonShopsChargeMore(DignityType level, double multiplier)
        {
            var dignity = new DignityService.DignityService();

            Assert.AreEqual(multiplier, dignity.GetShopPriceMultiplier(level, true));
            Assert.AreEqual(dignity.GetShopPriceMultiplier(level), dignity.GetShopPriceMultiplier(level, false));
        }

        [TestMethod]
        public void DignityLossIsCappedAtFifty()
        {
            var dignity = new DignityService.DignityService();

            Assert.AreEqual(30, dignity.GetDignityLoss(30));
            Assert.AreEqual(50, dignity.GetDignityLoss(99));
        }

        [TestMethod]
        public void MonsterCriticalsAreFixed()
        {
            var monsterStat = new MonsterStatService.MonsterStatService(new MateHpService.MateHpService(), new MateMpService.MateMpService());

            Assert.AreEqual(4, monsterStat.GetCriticalChance());
            Assert.AreEqual(70, monsterStat.GetCriticalRate());
        }

        [TestMethod]
        public void SumLevelsStopAtFive()
        {
            ISumService sum = new SumService.SumService();

            Assert.AreEqual(5, sum.MaxLevel);
        }

        [TestMethod]
        public void PartnerSkillRanksOutsideTheTableWeighNothing()
        {
            var ranks = new PartnerSkillRankService.PartnerSkillRankService();

            Assert.AreEqual(0, ranks.GetWeight(0));
            Assert.AreEqual(0, ranks.GetWeight((byte)(ranks.MaxRank + 1)));
            Assert.AreNotEqual(0, ranks.GetWeight(ranks.MaxRank));
        }

        [TestMethod]
        public void SpecialistUpgradesPastTheTableKeepTheLastBonus()
        {
            var points = new SpecialistPointService.SpecialistPointService();

            Assert.AreEqual(points.GetSpecialistPoints(20, 20), points.GetSpecialistPoints(20, 255));
        }

        [TestMethod]
        public void ShellsOutsideTheTablesHaveNoSlotsOrOptions()
        {
            var shells = new ShellService.ShellService();

            Assert.AreEqual(0, shells.GetSlots(ShellType.Full, 255).Count);
            Assert.AreEqual(0, shells.GetSlots((ShellType)255, 0).Count);
            Assert.AreEqual(0, shells.GetWeaponOptions(13).Count);
            Assert.AreEqual(0, shells.GetArmorOptions(13).Count);
        }

        [TestMethod]
        public void MateLevelsPastTheTableKeepTheLastRow()
        {
            var mates = new MateExperienceService.MateExperienceService();

            Assert.AreEqual(mates.GetPetExperience(1), mates.GetPetExperience(0));
            Assert.AreEqual(mates.GetPartnerExperience(254), mates.GetPartnerExperience(255));
        }
    }
}
