using GildedRose.Models;
using GildedRose.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.UnitTests.Rules.Items
{
    [TestClass]
    public class SulfurasTests
    {
        [TestMethod]
        public void DayPasses_Sulfuras_QualityAboveZero_QualityDoesntChange()
        {
            var item = new Item { Name = ItemNames.Sulfuras, Quality = 1, SellIn = 1 };
            ProcessRules.Process(item);
            Assert.AreEqual(1, item.Quality);
        }

        [TestMethod]
        public void DayPasses_Sulfuras_SellInDoesntChange()
        {
            var item = new Item { Name = ItemNames.Sulfuras, Quality = 1, SellIn = 1 };
            ProcessRules.Process(item);
            Assert.AreEqual(1, item.SellIn);
        }
    }
}
