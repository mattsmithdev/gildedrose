using GildedRose.Models;
using GildedRose.Rules.Items;

namespace GildedRose.Rules
{
    public static class ProcessRules
    {
        public static void Process(Item item)
        {
            var itemRuleTriggered = ProcessItems(item);

            if (!itemRuleTriggered)
            {
                UpdateQuality.Process(item);
            }

            UpdateSellIn.Process(item);
        }

        private static bool ProcessItems(Item item)
        {
            var itemRuleTriggered = AgedBrie.Process(item);
            if (!itemRuleTriggered)
            {
                itemRuleTriggered = BackstagePass.Process(item);
            }
            if (!itemRuleTriggered)
            {
                itemRuleTriggered = Sulfuras.Process(item);
            }
            if (!itemRuleTriggered)
            {
                itemRuleTriggered = Conjured.Process(item);
            }
            return itemRuleTriggered;
        }
    }
}
