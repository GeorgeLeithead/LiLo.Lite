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
	using LiLo.Lite.Definitions;
	using LiLo.Lite.Models;
	using Xamarin.Essentials;

	/// <summary>Application settings service.</summary>
	public class SettingsService : NotifyPropertyChangedBase, ISettingsService
	{
		/// <summary>Default network</summary>
		private readonly bool defaultNetwork = true;

		/// <summary>Default symbol.</summary>
		private readonly string defaultSymbol = Enum.GetNames(typeof(CurrencyEnum))[0];

		/// <summary>Sets the users last selected currency.</summary>
		public CurrencyEnum Currency
		{
			set => Preferences.Set(nameof(Symbol), value.ToString());
		}

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

		/// <summary>Gets a value indicating whether the user is network Authenticate-able.</summary>
		public bool IsAuthenticatable => TestNet
					? !string.IsNullOrEmpty(TestNetApi) && !string.IsNullOrEmpty(TestNetPrivate)
					: !string.IsNullOrEmpty(MainNetApi) && !string.IsNullOrEmpty(MainNetPrivate);

		/// <summary>Gets or sets the users MainNet API key.</summary>
		public string MainNetApi
		{
			get => Preferences.Get(nameof(MainNetApi), string.Empty);
			set => Preferences.Set(nameof(MainNetApi), value);
		}

		/// <summary>Gets or sets the users MainNet Private key.</summary>
		public string MainNetPrivate
		{
			get => Preferences.Get(nameof(MainNetPrivate), string.Empty);
			set => Preferences.Set(nameof(MainNetPrivate), value);
		}

		/// <summary>Gets or sets the users selected currency symbol.</summary>
		public string Symbol
		{
			get => Preferences.Get(nameof(Symbol), defaultSymbol);
			set => Preferences.Set(nameof(Symbol), value);
		}

		/// <summary>Gets or sets a value indicating whether the network is TestNet.</summary>
		public bool TestNet
		{
			get => Preferences.Get("TestNet", defaultNetwork);
			set => Preferences.Set(nameof(TestNet), value);
		}

		/// <summary>Gets or sets the users TestNet API key.</summary>
		public string TestNetApi
		{
			get => Preferences.Get(nameof(TestNetApi), string.Empty);
			set => Preferences.Set(nameof(TestNetApi), value);
		}

		/// <summary>Gets or sets the users TestNet private key.</summary>
		public string TestNetPrivate
		{
			get => Preferences.Get(nameof(TestNetPrivate), string.Empty);
			set => Preferences.Set(nameof(TestNetPrivate), value);
		}

		/// <summary>Gets or sets the users selected theme.</summary>
		public ThemeModel ThemeOption
		{
			get => (ThemeModel)Preferences.Get(nameof(ThemeOption), HasDefaultThemeOption ? (int)ThemeModel.Default : (int)ThemeModel.Light);
			set => Preferences.Set(nameof(ThemeOption), (int)value);
		}
	}
}