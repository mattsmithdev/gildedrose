using GildedRose.Models;
using GildedRose.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.UnitTests.Rules.Items
{
    [TestClass]
    public class AgedBrieTests
    {
        [TestMethod]
        public void DayPasses_AgedBrie_QualityGoesUpByOne()
        {
            var item = new Item { Name = ItemNames.AgedBrie, Quality = 0, SellIn = 1 };
            ProcessRules.Process(item);
            Assert.AreEqual(1, item.Quality);
        }

        [TestMethod]
        public void DayPasses_AgedBrie_QualityDoesntGoAboveMax()
        {
            var item = new Item { Name = ItemNames.AgedBrie, Quality = Limits.MaxQuality, SellIn = 1 };
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
