//-----------------------------------------------------------------------
// <copyright file="SettingsService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Application settings service.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Services.Settings
{
	using System;
	using Lilo.Lite.Services;
	using LiLo.Lite.Models;
	using Xamarin.Essentials;

	/// <summary>Application settings service.</summary>
	public class SettingsService : NotifyPropertyChangedBase, ISettingsService
	{
		/// <summary>Gets a value indicating whether the device has a default theme option for the appropriate device and version.</summary>
		public bool HasDefaultThemeOption
		{
			get
			{
				var minDefaultVersion = new Version(13, 0);
				if (DeviceInfo.Platform == DevicePlatform.UWP)
				{
					minDefaultVersion = new Version(10, 0, 17763, 1);
				}
				else if (DeviceInfo.Platform == DevicePlatform.Android)
				{
					minDefaultVersion = new Version(10, 0);
				}

				return DeviceInfo.Version >= minDefaultVersion;
			}
		}

		/// <summary>Gets or sets the users selected theme.</summary>
		public ThemeModel ThemeOption
		{
			get => (ThemeModel)Preferences.Get(nameof(ThemeOption), HasDefaultThemeOption ? (int)ThemeModel.Default : (int)ThemeModel.Light);
			set => Preferences.Set(nameof(ThemeOption), (int)value);
		}
	}
}