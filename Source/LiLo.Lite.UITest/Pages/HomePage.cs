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

		/// <summary>Arrange test for page title.</summary>
		private readonly Func<string, Query> pageTitle;

		/// <summary>Initialises a new instance of the <see cref="HomePage"/> class.</summary>
		public HomePage()
		{
			this.marketsList = x => x.Marked("CollectionViewMarketsList").Child();
			this.pageTitle = pageName => x => x.Marked("PageTitle").Text(pageName);
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
			this.App.Screenshot("Markets Page Title");
			return this;
		}

		/// <summary>Assert that the Markets List exists.</summary>
		/// <param name="marketsCount">Number of expected markets.</param>
		/// <returns>Application assertion.</returns>
		public HomePage VerifyMarketsList(int marketsCount = -1)
		{
			AppResult[] marketsListElement = this.App.WaitForElement(this.marketsList, "Timeout waiting for Markets list");
			this.App.Screenshot("Markets length");
			if (marketsCount == -1)
			{
				if (marketsListElement.Length == 0)
				{
					this.App.Screenshot("Markets length fail");
					Assert.Fail("Markets list does not contain the expected number of markets");
				}
			}
			else
			{
				if (marketsListElement.Length != marketsCount)
				{
					this.App.Screenshot($"Markets length fail {marketsCount}");
					Assert.Fail($"Markets list does not contain the expected number {marketsCount} of markets, actual {marketsListElement.Length}");
				}
			}

			return this;
		}
	}
}