using System;
using System.Collections.Generic;
using static csharpcore.Constants;

namespace csharpcore
{
	public class GildedRose
	{
		//ToDo - Idea to think about - class per item type with separate update methods (when we have more different types)
		//ToDo - Idea - merge different pattern matchings
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
					(ItemName.AgedBrie, <=0) => ChangeQuality(item.Quality, 2),
					(ItemName.AgedBrie, _) => ChangeQuality(item.Quality, 1),
					(ItemName.BackstagePasses, <=0) => Quality.MinimumValue,
					(ItemName.BackstagePasses, <= 5) => ChangeQuality(item.Quality, 3),
					(ItemName.BackstagePasses, <= 10) => ChangeQuality(item.Quality, 2),
					(ItemName.BackstagePasses, _) => ChangeQuality(item.Quality, 1),
					(ItemName.ConjuredManaCake, <= 0) => ChangeQuality(item.Quality, -4),
					(ItemName.ConjuredManaCake, _) => ChangeQuality(item.Quality, -2),
					(ItemName.Sulfuras, _) => item.Quality,
					(_, <= 0) => ChangeQuality(item.Quality, -2),
					(_, _) => ChangeQuality(item.Quality, -1)
				};

				// Step 2 - Reduce Sell In
				if (item.Name != ItemName.Sulfuras)
				{
					item.SellIn--;
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
