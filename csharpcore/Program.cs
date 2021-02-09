using System;
using System.Collections.Generic;
using static csharpcore.Constants;

namespace csharpcore
{
	public class Program
	{
		public static void Main(string[] args)
		{
			// ToDo: refactor this file too
			Console.WriteLine("OMGHAI!");

			IList<Item> Items = new List<Item>{
				new Item {Name = ItemName.DexterityVest, SellIn = 10, Quality = 20},
				new Item {Name = ItemName.AgedBrie, SellIn = 2, Quality = 0},
				new Item {Name = ItemName.MongooseElixir, SellIn = 5, Quality = 7},
				new Item {Name = ItemName.Sulfuras, SellIn = 0, Quality = 80},
				new Item {Name = ItemName.Sulfuras, SellIn = -1, Quality = 80},
				new Item
				{
					Name = ItemName.BackstagePasses,
					SellIn = 15,
					Quality = 20
				},
				new Item
				{
					Name = ItemName.BackstagePasses,
					SellIn = 10,
					Quality = 49
				},
				new Item
				{
					Name = ItemName.BackstagePasses,
					SellIn = 5,
					Quality = 49
				},
				// this conjured item does not work properly yet, //ToDo - add Conjured items
				new Item {Name = ItemName.ConjuredManaCake, SellIn = 3, Quality = 6}
			};

			var app = new GildedRose(Items);


			for (var i = 0; i < 31; i++)
			{
				Console.WriteLine("-------- day " + i + " --------");
				Console.WriteLine("name, sellIn, quality");
				for (var j = 0; j < Items.Count; j++)
				{
					System.Console.WriteLine(Items[j].Name + ", " + Items[j].SellIn + ", " + Items[j].Quality);
				}
				Console.WriteLine("");
				app.UpdateQuality();
			}
		}
	}
}
