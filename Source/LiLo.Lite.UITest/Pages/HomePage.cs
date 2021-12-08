// <copyright file="HomePage.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
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
			marketsList = x => x.Marked("CollectionViewMarketsList").Child();
			market = marketName => marketsList => marketsList.Descendant().Marked(marketName);
			pageTitle = pageName => x => x.Marked("PageTitle").Text(pageName);
			searchSymbol = x => x.Marked("SearchBar");
			searchSrcText = x => x.Id("search_src_text");
			alertDialog = x => x.Class("AlertDialogLayout");
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
			_ = App.WaitForElement(this.pageTitle(pageTitle), $"Timed out waiting for page with the title '{pageTitle}'.");
			_ = TapBackButton();
			_ = App.WaitForElement(alertDialog, $"Time out waiting for alert dialogue.");
			return this;
		}

		/// <summary>Assert that the Search bar exists.</summary>
		/// <returns>Application assertion.</returns>
		public HomePage SearchBarExists()
		{
			AppResult[] searchBarElement = App.WaitForElement(searchSymbol, "Timeout waiting for search bar.");
			System.IO.File.Delete(@".\LiLo.Lite.UITest\Screenshots\Searchbar.png");
			App.Screenshot("Search Bar").MoveTo(@".\LiLo.Lite.UITest\Screenshots\Searchbar.png");
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
			AppResult[] searchBarElement = App.WaitForElement(this.searchSymbol, "Timeout waiting for search bar.");
			System.IO.File.Delete(@".\LiLo.Lite.UITest\Screenshots\Searchbar.png");
			App.Screenshot("Search Bar").MoveTo(@".\LiLo.Lite.UITest\Screenshots\Searchbar.png");
			AppResult searchBar = searchBarElement[0];
			App.EnterText(searchSrcText, searchSymbol);
			AppResult[] marketsListElement = App.WaitForElement(marketsList, "Timeout waiting for Markets list");
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
			App.Back();
			return this;
		}

		/// <summary>Assert tapping settings icon.</summary>
		/// <returns>Application assertion.</returns>
		public HomePage TapSettings()
		{
			AppResult[] marketsListElement = App.WaitForElement(marketsList, "Timeout waiting for Markets list");
			if (marketsListElement.Length == 0)
			{
				System.IO.File.Delete(@".\LiLo.Lite.UITest\Screenshots\marketsLengthFail.png");
				App.Screenshot("Markets length fail").MoveTo(@".\LiLo.Lite.UITest\Screenshots\marketsLengthFail.png");
				Assert.Fail("Markets list does not contain the expected number of markets");
			}
			else
			{
				App.Tap(x => x.Marked("TitleBarSettings").Index(0));
				WaitForPageToLeave();
				System.IO.File.Delete(@".\LiLo.Lite.UITest\Screenshots\HomeTapSettings.png");
				App.Screenshot("Tap Settings").MoveTo(@".\LiLo.Lite.UITest\Screenshots\HomeTapSettings.png");
				_ = TapBackButton();
			}

			return this;
		}

		/// <summary>Assert tapping a symbol.</summary>
		/// <param name="symbol">market symbol.</param>
		/// <returns>Application assertion.</returns>
		public HomePage TapSymbol(string symbol)
		{
			AppResult[] selectedmarket = App.WaitForElement(market(symbol));
			if (selectedmarket.Length != 1)
			{
				_ = App.Screenshot($"Market for currency '{symbol}' length fail");
				Assert.Fail($"Expected Market '{symbol}' does not exist in Markets List");
			}

			App.Tap(market(symbol));
			WaitForPageToLeave();
			System.IO.File.Delete($@".\LiLo.Lite.UITest\Screenshots\TapSymbol{symbol}.png");
			App.Screenshot($"Tap Symbol {symbol}").MoveTo($@".\LiLo.Lite.UITest\Screenshots\TapSymbol{symbol}.png");
			_ = TapBackButton();
			return this;
		}

		/// <summary>Assert the page title.</summary>
		/// <param name="pageTitle">Page title.</param>
		/// <returns>Application assertion.</returns>
		public HomePage ValidatePageTitle(string pageTitle = "Markets")
		{
			_ = App.WaitForElement(this.pageTitle(pageTitle), $"Timed out waiting for page with the title '{pageTitle}'.");
			System.IO.File.Delete(@".\LiLo.Lite.UITest\Screenshots\MarketsPageTitle.png");
			App.Screenshot("Markets Page Title").MoveTo(@".\LiLo.Lite.UITest\Screenshots\MarketsPageTitle.png");
			return this;
		}

		/// <summary>Assert that the Markets List exists.</summary>
		/// <param name="marketsCount">Number of expected markets.</param>
		/// <returns>Application assertion.</returns>
		public HomePage VerifyMarketsList(int marketsCount = -1)
		{
			AppResult[] marketsListElement = App.WaitForElement(marketsList, "Timeout waiting for Markets list");
			System.IO.File.Delete(@".\LiLo.Lite.UITest\Screenshots\MmarketsLength.png");
			App.Screenshot("Markets length").MoveTo(@".\LiLo.Lite.UITest\Screenshots\MmarketsLength.png");
			if (marketsCount == -1)
			{
				if (marketsListElement.Length == 0)
				{
					System.IO.File.Delete(@".\LiLo.Lite.UITest\Screenshots\marketsLengthFail.png");
					App.Screenshot("Markets length fail").MoveTo(@".\LiLo.Lite.UITest\Screenshots\marketsLengthFail.png");
					Assert.Fail("Markets list does not contain the expected number of markets");
				}
			}
			else
			{
				if (marketsListElement.Length != marketsCount)
				{
					System.IO.File.Delete(@".\LiLo.Lite.UITest\Screenshots\MarketLengthsFailCount.png");
					App.Screenshot($"Markets length fail {marketsCount}").MoveTo(@".\LiLo.Lite.UITest\Screenshots\MarketLengthsFailCount.png");
					Assert.Fail($"Markets list does not contain the expected number {marketsCount} of markets, actual {marketsListElement.Length}");
				}
			}

			return this;
		}
	}
}