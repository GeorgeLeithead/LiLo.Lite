// <copyright file="BaseTestFixture.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>

namespace LiLo.Lite.UITest
{
	using NUnit.Framework;
	using Xamarin.UITest;

	/// <summary>Base test fixture.</summary>
	[TestFixture(Platform.Android)]
	[TestFixture(Platform.iOS)]
	public abstract class BaseTestFixture
	{
		/// <summary>Initialises a new instance of the <see cref="BaseTestFixture"/> class.</summary>
		/// <param name="platform">On platform.</param>
		protected BaseTestFixture(Platform platform) => AppManager.Platform = platform;

		/// <summary>Gets the main gateway to interact with an app. This interface contains shared functionality between Xamarin.UITest.Android.AndroidApp and Xamarin.UITest.iOS.iOSApp.</summary>
		protected IApp App => AppManager.App;

		/// <summary>Gets a value indicating whether the application is on Android.</summary>
		protected bool OnAndroid => AppManager.Platform == Platform.Android;

		/// <summary>Gets a value indicating whether the application is on iOS.</summary>
		protected bool OniOS => AppManager.Platform == Platform.iOS;

		/// <summary>before each test, start up the app.</summary>
		[SetUp]
		public virtual void BeforeEachTest() => AppManager.StartApp();
	}
}