using GildedRose.Models;

namespace GildedRose.Rules.Items
{
    /*
     * "Sulfuras", being a legendary item, never has to be sold or decreases in Quality
     */

    public static class Sulfuras
    {
        public static bool Process(Item item)
        {
            if (item.Name == ItemNames.Sulfuras)
            {
                item.SellIn++;
                return true;
            }
            return false;
        }
    }
}
