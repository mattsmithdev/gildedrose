using GildedRose.Models;
using GildedRose.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GildedRose.UnitTests.Rules.Items
{
    [TestClass]
    public class ConjuredTests
    {
        [TestMethod]
        public void DayPasses_Conjured_QualityGoesDownByTwo()
        {
            var item = new Item { Name = ItemNames.Conjured, Quality = 3, SellIn = 1 };
            ProcessRules.Process(item);
            Assert.AreEqual(1, item.Quality);
        }
    }
}
