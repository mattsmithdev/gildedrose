using GildedRose.Models;

namespace GildedRose.Actions
{
    public static class SellIn
    {
        public static void UpdateSellIn(Item item, int sellInChange)
        {
            item.SellIn += sellInChange;
        }
    }
}
