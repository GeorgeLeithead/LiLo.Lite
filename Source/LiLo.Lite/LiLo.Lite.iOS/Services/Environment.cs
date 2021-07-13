//-----------------------------------------------------------------------
// <copyright file="Environment.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>
//-----------------------------------------------------------------------

namespace LiLo.Lite.iOS.Services
{
	using LiLo.Lite.Helpers;
	using UIKit;
	using Xamarin.Essentials;

	public class Environment : IEnvironment
	{
		public void SetStatusBarColor(System.Drawing.Color color, bool darkStatusBarTint)
		{
			UIStatusBarStyle style = darkStatusBarTint ? UIStatusBarStyle.DarkContent : UIStatusBarStyle.LightContent;
			UIApplication.SharedApplication.SetStatusBarStyle(style, false);
			Platform.GetCurrentUIViewController()?.SetNeedsStatusBarAppearanceUpdate();
		}
	}
}