using GildedRose.Actions;
using GildedRose.Models;

namespace GildedRose.Rules.Items
{
    /*
     * "Aged Brie" actually increases in Quality the older it gets
     */
    public static class AgedBrie
    {
        private const int QualityChange = 1;

        public static bool Process(Item item)
        {
            if (item.Name == ItemNames.AgedBrie)
            {
                Quality.UpdateQuality(item, QualityChange);
                return true;
            }
            return false;
        }
    }
}
