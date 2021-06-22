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
		private readonly Query alertDialog;

		/// <summary>Arrange test for market.</summary>
		private readonly Func<string, Query> market;

		/// <summary>Arrange test for markets List.</summary>
		private readonly Query marketsList;

		/// <summary>Arrange test for page title.</summary>
		private readonly Func<string, Query> pageTitle;

		/// <summary>Arrange text for search text.</summary>
		private readonly Query searchSrcText;

		/// <summary>Arrange test for search symbol.</summary>
		private readonly Query searchSymbol;

		/// <summary>Initialises a new instance of the <see cref="HomePage"/> class.</summary>
		public HomePage()
		{
			this.marketsList = x => x.Marked("CollectionViewMarketsList").Child();
			this.market = marketName => marketsList => marketsList.Descendant().Marked(marketName);
			this.pageTitle = pageName => x => x.Marked("PageTitle").Text(pageName);
			this.searchSymbol = x => x.Marked("SearchBar");
			this.searchSrcText = x => x.Id("search_src_text");
			this.alertDialog = x => x.Class("AlertDialogLayout");
		}

		/// <summary>Gets an action on a trait for the test.</summary>
		protected override PlatformQuery Trait => new PlatformQuery
		{
			Android = x => x.Marked("PageTitle").Text("Markets"),
			iOS = x => x.Marked("PageTitle").Text("Markets"),
		};

		/// <summary>Assert pressing the back button to leave the app.</summary>
		/// <param name="pageTitle">Page title.</param>
		/// <param name="cancel">Cancel leave app.</param>
		/// <returns>Application assertion.</returns>
		public HomePage LeaveApp(string pageTitle, bool cancel = false)
		{
			_ = this.App.WaitForElement(this.pageTitle(pageTitle), $"Timed out waiting for page with the title '{pageTitle}'.");
			_ = this.TapBackButton();
			_ = this.App.WaitForElement(this.alertDialog, $"Time out waiting for alert dialogue.");
			return this;
		}

		/// <summary>Assert that the Search bar exists.</summary>
		/// <returns>Application assertion.</returns>
		public HomePage SearchBarExists()
		{
			AppResult[] searchBarElement = this.App.WaitForElement(this.searchSymbol, "Timeout waiting for search bar.");
			System.IO.File.Delete(@".\LiLo.Lite.UITest\Screenshots\Searchbar.png");
			this.App.Screenshot("Search Bar").MoveTo(@".\LiLo.Lite.UITest\Screenshots\Searchbar.png");
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
			System.IO.File.Delete(@".\LiLo.Lite.UITest\Screenshots\Searchbar.png");
			this.App.Screenshot("Search Bar").MoveTo(@".\LiLo.Lite.UITest\Screenshots\Searchbar.png");
			AppResult searchBar = searchBarElement[0];
			this.App.EnterText(this.searchSrcText, searchSymbol);
			AppResult[] marketsListElement = this.App.WaitForElement(this.marketsList, "Timeout waiting for Markets list");
			if (marketsListElement.Length != 1)
			{
				Assert.Fail($"Search bar search for symbol {searchSymbol} not found.");
			}

			return this;
		}

		/// <summary>Assert that the back button has been tapped.</summary>
		/// <returns>Application assertion.</returns>
		public HomePage TapBackButton()
		{
			this.App.Back();
			return this;
		}

		/// <summary>Assert tapping settings icon.</summary>
		/// <returns>Application assertion.</returns>
		public HomePage TapSettings()
		{
			AppResult[] marketsListElement = this.App.WaitForElement(this.marketsList, "Timeout waiting for Markets list");
			if (marketsListElement.Length == 0)
			{
				System.IO.File.Delete(@".\LiLo.Lite.UITest\Screenshots\marketsLengthFail.png");
				this.App.Screenshot("Markets length fail").MoveTo(@".\LiLo.Lite.UITest\Screenshots\marketsLengthFail.png");
				Assert.Fail("Markets list does not contain the expected number of markets");
			}
			else
			{
				this.App.Tap(x => x.Marked("TitleBarSettings").Index(0));
				this.WaitForPageToLeave();
				System.IO.File.Delete(@".\LiLo.Lite.UITest\Screenshots\HomeTapSettings.png");
				this.App.Screenshot("Tap Settings").MoveTo(@".\LiLo.Lite.UITest\Screenshots\HomeTapSettings.png");
				_ = this.TapBackButton();
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
				_ = this.App.Screenshot($"Market for currency '{symbol}' length fail");
				Assert.Fail($"Expected Market '{symbol}' does not exist in Markets List");
			}

			this.App.Tap(this.market(symbol));
			this.WaitForPageToLeave();
			System.IO.File.Delete($@".\LiLo.Lite.UITest\Screenshots\TapSymbol{symbol}.png");
			this.App.Screenshot($"Tap Symbol {symbol}").MoveTo($@".\LiLo.Lite.UITest\Screenshots\TapSymbol{symbol}.png");
			_ = this.TapBackButton();
			return this;
		}

		/// <summary>Assert the page title.</summary>
		/// <param name="pageTitle">Page title.</param>
		/// <returns>Application assertion.</returns>
		public HomePage ValidatePageTitle(string pageTitle = "Markets")
		{
			_ = this.App.WaitForElement(this.pageTitle(pageTitle), $"Timed out waiting for page with the title '{pageTitle}'.");
			System.IO.File.Delete(@".\LiLo.Lite.UITest\Screenshots\MarketsPageTitle.png");
			this.App.Screenshot("Markets Page Title").MoveTo(@".\LiLo.Lite.UITest\Screenshots\MarketsPageTitle.png");
			return this;
		}

		/// <summary>Assert that the Markets List exists.</summary>
		/// <param name="marketsCount">Number of expected markets.</param>
		/// <returns>Application assertion.</returns>
		public HomePage VerifyMarketsList(int marketsCount = -1)
		{
			AppResult[] marketsListElement = this.App.WaitForElement(this.marketsList, "Timeout waiting for Markets list");
			System.IO.File.Delete(@".\LiLo.Lite.UITest\Screenshots\MmarketsLength.png");
			this.App.Screenshot("Markets length").MoveTo(@".\LiLo.Lite.UITest\Screenshots\MmarketsLength.png");
			if (marketsCount == -1)
			{
				if (marketsListElement.Length == 0)
				{
					System.IO.File.Delete(@".\LiLo.Lite.UITest\Screenshots\marketsLengthFail.png");
					this.App.Screenshot("Markets length fail").MoveTo(@".\LiLo.Lite.UITest\Screenshots\marketsLengthFail.png");
					Assert.Fail("Markets list does not contain the expected number of markets");
				}
			}
			else
			{
				if (marketsListElement.Length != marketsCount)
				{
					System.IO.File.Delete(@".\LiLo.Lite.UITest\Screenshots\MarketLengthsFailCount.png");
					this.App.Screenshot($"Markets length fail {marketsCount}").MoveTo(@".\LiLo.Lite.UITest\Screenshots\MarketLengthsFailCount.png");
					Assert.Fail($"Markets list does not contain the expected number {marketsCount} of markets, actual {marketsListElement.Length}");
				}
			}

			return this;
		}
	}
}