using GildedRose.Models;
using GildedRose.Respository;
using GildedRose.Rules;
using System;
using System.Collections.Generic;

namespace GildedRose
{
    class Program
    {
        static void Main(string[] args)
        {
            var items = Items.GetItems() as List<Item>;
            RunRules(items);
        }

        private static void RunRules(List<Item> items)
        {
            const int DaysToRun = 30;

            for (var i = 0; i < DaysToRun; i++)
            {
                Console.WriteLine("-------- day " + (i + 1) + " --------");
                Console.WriteLine("name, sellIn, quality");
                for (var j = 0; j < items.Count; j++)
                {
                    System.Console.WriteLine(items[j].Name + ", " + items[j].SellIn + ", " + items[j].Quality);
                }
                Console.WriteLine("");
                items.ForEach(item => ProcessRules.Process(item));
            }
        }
    }
}
