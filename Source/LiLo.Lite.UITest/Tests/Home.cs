// <copyright file="Home.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
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
			new HomePage().ValidatePageTitle(pageTitle);
		}

		/// <summary>Test that the markets list exists.</summary>
		[Test]
		public void MarketsListExists()
		{
			new HomePage().VerifyMarketsList();
		}

		/// <summary>Test that the markets list exists and has a matching count.</summary>
		[Test]
		public void MarketsListCount()
		{
			new HomePage().VerifyMarketsList(7);
		}
	}
}