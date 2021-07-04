using GildedRose.Actions;
using GildedRose.Models;

namespace GildedRose.Rules.Items
{
    /*
     * "Conjured" items degrade in Quality twice as fast as normal items
     */
    public static class Conjured
    {
        private const int QualityChange = -2;

        public static bool Process(Item item)
        {
            if (item.Name == ItemNames.Conjured)
            {
                Quality.UpdateQuality(item, QualityChange);
                return true;
            }
            return false;
        }
    }
}
