﻿using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
	public class GildedRoseTest
	{
		[Fact]
		public void Should_DecreaseQualityTwiceAsFast_When_SellByHasPassed()
		{
			var qualityBefore = 10;
			var items = new List<Item>
			{
				new Item
				{
					Name = "Dummy generic item",
					SellIn = 0,
					Quality = qualityBefore
				}
			};
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.Equal(-2, items[0].Quality - qualityBefore);
		}

		[Fact]
		public void ShouldNot_HaveNegativeQuality()
		{
			var items = new List<Item>
			{
				new Item
				{
					Name = "Dummy generic item",
					SellIn = 5,
					Quality = 0
				}
			};
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.True(items[0].Quality >= 0);
		}

		[Fact]
		public void Should_IncreaseQuality_When_ItemIsAgedBrie()
		{
			var qualityBefore = 10;
			var items = new List<Item>
			{
				new Item
				{
					Name = "Aged Brie",
					SellIn = 5,
					Quality = qualityBefore
				}
			};
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.True(items[0].Quality > qualityBefore);
		}

		[Fact]
		public void ShouldNot_HaveQualityHigherThan50()
		{
			var qualityBefore = 50; //ToDo - validate when creating objects if quality is in correct range
			var items = new List<Item>
			{
				new Item
				{
					Name = "Aged Brie",
					SellIn = 5,
					Quality = qualityBefore
				}
			};
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.True(items[0].Quality <= 50); // ToDo - Move 50, 0 to consts
		}
		[Fact]
		public void ShouldNot_BeSold_When_ItemIsSulfuras()
		{
			var sellInBefore = 5;
			var items = new List<Item>
			{
				new Item
				{
					Name = "Sulfuras, Hand of Ragnaros",
					SellIn = sellInBefore,
					Quality = 10
				}
			};
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.Equal(sellInBefore, items[0].SellIn);
		}

		[Fact]
		public void ShouldNotDecreaseQuality_When_ItemIsSulfuras()
		{
			var qualityBefore = 10;
			var items = new List<Item>
			{
				new Item
				{
					Name = "Sulfuras, Hand of Ragnaros",
					SellIn = 5,
					Quality = qualityBefore
				}
			};
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.True(items[0].Quality >= qualityBefore);
		}

		[Fact]
		public void Should_IncreaseQuality_When_ItemIsBackstagePasses_And_SellByDateIsApproaching()
		{
			var qualityBefore = 10;
			var items = new List<Item>
			{
				new Item
				{
					Name = "Backstage passes to a TAFKAL80ETC concert",
					SellIn = 15,
					Quality = qualityBefore
				}
			};
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.True(items[0].Quality > qualityBefore);
		}

		[Theory]
		[InlineData(10)]
		[InlineData(9)]
		[InlineData(8)]
		[InlineData(7)]
		[InlineData(6)]
		public void Should_IncreaseQualityBy2_When_ItemIsBackstagePasses_And_SellByDateIsIn10DaysOrLess(int sellIn)
		{
			var qualityBefore = 10;
			var items = new List<Item>
			{
				new Item
				{
					Name = "Backstage passes to a TAFKAL80ETC concert",
					SellIn = sellIn,
					Quality = qualityBefore
				}
			};
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.Equal(2, items[0].Quality - qualityBefore);
		}

		[Theory]
		[InlineData(5)]
		[InlineData(4)]
		[InlineData(3)]
		[InlineData(2)]
		[InlineData(1)]
		public void Should_IncreaseQualityBy3_When_ItemIsBackstagePasses_And_SellByDateIsIn5DaysOrLess(int sellIn)
		{
			var qualityBefore = 10;
			var items = new List<Item>
			{
				new Item
				{
					Name = "Backstage passes to a TAFKAL80ETC concert",
					SellIn = sellIn,
					Quality = qualityBefore
				}
			};
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.Equal(3, items[0].Quality - qualityBefore);
		}

		[Theory]
		[InlineData(0)]
		[InlineData(-1)]
		public void Should_SetQualityTo0_When_ItemIsBackstagePasses_And_ConcertHasPassed(int sellIn)
		{
			var items = new List<Item>
			{
				new Item
				{
					Name = "Backstage passes to a TAFKAL80ETC concert",
					SellIn = sellIn,
					Quality = 10
				}
			};
			var app = new GildedRose(items);

			app.UpdateQuality();

			Assert.Equal(0, items[0].Quality);
		}
	}
}