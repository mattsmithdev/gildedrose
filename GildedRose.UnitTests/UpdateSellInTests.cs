using GildedRose.Models;
using GildedRose.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.UnitTests
{
    [TestClass]
    public class UpdateSellInTests
    {
        [TestMethod]
        public void DayPasses_SellInGreaterThanZero_SellInGoesDownByOne()
        {
            var item = new Item { Name = "", Quality = 1, SellIn = 1 };
            ProcessRules.Process(item);
            Assert.AreEqual(0, item.SellIn);
        }

        [TestMethod]
        public void DayPasses_SellInLessThanZero_SellInGoesDownByOne()
        {
            var item = new Item { Name = "", Quality = 1, SellIn = -1 };
            ProcessRules.Process(item);
            Assert.AreEqual(-2, item.SellIn);
        }
    }
}
