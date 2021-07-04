using GildedRose.Models;
using GildedRose.Respository;
using GildedRose.Rules;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Text.Json;

namespace GildedRose.UnitTests
{
    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ThirtyDaysPass_ItemsShouldBeUpdatedProperly()
        {
            const int DaysToRun = 30;
            var items = Items.GetItems() as List<Item>;

            for (var i = 0; i < DaysToRun; i++)
            {
                items.ForEach(item => ProcessRules.Process(item));
            }

            Assert.AreEqual(
                JsonSerializer.Serialize(Get30DayItems()),
                JsonSerializer.Serialize(items));
        }

        private static List<Item> Get30DayItems()
        {
            return new List<Item>{
                        new Item {Name = "+5 Dexterity Vest", SellIn = -20, Quality = 0},
                        new Item {Name = "Aged Brie", SellIn = -28, Quality = 30},
                        new Item {Name = "Elixir of the Mongoose", SellIn = -25, Quality = 0},
                        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80},
                        new Item {Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80},
                        new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = -15,
                            Quality = 0
                        },
                        new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = -20,
                            Quality = 0
                        },
                        new Item
                        {
                            Name = "Backstage passes to a TAFKAL80ETC concert",
                            SellIn = -25,
                            Quality = 0
                        },
            // this conjured item does not work properly yet
            new Item {Name = "Conjured Mana Cake", SellIn = -27, Quality = 0}
                    };
        }
    }
}
