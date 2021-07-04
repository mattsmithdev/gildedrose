using GildedRose.Models;
using GildedRose.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.UnitTests
{
    [TestClass]
    public class UpdateQualityTests
    {
        [TestMethod]
        public void DayPasses_SellByDateNotPassed_QualityGoesDownByOne()
        {
            var item = new Item { Name = "", Quality = 1, SellIn = 1 };
            ProcessRules.Process(item);
            Assert.AreEqual(0, item.Quality);
        }

        [TestMethod]
        public void DayPasses_SellByDatePassed_QualityGoesDownByTwo()
        {
            var item = new Item { Name = "", Quality = 2, SellIn = -1 };
            ProcessRules.Process(item);
            Assert.AreEqual(0, item.Quality);
        }
    }
}
