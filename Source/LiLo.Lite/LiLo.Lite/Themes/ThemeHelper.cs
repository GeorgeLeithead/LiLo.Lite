//-----------------------------------------------------------------------
// <copyright file="ThemeHelper.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Application theme helper.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Themes
{
	using LiLo.Lite.Models;
	using LiLo.Lite.Services.Environment;
	using LiLo.Lite.Services.Settings;
	using Xamarin.Essentials;
	using Xamarin.Forms;

	/// <summary>Application theme helper.</summary>
	public static class ThemeHelper
	{
		/// <summary>Settings service interface.</summary>
		private static ISettingsService settingsService;

		/// <summary>Change the application theme.</summary>
		/// <param name="theme">Application theme</param>
		/// <param name="forceTheme">Force them application.</param>
		public static void ChangeTheme(ThemeModel theme, bool forceTheme = false)
		{
			ThemeModel currentTheme = settingsService.ThemeOption;
			if (theme == currentTheme && !forceTheme)
			{
				return; // don't change to the same theme
			}

			ResourceDictionary applicationResourceDictionary = Application.Current.Resources; // clear all the resources
			if (theme == ThemeModel.Default)
			{
				theme = AppInfo.RequestedTheme == AppTheme.Dark ? ThemeModel.Dark : ThemeModel.Light;
			}

			ResourceDictionary newTheme = theme switch
			{
				ThemeModel.Light => new LightTheme(),
				ThemeModel.Dark => new DarkTheme(),
				_ => new LightTheme(),
			};
			ManuallyCopyThemes(newTheme, applicationResourceDictionary);
			settingsService.ThemeOption = theme;
			IEnvironmentService environment = DependencyService.Get<IEnvironmentService>();
			Color background = (Color)Application.Current.Resources["PrimaryDarkColor"];
			environment?.SetStatusBarColor(ColorConverters.FromHex(background.ToHex()), false);
		}

		/// <summary>Initialises the theme helper service.</summary>
		/// <param name="settingsServiceConstructor">Settings service constructor.</param>
		public static void Init(ISettingsService settingsServiceConstructor)
		{
			settingsService = settingsServiceConstructor;
		}

		/// <summary>Manually copy theme resource dictionary.</summary>
		/// <param name="fromResource">Copy resources from.</param>
		/// <param name="toResource">Copy resources to.</param>
		private static void ManuallyCopyThemes(ResourceDictionary fromResource, ResourceDictionary toResource)
		{
			foreach (string item in fromResource.Keys)
			{
				toResource[item] = fromResource[item];
			}
		}
	}
}