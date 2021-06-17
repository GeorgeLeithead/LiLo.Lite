//-----------------------------------------------------------------------
// <copyright file="AppDelegate.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   App Delegate.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.iOS
{
	using System.Linq;
	using Foundation;
	using LiLo.Lite.Views;
	using ObjCRuntime;
	using UIKit;
	using UserNotifications;
	using Xamarin.Forms;

	/// <summary>The UIApplicationDelegate for the application. This class is responsible for launching the User Interface of the application, as well as listening (and optionally responding) to application events from iOS.</summary>
	[Register("AppDelegate")]
	public partial class AppDelegate : Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		/// <inheritdoc/>
		public override bool FinishedLaunching(UIApplication app, NSDictionary options)
		{
			Forms.SetFlags("CollectionView_Experimental");
			Forms.Init();
			UNUserNotificationCenter.Current.Delegate = new IOSNotificationReceiver();
			this.LoadApplication(new App());
			return base.FinishedLaunching(app, options);
		}

		/// <inheritdoc/>
		public override UIInterfaceOrientationMask GetSupportedInterfaceOrientations(UIApplication application, [Transient] UIWindow forWindow)
		{
			Page mainpage = Xamarin.Forms.Application.Current.MainPage;
			return mainpage.Navigation.NavigationStack.LastOrDefault() is ChartView
				? UIInterfaceOrientationMask.Portrait
				: UIInterfaceOrientationMask.All;
		}
	}
}