using GildedRose.Models;

namespace GildedRose.Rules
{
    /*
     * The Quality of an item is never negative
     * The Quality of an item is never more than 50
     */

    public static class QualityLimits
    {
        public static void Process(Item item)
        {
            if (item.Quality < 0)
            {
                item.Quality = 0;
            }

            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
        }
    }
}
