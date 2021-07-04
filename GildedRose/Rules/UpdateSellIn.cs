using GildedRose.Actions;
using GildedRose.Models;

namespace GildedRose.Rules
{
    public static class UpdateSellIn
    {
        public static bool Process(Item item)
        {
            SellIn.UpdateSellIn(item, -1);
            return true;
        }
    }
}
