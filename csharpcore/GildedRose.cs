using System;
using System.Collections.Generic;

namespace csharpcore
{
	// ToDo - Make Static?
	public class GildedRose
	{
		IList<Item> Items;
		public GildedRose(IList<Item> Items)
		{
			this.Items = Items;
		}

		public void UpdateQuality()
		{
			//ToDo - reread requirements
			//ToDo - add Conjured items
			//ToDo - Ideas : Switch, use Math.Min(quality, 50), ChangeQuality(item, changeBy) methods, write methods (E.g., change SellIn) 

			foreach (var item in Items)
			{
				// Step 1 - Update Quality
				//ToDo: avoid having || or &&
				if (item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert")
				{
					item.Quality = Math.Min(item.Quality + 1, 50);

					if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
					{
						if (item.SellIn <= 5)
						{
							item.Quality = Math.Min(item.Quality + 2, 50);
						} 
						else if (item.SellIn <= 10)
						{
							item.Quality = Math.Min(item.Quality + 1, 50);
						}
					}
				}
				else if (item.Name != "Sulfuras, Hand of Ragnaros")
				{
					item.Quality = Math.Max(item.Quality - 1, 0);
				}
				


				// Step 2 - Reduce Sell In
				if (item.Name != "Sulfuras, Hand of Ragnaros")
				{
					item.SellIn--;
				}

				// Step 3 - Update quality for Items after Sell By date has passed
				if (item.SellIn < 0)
				{
					if (item.Name == "Aged Brie")
					{
						item.Quality = Math.Min(item.Quality + 1, 50);
					}
					// ToDo: Rewrite with If (==) Maybe this is not needed - item.Name != "Sulfuras, Hand of Ragnaros" - as its sellin does not decrease
					else if (item.Name != "Backstage passes to a TAFKAL80ETC concert" && item.Name != "Sulfuras, Hand of Ragnaros")
					{
						item.Quality = Math.Max(item.Quality - 1, 0);
					}
					else
					{
						item.Quality = 0;
					}
				}
			}
		}
	}
}
