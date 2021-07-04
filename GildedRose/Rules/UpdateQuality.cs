using GildedRose.Actions;
using GildedRose.Models;

namespace GildedRose.Rules
{
    public static class UpdateQuality
    {
        public static bool Process(Item item)
        {
            if (item.SellIn < 0)
            {
                Quality.UpdateQuality(item, -2);
            }
            else
            {
                Quality.UpdateQuality(item, -1);
            }

            return true;
        }
    }
}
