// <copyright file="Home.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.UITest.Tests
{
	using LiLo.Lite.UITest.Pages;
	using NUnit.Framework;
	using Xamarin.UITest;

	/// <summary>Tests for the Home page.</summary>
	[TestFixture(Platform.Android)]
	public class Home : BaseTestFixture
	{
		/// <summary>Initialises a new instance of the <see cref="Home"/> class.</summary>
		/// <param name="platform">On Platform.</param>
		public Home(Platform platform)
			: base(platform)
		{
		}

		/// <summary>Launch REPL (read-eval-print-loop).</summary>
		[Test]
		public void Repl()
		{
			if (TestEnvironment.IsTestCloud)
			{
				Assert.Ignore("Local only");
			}

			this.App.Repl();
		}

		/// <summary>Test the page title.</summary>
		[Test]
		public void PageTitleTest()
		{
			// Arrange
			string pageTitle = "Markets";

			// Act
			_ = new HomePage().ValidatePageTitle(pageTitle);
		}

		/// <summary>Test that the markets list exists.</summary>
		[Test]
		public void MarketsListExists()
		{
			_ = new HomePage().VerifyMarketsList();
		}

		/// <summary>Test that the markets list exists and has a matching count.</summary>
		[Test]
		public void MarketsListCount()
		{
			_ = new HomePage().VerifyMarketsList(7);
		}

		/// <summary>Test home page the search bar.</summary>
		[Test]
		public void SearchBar()
		{
			HomePage homePage = new HomePage();
			_ = homePage.SearchBarExists();
			////homePage.SearchBarSearch("BTC");
		}

		/// <summary>Test tapping market symbols.</summary>
		[Test]
		public void TapMarket()
		{
			HomePage homePage = new HomePage();
			_ = homePage.TapSymbol("XRP_symbol");
			_ = homePage.TapSymbol("BTC_symbol");
		}

		/// <summary>Test tapping the settings icon.</summary>
		[Test]
		public void TapSettings()
		{
			_ = new HomePage().TapSettings();
		}
	}
}