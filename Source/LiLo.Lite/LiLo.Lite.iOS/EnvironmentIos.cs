//-----------------------------------------------------------------------
// <copyright file="EnvironmentIos.cs" company="InternetWideWorld.com">
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

using System;
using System.Linq;
using System.Threading.Tasks;
using LiLo.Lite.Interfaces;
using LiLo.Lite.iOS;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(EnvironmentIos))]

namespace LiLo.Lite.iOS
{
	public class EnvironmentIos : IEnvironment
	{
		public Theme GetOperatingSystemTheme()
		{
			//Ensure the current device is running 12.0 or higher, because `TraitCollection.UserInterfaceStyle` was introduced in iOS 12.0
			if (UIDevice.CurrentDevice.CheckSystemVersion(12, 0))
			{
				UIViewController currentUIViewController = GetVisibleViewController();
				UIUserInterfaceStyle userInterfaceStyle = currentUIViewController.TraitCollection.UserInterfaceStyle;
				switch (userInterfaceStyle)
				{
					case UIUserInterfaceStyle.Light:
						return Theme.Light;

					case UIUserInterfaceStyle.Dark:
						return Theme.Dark;

					default:
						throw new NotSupportedException($"UIUserInterfaceStyle {userInterfaceStyle} not supported");
				}
			}
			else
			{
				return Theme.Light;
			}
		}

		// UIApplication.SharedApplication can only be referenced by the Main Thread, so we'll use Device.InvokeOnMainThreadAsync which was introduced in Xamarin.Forms v4.2.0
		public async Task<Theme> GetOperatingSystemThemeAsync() => await Device.InvokeOnMainThreadAsync(this.GetOperatingSystemTheme);

		private static UIViewController GetVisibleViewController()
		{
			UIViewController viewController = null;
			UIWindow window = UIApplication.SharedApplication.KeyWindow;
			if (window.WindowLevel == UIWindowLevel.Normal)
			{
				viewController = window.RootViewController;
			}

			if (viewController is null)
			{
				window = UIApplication.SharedApplication.Windows
					.OrderByDescending(w => w.WindowLevel)
					.FirstOrDefault(w => w.RootViewController != null && w.WindowLevel == UIWindowLevel.Normal);
				viewController = window?.RootViewController ?? throw new InvalidOperationException("Could not find current view controller.");
			}

			while (viewController.PresentedViewController != null)
			{
				viewController = viewController.PresentedViewController;
			}

			return viewController;
		}
	}
}