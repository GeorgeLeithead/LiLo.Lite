//-----------------------------------------------------------------------
// <copyright file="EnvironmentAndroid.cs" company="InternetWideWorld.com">
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

using System;
using System.Threading.Tasks;
using Android.Content.Res;
using Android.OS;
using LiLo.Lite.Droid;
using LiLo.Lite.Interfaces;
using Plugin.CurrentActivity;
using Xamarin.Forms;

[assembly: Dependency(typeof(EnvironmentAndroid))]

namespace LiLo.Lite.Droid
{
	public class EnvironmentAndroid : IEnvironment
	{
		public Theme GetOperatingSystemTheme()
		{
			//Ensure the device is running Android Froyo or higher because UIMode was added in Android Froyo, API 8.0
			if (Build.VERSION.SdkInt < BuildVersionCodes.Froyo)
			{
				return Theme.Light;
			}

			UiMode uiModelFlags = CrossCurrentActivity.Current.AppContext.Resources.Configuration.UiMode & UiMode.NightMask;

			return uiModelFlags switch
			{
				UiMode.NightYes => Theme.Dark,
				UiMode.NightNo => Theme.Light,
				_ => throw new NotSupportedException($"UiMode {uiModelFlags} not supported"),
			};
		}

		public Task<Theme> GetOperatingSystemThemeAsync()
		{
			return Task.FromResult(this.GetOperatingSystemTheme());
		}
	}
}