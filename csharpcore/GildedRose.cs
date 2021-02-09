using System;
using System.Collections.Generic;
using static csharpcore.Constants;

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

		public IList<Item> GetItems() => Items;

		public void UpdateQuality()
		{
			foreach (var item in Items)
			{
				// Step 1 - Change Quality
				item.Quality = (item.Name, item.SellIn) switch
				{
					(ItemName.AgedBrie, _) => ChangeQuality(item.Quality, 1),
					(ItemName.BackstagePasses, <= 5) => ChangeQuality(item.Quality, 3),
					(ItemName.BackstagePasses, <= 10) => ChangeQuality(item.Quality, 2),
					(ItemName.BackstagePasses, _) => ChangeQuality(item.Quality, 1),
					(ItemName.ConjuredManaCake, _) => ChangeQuality(item.Quality, -2),
					(ItemName.Sulfuras, _) => item.Quality,
					(_, _) => ChangeQuality(item.Quality, -1)
				};
				
				// Step 2 - Reduce Sell In
				if (item.Name != ItemName.Sulfuras)
				{
					item.SellIn--;

					// Step 3 - Change quality for Items after Sell By date has passed
					if (item.SellIn < 0)    
					{
						item.Quality = item.Name switch
						{
							ItemName.AgedBrie => ChangeQuality(item.Quality, 1), // Todo should it increase once more for Aged Brie?
							ItemName.ConjuredManaCake => ChangeQuality(item.Quality, -2),
							ItemName.BackstagePasses => Quality.MinimumValue,
							_ => ChangeQuality(item.Quality, -1)
						};
					}
				}
			}
		}

		private static int ChangeQuality(int quality, int changeBy) 
		{
			var newQuality = quality + changeBy;
			newQuality = Math.Max(newQuality, Quality.MinimumValue);	// Making sure new Quality value is >= minimum value
			newQuality = Math.Min(newQuality, Quality.MaximumValue);	// Making sure new Quality value is <= maximum value

			return newQuality;
		}
	}
}
