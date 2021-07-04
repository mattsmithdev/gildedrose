# GildedRose

## Overview

This is one of the multitudes of solutions for the GildedRose problem based on the included GildedRoseRequirements.txt file. This particular solution is a console app written in C# .Net Core 3.1.

## How To Run

To run the console app you'll need to clone the repository. Then using Visual Studio or any similar tool build the .Net Core 3.1 solution. Then run the exe in the debug or release folder. It should output 30 days of results based on the hard coded Items located in the Repository folder of the main project.

## Testing

The solution includes a unit test project. You can run the tests in your favorite .Net IDE or command line in the standard fashion. The test layout follows the same layout as the main project.

## The Whys

Obviously when you create something for production you wouldn't hardcode data or in some cases hardcode rules. As far as the rules go, you could look at using a Business Rules Engine (BRE).

I tried NRule with the GildedRose problem but found that the current flow of the requirements (generally a rule per item) didn't fit the philosophy of NRule. I couldn't have it cleanly just stop at first hit, but always run rule x. It really wasn't designed for that.

In the end I did a custom solution for this, but kept it in the Rules base layout. The focus behind the layout if for maintainability and the ability to easily add future item rules. It's an item first focus. So see if the current item matches any specific item rule then apply the generic rules if not. Based on the current requirements there is no heirarchy (parent/child) of items. I also left updating SellIn at the top level since only one item changes that, but that could be put into each Item class if the requirements change.

To add a new item rule, you would add a new class under the Rules/Items folder in the same format as the existing item rules. Then add that class call to the Rules/ProcessRules.cs class under the ProcessItems method. This is fine for the few sets of rules we have now, but will become harder to maintain if the requirements grow too much more or become much more complex.

For example, if we have a new requirement to add specify a rule for "Elixir of the Mongoose" such that "Elixir items degrade in Quality three as fast as normal items", we would create a new class under Rules/Items called `Elixir.cs`...

```c#
using GildedRose.Actions;
using GildedRose.Models;

namespace GildedRose.Rules.Items
{
    /*
     * Elixir items degrade in Quality three as fast as normal items
     */
    public static class Elixir
    {
        private const int QualityChange = -3;

        public static bool Process(Item item)
        {
            if (item.Name == ItemNames.Elixir)
            {
                Quality.UpdateQuality(item, QualityChange);
                return true;
            }
            return false;
        }
    }
}

```

...Then update our ProcessItems method under the Rules/ProcessRules.cs class...

```c#
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
            if (!itemRuleTriggered)
            {
                itemRuleTriggered = Elixir.Process(item);
            }
            return itemRuleTriggered;
        }
```



