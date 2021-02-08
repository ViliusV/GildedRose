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
			//ToDo - Ideas : Switch, ChangeQuality(item, changeBy) methods, write methods (E.g., change SellIn) 

			foreach (var item in Items)
			{
				// Step 1 - Update Quality
				//ToDo: avoid having || or &&
				if (item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert")
				{
					UpdateQuality(item, 1);

					if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
					{
						if (item.SellIn <= 5)
						{
							UpdateQuality(item, 2);	
						} 
						else if (item.SellIn <= 10)
						{
							UpdateQuality(item, 1);
						}
					}
				}
				else if (item.Name != "Sulfuras, Hand of Ragnaros")
				{
					UpdateQuality(item, -1);
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
						UpdateQuality(item, 1);	
					}
					// ToDo: Rewrite with If (==) Maybe this is not needed - item.Name != "Sulfuras, Hand of Ragnaros" - as its sellin does not decrease
					else if (item.Name != "Backstage passes to a TAFKAL80ETC concert" && item.Name != "Sulfuras, Hand of Ragnaros")
					{
						UpdateQuality(item, -1);
					}
					else
					{
						item.Quality = Constants.QualityMinimumValue;
					}
				}
			}
		}

		private void UpdateQuality(Item item, int changeBy) 
		{
			var newQuality = item.Quality + changeBy;
			newQuality = Math.Max(newQuality, Constants.QualityMinimumValue);	// Making sure new Quality value is >= minimum value
			newQuality = Math.Min(newQuality, Constants.QualityMaximumValue);	// Making sure new Quality value is <= maximum value

			item.Quality = newQuality;
		}
	}
}
