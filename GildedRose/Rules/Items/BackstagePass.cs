using GildedRose.Actions;
using GildedRose.Models;

namespace GildedRose.Rules.Items
{
    /*
     * "Backstage passes", like aged brie, increases in Quality as its SellIn value approaches;
	Quality increases by 2 when there are 10 days or less and by 3 when there are 5 days or less but
	Quality drops to 0 after the concert
    */

    public static class BackstagePass
    {
        public static bool Process(Item item)
        {
            if (item.Name == ItemNames.BackstagePass)
            {
                if (item.SellIn < 0)
                {
                    Quality.SetQuality(item, 0);
                    return true;
                }

                if (item.SellIn <= 5)
                {
                    Quality.UpdateQuality(item, 3);
                    return true;
                }

                if (item.SellIn <= 10)
                {
                    Quality.UpdateQuality(item, 2);
                    return true;
                }

                Quality.UpdateQuality(item, 1);
                return true;
            }
            return false;
        }
    }
}
