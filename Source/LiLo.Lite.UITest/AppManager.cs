// <copyright file="AppManager.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.UITest
{
	using System;
	using Xamarin.UITest;

	/// <summary>Application manager.</summary>
	/// <remarks>Based on using the 'Page Object Pattern' <a href="https://devblogs.microsoft.com/xamarin/best-practices-tips-xamarin-uitest/">Best Practices and Tips for Using Xamarin.UITest</a> for details.</remarks>
	internal static class AppManager
	{
		private static IApp app;
		private static Platform? platform;

		/// <summary>Gets the main gateway to interact with an app. This interface contains shared functionality between Xamarin.UITest.Android.AndroidApp and Xamarin.UITest.iOS.iOSApp.</summary>
		public static IApp App => app ?? throw new NullReferenceException("'AppManager.App' not set. Call 'AppManager.StartApp()' before trying to access it.");

		/// <summary>Gets or sets the platform being tested.</summary>
		public static Platform Platform
		{
			get => platform == null ? throw new NullReferenceException("'AppManager.Platform' not set.") : platform.Value;
			set => platform = value;
		}

		/// <summary>Application StartUp configuration.</summary>
		/// <remarks>REMEMBER:
		/// - To use InstalledApp the app must be installed on the emulator
		/// - The emulator must be running BEFORE starting tests
		/// - Any updates to the app need to be deployed to the emulator, BEFORE they can be tested.
		/// </remarks>
		public static void StartApp()
		{
			if (platform == Platform.Android)
			{
				app = ConfigureApp
					.Android
					.EnableLocalScreenshots().InstalledApp("com.internetwideworld.lilo.lite")
					.StartApp();
			}

			if (Platform == Platform.iOS)
			{
				app = ConfigureApp.iOS.EnableLocalScreenshots().StartApp();
			}
		}
	}
}