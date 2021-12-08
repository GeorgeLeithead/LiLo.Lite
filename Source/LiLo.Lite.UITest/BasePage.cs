// <copyright file="BasePage.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.UITest
{
	using System;
	using NUnit.Framework;
	using Xamarin.UITest;

	/// <summary>Base Page.</summary>
	public abstract class BasePage
	{
		/// <summary>Initialises a new instance of the <see cref="BasePage"/> class.</summary>
		protected BasePage()
		{
			AssertOnPage(TimeSpan.FromSeconds(30));
			_ = App.Screenshot("On " + GetType().Name);
		}

		/// <summary>Gets the main gateway to interact with an app. This interface contains shared functionality between Xamarin.UITest.Android.AndroidApp and Xamarin.UITest.iOS.iOSApp.</summary>
		protected IApp App => AppManager.App;

		/// <summary>Gets a value indicating whether the application is on Android.</summary>
		protected bool OnAndroid => AppManager.Platform == Platform.Android;

		/// <summary>Gets a value indicating whether the application is on iOS.</summary>
		protected bool OniOS => AppManager.Platform == Platform.iOS;

		/// <summary>Gets an action on a trait for the test.</summary>
		protected abstract PlatformQuery Trait { get; }

		/// <summary>Verifies that the trait is still present. Defaults to no wait.</summary>
		/// <param name="timeout">Time to wait before the assertion fails.</param>
		protected void AssertOnPage(TimeSpan? timeout = default)
		{
			string message = "Unable to verify on page: " + GetType().Name;
			if (timeout == null)
			{
				Assert.IsNotEmpty(App.Query(Trait.Current), message);
			}
			else
			{
				Assert.DoesNotThrow(() => App.WaitForElement(Trait.Current, timeout: timeout), message);
			}
		}

		/// <summary>Verifies that the trait is no longer present. Defaults to a 5 second wait.</summary>
		/// <param name="timeout">Time to wait before the assertion fails.</param>
		protected void WaitForPageToLeave(TimeSpan? timeout = default)
		{
			timeout ??= TimeSpan.FromSeconds(5);
			string message = "Unable to verify *not* on page: " + GetType().Name;
			Assert.DoesNotThrow(() => App.WaitForNoElement(Trait.Current, timeout: timeout), message);
		}
	}
}