//-----------------------------------------------------------------------
// <copyright file="Environment.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Main Activity.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Droid.Services
{
	using Android.App;
	using Android.OS;
	using Android.Views;
	using LiLo.Lite.Helpers;
	using System.Drawing;
	using Xamarin.Essentials;

	public class Environment : IEnvironment
	{
		public void SetStatusBarColor(Color color, bool darkStatusBarTint)
		{
			if (Build.VERSION.SdkInt < BuildVersionCodes.Lollipop)
			{
				return;
			}

			Activity activity = Platform.CurrentActivity;
			Window window = activity.Window;
			window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
			window.ClearFlags(WindowManagerFlags.TranslucentStatus);
			window.SetStatusBarColor(color.ToPlatformColor());
			if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
			{
				StatusBarVisibility flag = (StatusBarVisibility)SystemUiFlags.LightStatusBar;
#pragma warning disable CS0618 // Type or member is obsolete and known
				window.DecorView.SystemUiVisibility = darkStatusBarTint ? flag : 0;
#pragma warning restore CS0618 // Type or member is obsolete and known
			}
		}
	}
}