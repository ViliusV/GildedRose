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
			//ToDo - add Conjured items
			foreach (var item in Items)
			{
				// Step 1 - Change Quality
				item.Quality = (item.Name, item.SellIn) switch
				{
					("Aged Brie", _) => ChangeQuality(item.Quality, 1),
					("Backstage passes to a TAFKAL80ETC concert", <= 5) => ChangeQuality(item.Quality, 3),
					("Backstage passes to a TAFKAL80ETC concert", <= 10) => ChangeQuality(item.Quality, 2),
					("Backstage passes to a TAFKAL80ETC concert", _) => ChangeQuality(item.Quality, 1),
					("Sulfuras, Hand of Ragnaros", _) => item.Quality,
					(_, _) => ChangeQuality(item.Quality, -1)
				};
				
				// Step 2 - Reduce Sell In
				if (item.Name != "Sulfuras, Hand of Ragnaros")
				{
					item.SellIn--;

					// Step 3 - Change quality for Items after Sell By date has passed
					if (item.SellIn < 0)    
					{
						item.Quality = item.Name switch
						{
							"Aged Brie" => ChangeQuality(item.Quality, 1),
							"Backstage passes to a TAFKAL80ETC concert" => Constants.QualityMinimumValue,
							_ => ChangeQuality(item.Quality, -1)
						};
					}
				}
			}
		}

		private static int ChangeQuality(int quality, int changeBy) 
		{
			var newQuality = quality + changeBy;
			newQuality = Math.Max(newQuality, Constants.QualityMinimumValue);	// Making sure new Quality value is >= minimum value
			newQuality = Math.Min(newQuality, Constants.QualityMaximumValue);	// Making sure new Quality value is <= maximum value

			return newQuality;
		}
	}
}
