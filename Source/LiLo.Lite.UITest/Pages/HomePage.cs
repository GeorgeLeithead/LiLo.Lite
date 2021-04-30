// <copyright file="HomePage.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>

namespace LiLo.Lite.UITest.Pages
{
	using System;
	using NUnit.Framework;
	using Xamarin.UITest.Queries;
	using Query = System.Func<Xamarin.UITest.Queries.AppQuery, Xamarin.UITest.Queries.AppQuery>;

	/// <summary>Home Page Object.</summary>
	public class HomePage : BasePage
	{
		/// <summary>Arrange test for markets List.</summary>
		private readonly Query marketsList;

		/// <summary>Arrange test for market.</summary>
		private readonly Func<string, Query> market;

		/// <summary>Arrange test for page title.</summary>
		private readonly Func<string, Query> pageTitle;

		/// <summary>Arrange test for search symbol.</summary>
		private readonly Query searchSymbol;

		/// <summary>Arrange text for search text.</summary>
		private readonly Query searchSrcText;

		/// <summary>Initialises a new instance of the <see cref="HomePage"/> class.</summary>
		public HomePage()
		{
			this.marketsList = x => x.Marked("CollectionViewMarketsList").Child();
			this.market = marketName => marketsList => marketsList.Descendant().Marked(marketName);
			this.pageTitle = pageName => x => x.Marked("PageTitle").Text(pageName);
			this.searchSymbol = x => x.Marked("SearchBar");
			this.searchSrcText = x => x.Id("search_src_text");
		}

		/// <summary>Gets an action on a trait for the test.</summary>
		protected override PlatformQuery Trait => new PlatformQuery
		{
			Android = x => x.Marked("PageTitle").Text("Markets"),
			iOS = x => x.Marked("PageTitle").Text("Markets"),
		};

		/// <summary>Assert that the back button has been tapped.</summary>
		/// <returns>Application assertion.</returns>
		public HomePage TapBackButton()
		{
			this.App.Back();
			return this;
		}

		/// <summary>Assert the page title.</summary>
		/// <param name="pageTitle">Page title.</param>
		/// <returns>Application assertion.</returns>
		public HomePage ValidatePageTitle(string pageTitle = "Markets")
		{
			this.App.WaitForElement(this.pageTitle(pageTitle), $"Timed out waiting for page with the title '{pageTitle}'.");
			System.IO.File.Delete(@"C:\Dev\LiLo.Lite\Source\LiLo.Lite.UITest\screenshots\MarketsPageTitle.png");
			this.App.Screenshot("Markets Page Title").MoveTo(@"C:\Dev\LiLo.Lite\Source\LiLo.Lite.UITest\screenshots\MarketsPageTitle.png");
			return this;
		}

		/// <summary>Assert that the Markets List exists.</summary>
		/// <param name="marketsCount">Number of expected markets.</param>
		/// <returns>Application assertion.</returns>
		public HomePage VerifyMarketsList(int marketsCount = -1)
		{
			AppResult[] marketsListElement = this.App.WaitForElement(this.marketsList, "Timeout waiting for Markets list");
			this.App.Screenshot("Markets length").MoveTo(@"C:\Dev\LiLo.Lite\Source\LiLo.Lite.UITest\screenshots\MmarketsLength.png");
			if (marketsCount == -1)
			{
				if (marketsListElement.Length == 0)
				{
					this.App.Screenshot("Markets length fail").MoveTo(@"C:\Dev\LiLo.Lite\Source\LiLo.Lite.UITest\screenshots\marketsLengthFail.png");
					Assert.Fail("Markets list does not contain the expected number of markets");
				}
			}
			else
			{
				if (marketsListElement.Length != marketsCount)
				{
					this.App.Screenshot($"Markets length fail {marketsCount}").MoveTo(@"C:\Dev\LiLo.Lite\Source\LiLo.Lite.UITest\screenshots\MarketLengthsFailCount.png");
					Assert.Fail($"Markets list does not contain the expected number {marketsCount} of markets, actual {marketsListElement.Length}");
				}
			}

			return this;
		}

		/// <summary>Assert that the Search bar exists.</summary>
		/// <returns>Application assertion.</returns>
		public HomePage SearchBarExists()
		{
			AppResult[] searchBarElement = this.App.WaitForElement(this.searchSymbol, "Timeout waiting for search bar.");
			System.IO.File.Delete(@"C:\Dev\LiLo.Lite\Source\LiLo.Lite.UITest\screenshots\Searchbar.png");
			this.App.Screenshot("Search Bar").MoveTo(@"C:\Dev\LiLo.Lite\Source\LiLo.Lite.UITest\screenshots\Searchbar.png");
			if (searchBarElement.Length != 1)
			{
				Assert.Fail("Search bar not found.");
			}

			return this;
		}

		/// <summary>Assert using the search bar to search for a symbol.</summary>
		/// <param name="searchSymbol">Search symbol.</param>
		/// <returns>Application assertion.</returns>
		public HomePage SearchBarSearch(string searchSymbol)
		{
			AppResult[] searchBarElement = this.App.WaitForElement(this.searchSymbol, "Timeout waiting for search bar.");
			System.IO.File.Delete(@"C:\Dev\LiLo.Lite\Source\LiLo.Lite.UITest\screenshots\Searchbar.png");
			this.App.Screenshot("Search Bar").MoveTo(@"C:\Dev\LiLo.Lite\Source\LiLo.Lite.UITest\screenshots\Searchbar.png");
			AppResult searchBar = searchBarElement[0];
			this.App.EnterText(this.searchSrcText, searchSymbol);
			AppResult[] marketsListElement = this.App.WaitForElement(this.marketsList, "Timeout waiting for Markets list");
			if (marketsListElement.Length != 1)
			{
				Assert.Fail($"Search bar search for symbol {searchSymbol} not found.");
			}

			return this;
		}

		/// <summary>Assert tapping a symbol.</summary>
		/// <param name="symbol">market symbol.</param>
		/// <returns>Application assertion.</returns>
		public HomePage TapSymbol(string symbol)
		{
			AppResult[] selectedmarket = this.App.WaitForElement(this.market(symbol));
			if (selectedmarket.Length != 1)
			{
				this.App.Screenshot($"Market for currency '{symbol}' length fail");
				Assert.Fail($"Expected Market '{symbol}' does not exist in Markets List");
			}

			this.App.Tap(this.market(symbol));
			this.WaitForPageToLeave();
			System.IO.File.Delete($@"C:\Dev\LiLo.Lite\Source\LiLo.Lite.UITest\screenshots\TapSymbol{symbol}.png");
			this.App.Screenshot("Search Bar").MoveTo($@"C:\Dev\LiLo.Lite\Source\LiLo.Lite.UITest\screenshots\TapSymbol{symbol}.png");
			this.TapBackButton();
			return this;
		}
	}
}