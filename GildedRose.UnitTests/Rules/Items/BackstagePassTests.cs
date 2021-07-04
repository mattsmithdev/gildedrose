using GildedRose.Models;
using GildedRose.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.UnitTests.Rules.Items
{
    [TestClass]
    public class BackstagePassTests
    {
        [TestMethod]
        public void DayPasses_BackstagePass_SellInIsLessThanZero_QualityGoesToZero()
        {
            var item = new Item { Name = ItemNames.BackstagePass, Quality = 20, SellIn = -1 };
            ProcessRules.Process(item);
            Assert.AreEqual(0, item.Quality);
        }

        [TestMethod]
        public void DayPasses_BackstagePass_SellInIsOneToFiveDays_QualityGoesUpByThree()
        {
            var item = new Item { Name = ItemNames.BackstagePass, Quality = 20, SellIn = 1 };
            ProcessRules.Process(item);
            Assert.AreEqual(23, item.Quality);
        }

        [TestMethod]
        public void DayPasses_BackstagePass_SellInIsSixToTenDays_QualityGoesUpByTwo()
        {
            var item = new Item { Name = ItemNames.BackstagePass, Quality = 20, SellIn = 6 };
            ProcessRules.Process(item);
            Assert.AreEqual(22, item.Quality);
        }

        [TestMethod]
        public void DayPasses_BackstagePass_SellInIsGreateThanTenDays_QualityGoesUpByOne()
        {
            var item = new Item { Name = ItemNames.BackstagePass, Quality = 20, SellIn = 11 };
            ProcessRules.Process(item);
            Assert.AreEqual(21, item.Quality);
        }

        [TestMethod]
        public void DayPasses_BackstagePass_QualityDoesntGoAboveMax()
        {
            var item = new Item { Name = ItemNames.BackstagePass, Quality = Limits.MaxQuality, SellIn = 1 };
            ProcessRules.Process(item);
            Assert.AreEqual(Limits.MaxQuality, item.Quality);
        }

        [TestMethod]
        public void DayPasses_AgedBrie_SellInGoesDownByOne()
        {
            var item = new Item { Name = ItemNames.AgedBrie, Quality = 1, SellIn = 1 };
            ProcessRules.Process(item);
            Assert.AreEqual(0, item.SellIn);
        }
    }
}
