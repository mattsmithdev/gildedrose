using GildedRose.Models;
using GildedRose.Rules;

namespace GildedRose.Actions
{
    public static class Quality
    {
        public static void UpdateQuality(Item item, int qualityChange)
        {
            item.Quality += qualityChange;
            QualityLimits.Process(item);
        }

        public static void SetQuality(Item item, int qualityValue)
        {
            item.Quality = qualityValue;
            QualityLimits.Process(item);
        }
    }
}
