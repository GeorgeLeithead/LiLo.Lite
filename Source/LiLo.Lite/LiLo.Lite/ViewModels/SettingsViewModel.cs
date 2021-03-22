// <copyright file="SettingsViewModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>

namespace LiLo.Lite.ViewModels
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using LiLo.Lite.ViewModels.Base;
	using Microsoft.AppCenter.Analytics;
	using Xamarin.CommunityToolkit.ObjectModel;
	using Xamarin.Essentials;
	using Xamarin.Forms;

	/// <summary>Settings view model.</summary>
	public class SettingsViewModel : ViewModelBase
	{
		/// <summary>Initialises a new instance of the <see cref="SettingsViewModel"/> class.</summary>
		public SettingsViewModel()
		{
			this.IsBusy = true;
			this.Title = "Settings";
			this.IsBusy = false;
		}

		/// <summary>Gets the edge browser command.</summary>
		public IAsyncCommand EdgeBrowserCommand => new AsyncCommand(this.BrowserCommandClicked, allowsMultipleExecutions: false);

		/// <summary>Gets or sets a value indicating whether favourites is enabled.</summary>
		public bool FavouritesEnabled
		{
			get => Preferences.Get(nameof(this.FavouritesEnabled), false);
			set
			{
				Analytics.TrackEvent("FavouritesEnabled", new Dictionary<string, string> { { nameof(this.FavouritesEnabled), value.ToString() } });
				Preferences.Set(nameof(this.FavouritesEnabled), value);
				this.NotifyPropertyChanged(() => this.FavouritesEnabled);
			}
		}

		/// <summary>Gets the favourites manage command.</summary>
		public IAsyncCommand FavouritesManageCommand => new AsyncCommand(this.FavouritesManageCommandClicked, allowsMultipleExecutions: false);

		/// <summary>Gets the GitHub command.</summary>
		public IAsyncCommand GithubCommand => new AsyncCommand(this.GitHubCommandClicked, allowsMultipleExecutions: false);

		/// <summary>Gets the app settings command.</summary>
		public IAsyncCommand SettingsCommand => new AsyncCommand(this.SettingsCommandClicked, allowsMultipleExecutions: false);

		/// <summary>Gets a value indicating whether the system theme is supported.</summary>
		public bool SystemThemeSupported
		{
			get
			{
				Version minDefaultVersion = new Version(13, 0);
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

		/// <summary>Gets a value indicating whether dark theme is enabled.</summary>
		public bool ThemeDark => Application.Current.UserAppTheme == OSAppTheme.Dark;

		/// <summary>Gets a value indicating whether light theme is enabled.</summary>
		public bool ThemeLight => Application.Current.UserAppTheme == OSAppTheme.Light;

		/// <summary>Gets a value indicating whether system theme is enabled.</summary>
		public bool ThemeSystem => Application.Current.UserAppTheme == OSAppTheme.Unspecified;

		/// <summary>Gets the twitter command.</summary>
		public IAsyncCommand TwitterCommand => new AsyncCommand(this.TwitterCommandClicked, allowsMultipleExecutions: false);

		/// <summary>Gets the application version.</summary>
		public string Version => AppInfo.VersionString;

		private async Task BrowserCommandClicked() => await Browser.OpenAsync(new Uri("https://www.internetwideworld.com/lilolite"), BrowserLaunchMode.SystemPreferred);

		private async Task FavouritesManageCommandClicked() => await Shell.Current.GoToAsync("///Favourites");

		private async Task GitHubCommandClicked() => await Browser.OpenAsync(new Uri("https://github.com/GeorgeLeithead/LiLo.Lite"), BrowserLaunchMode.SystemPreferred);

		private async Task SettingsCommandClicked()
		{
			AppInfo.ShowSettingsUI();
			await Task.FromResult(true);
		}

		/// <summary>Link to the twitter page for LiLo.</summary>
		private async Task TwitterCommandClicked() => await Browser.OpenAsync(new Uri("https://twitter.com/LiLoMobileApp"), BrowserLaunchMode.SystemPreferred);
	}
}