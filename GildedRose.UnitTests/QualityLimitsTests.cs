using GildedRose.Models;
using GildedRose.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.UnitTests
{
    [TestClass]
    public class QualityLimitsTests
    {
        [TestMethod]
        public void DayPasses_QualityDoesntGoBelowMin()
        {
            var item = new Item { Name = "", Quality = Limits.MinQuality, SellIn = 1 };
            ProcessRules.Process(item);
            Assert.AreEqual(Limits.MinQuality, item.Quality);
        }

        [TestMethod]
        public void DayPasses_QualityDoesntGoAboveMax()
        {
            var item = new Item { Name = "", Quality = Limits.MaxQuality + 2, SellIn = 1 };
            ProcessRules.Process(item);
            Assert.AreEqual(Limits.MaxQuality, item.Quality);
        }
    }
}
