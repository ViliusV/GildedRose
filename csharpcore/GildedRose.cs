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
			//ToDo - Ideas : Switch, use Math.Min(quality, 50), ChangeQuality(item, changeBy) methods

			foreach (var item in Items)
			{
				// Step 1 - Update Quality
				if (item.Name == "Aged Brie" || item.Name == "Backstage passes to a TAFKAL80ETC concert")
				{
					if (item.Quality < 50)
					{
						item.Quality++;

						if (item.Name == "Backstage passes to a TAFKAL80ETC concert")
						{
							if (item.SellIn <= 10 && item.Quality < 50)
							{
								item.Quality++;
							}

							if (item.SellIn <= 5 && item.Quality < 50)
							{
								item.Quality++;
							}
						}
					}
				}
				else
				{
					if (item.Quality > 0 && item.Name != "Sulfuras, Hand of Ragnaros")
					{
						item.Quality--;
					}
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
						if (item.Quality < 50)
						{
							item.Quality++;
						}
					}
					else if (item.Name != "Backstage passes to a TAFKAL80ETC concert")
					{
						if (item.Quality > 0 && item.Name != "Sulfuras, Hand of Ragnaros")
						{
							item.Quality--;
						}
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
