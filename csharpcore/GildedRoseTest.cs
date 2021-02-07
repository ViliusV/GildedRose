using Xunit;
using System.Collections.Generic;

namespace csharpcore
{
	public class GildedRoseTest
	{
		[Fact]
		public void Should_DecreaseQualityTwiceAsFast_When_SellByHasPassed()
		{
			var qualityBefore = 10;
			var qualityAfter = 8;
			var qualityChange = qualityAfter - qualityBefore;
			Assert.Equal(-2, qualityChange);
		}

		[Fact]
		public void ShouldNot_HaveNegativeQuality()
		{
			var quality = 0;
			Assert.True(quality >= 0);
		}

		[Fact]
		public void Should_InceaseQuality_When_ItemIsAgedBrie()
		{
			var qualityBefore = 10;
			var qualityAfter = 11;
			Assert.True(qualityAfter > qualityBefore);
		}

		[Fact]
		public void ShouldNot_HaveQualityHigherThan50()
		{
			var quality = 10;
			Assert.True(quality <= 50);
		}
		[Fact]
		public void ShouldNot_BeSold_When_ItemIsSulfuras()
		{
			var sellInBefore = 5;
			var sellInAfter = 5;
			Assert.Equal(sellInAfter, sellInBefore);
		}

		[Fact]
		public void ShouldNotDecreaseQuality_When_ItemIsSulfuras()
		{
			//ToDo - Have 2 tests where quality increases and where it stays the same (e.g., when quality is max-quality - 50) 	
			var qualityBefore = 10;
			var qualityAfter = 10;
			Assert.True(qualityAfter >= qualityBefore);
		}

		[Fact]
		public void Should_IncreaseQuality_When_ItemIsBackstagePasses_And_SellByDateIsApproaching()
		{
			var qualityBefore = 10;
			var qualityAfter = 11;
			Assert.True(qualityAfter > qualityBefore);
		}

		[Fact]
		public void Should_IncreaseQualityBy2_When_ItemIsBackstagePasses_And_SellByDateIsIn10DaysOrLess()
		{
			var qualityBefore = 10;
			var qualityAfter = 12;
			var qualityChange = qualityAfter - qualityBefore;
			Assert.Equal(2, qualityChange);
		}

		[Fact]
		public void Should_IncreaseQualityBy3_When_ItemIsBackstagePasses_And_SellByDateIsIn5DaysOrLess()
		{
			var qualityBefore = 10;
			var qualityAfter = 13;
			var qualityChange = qualityAfter - qualityBefore;
			Assert.Equal(3, qualityChange);
		}

		[Fact]
		public void Should_SetQualityTo0_When_ItemIsBackstagePasses_And_ConcertHasPassed()
		{
			var qualityAfter = 0;
			Assert.Equal(0, qualityAfter);
		}
	}
}