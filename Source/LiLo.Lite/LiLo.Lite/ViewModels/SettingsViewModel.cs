// <copyright file="SettingsViewModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.ViewModels
{
	using LiLo.Lite.Helpers;
	using LiLo.Lite.Models.ChartModels;
	using LiLo.Lite.Resources;
	using LiLo.Lite.ViewModels.Base;
	using Microsoft.AppCenter.Analytics;
	using System;
	using System.Collections.Generic;
	using System.Globalization;
	using System.Linq;
	using System.Threading.Tasks;
	using Xamarin.CommunityToolkit.ObjectModel;
	using Xamarin.Essentials;
	using Xamarin.Forms;

	/// <summary>Settings view model.</summary>
	public class SettingsViewModel : ViewModelBase
	{
		/// <summary>Initialises a new instance of the <see cref="SettingsViewModel"/> class.</summary>
		public SettingsViewModel()
		{
			IsBusy = true;
			Title = AppResources.ViewTitleSettings;
			IndicatorModels = new ObservableRangeCollection<IndicatorModel>(PopulateChartModel.GetIndicator());
			IntervalModels = new ObservableRangeCollection<IntervalModel>(PopulateChartModel.GetInterval());
			BarStyleModels = new ObservableRangeCollection<BarStyleModel>(PopulateChartModel.GetBarStyle());
			IsBusy = false;
		}

		/// <summary>Gets the about application details.</summary>
		public string About => string.Format(CultureInfo.InvariantCulture, AppResources.SettingsLabelAbout, Version);

		/// <summary>Gets a collection of chart bar style models.</summary>
		public ObservableRangeCollection<BarStyleModel> BarStyleModels { get; }

		/// <summary>Gets or sets the chart bar style selected item.</summary>
		public BarStyleModel ChartBarStyleSelectedItem
		{
			get => BarStyleModels.FirstOrDefault(bsm => bsm.Value == Preferences.Get(Constants.Preferences.Chart.ChartBarStyle, Constants.Preferences.Chart.ChartBaryDefaultValue));
			set
			{
				BarStyleModel bsm = value;
				Preferences.Set(Constants.Preferences.Chart.ChartBarStyle, bsm.Value);
				OnPropertyChanged(nameof(ChartBarStyleSelectedItem));
			}
		}

		/// <summary>Gets or sets the chart indicator selected item.</summary>
		public IndicatorModel ChartIndicatorSelectedItem
		{
			get => IndicatorModels.FirstOrDefault(im => im.Value == Preferences.Get(Constants.Preferences.Chart.ChartStudyIndicator, Constants.Preferences.Chart.ChartStudyIndicatorDefaultValue));
			set
			{
				IndicatorModel im = value;
				Preferences.Set(Constants.Preferences.Chart.ChartStudyIndicator, im.Value);
				OnPropertyChanged(nameof(ChartIndicatorSelectedItem));
			}
		}

		/// <summary>Gets or sets the chart interval selected item.</summary>
		public IntervalModel ChartIntervalSelectedItem
		{
			get => IntervalModels.FirstOrDefault(im => im.Value == Preferences.Get(Constants.Preferences.Chart.ChartInterval, Constants.Preferences.Chart.ChartIntervalDefaultValue));
			set
			{
				IntervalModel im = value;
				Preferences.Set(Constants.Preferences.Chart.ChartInterval, im.Value);
				OnPropertyChanged(nameof(ChartIntervalSelectedItem));
			}
		}

		/// <summary>Gets or sets a value indicating whether chart tool bar is enabled.</summary>
		/// <remarks>"hide_side_toolbar": true .</remarks>
		public bool ChartToolBar
		{
			get => Preferences.Get(Constants.Preferences.Chart.ChartToolBar, Constants.Preferences.Chart.ChartToolBarDefaultValue);
			set
			{
				Preferences.Set(Constants.Preferences.Chart.ChartToolBar, value);
				OnPropertyChanged(nameof(ChartToolBar));
			}
		}

		/// <summary>Gets the edge browser command.</summary>
		public IAsyncCommand EdgeBrowserCommand => new AsyncCommand(BrowserCommandClicked, allowsMultipleExecutions: false);

		/// <summary>Gets or sets a value indicating whether favourites is enabled.</summary>
		public bool FavouritesEnabled
		{
			get => Preferences.Get(Constants.Preferences.Favourites.FavouritesEnabled, Constants.Preferences.Favourites.FavouritesEnabledDefaultValue);
			set
			{
				Analytics.TrackEvent(Constants.Analytics.Events.FavouritesEnabled, new Dictionary<string, string> { { Constants.Preferences.Favourites.FavouritesEnabled, value.ToString() } });
				Preferences.Set(Constants.Preferences.Favourites.FavouritesEnabled, value);
				OnPropertyChanged(nameof(FavouritesEnabled));
			}
		}

		/// <summary>Gets the favourites manage command.</summary>
		public IAsyncCommand FavouritesManageCommand => new AsyncCommand(FavouritesManageCommandClicked, allowsMultipleExecutions: false);

		/// <summary>Gets the GitHub command.</summary>
		public IAsyncCommand GithubCommand => new AsyncCommand(GitHubCommandClicked, allowsMultipleExecutions: false);

		/// <summary>Gets a collection of chart indicator models.</summary>
		public ObservableRangeCollection<IndicatorModel> IndicatorModels { get; }

		/// <summary>Gets a collection of chart interval models.</summary>
		public ObservableRangeCollection<IntervalModel> IntervalModels { get; }

		/// <summary>Gets or sets a value indicating whether show labels is enables.</summary>
		public bool ShowSymbolLabels
		{
			get => Preferences.Get(nameof(ShowSymbolLabels), true);
			set
			{
				Analytics.TrackEvent(Constants.Analytics.Events.ShowSymbolLabels, new Dictionary<string, string> { { nameof(FavouritesEnabled), value.ToString() } });
				Preferences.Set(nameof(ShowSymbolLabels), value);
				OnPropertyChanged(nameof(ShowSymbolLabels));
			}
		}

		/// <summary>Gets a value indicating whether dark theme is enabled.</summary>
		public bool ThemeDark => Application.Current.UserAppTheme == OSAppTheme.Dark;

		/// <summary>Gets a value indicating whether light theme is enabled.</summary>
		public bool ThemeLight => Application.Current.UserAppTheme == OSAppTheme.Light;

		/// <summary>Gets a value indicating whether system theme is enabled.</summary>
		public bool ThemeSystem => Application.Current.UserAppTheme == OSAppTheme.Unspecified;

		/// <summary>Gets the twitter command.</summary>
		public IAsyncCommand TwitterCommand => new AsyncCommand(TwitterCommandClicked, allowsMultipleExecutions: false);

		/// <summary>Gets the application version.</summary>
		private string Version => AppInfo.VersionString;

		private async Task BrowserCommandClicked()
		{
			await Browser.OpenAsync(new Uri(AppResources.SettingsIww), BrowserLaunchMode.SystemPreferred);
		}

		private async Task FavouritesManageCommandClicked()
		{
			await Shell.Current.GoToAsync(Constants.Navigation.Paths.Favourites);
		}

		private async Task GitHubCommandClicked()
		{
			await Browser.OpenAsync(new Uri(AppResources.SettingsGitHub), BrowserLaunchMode.SystemPreferred);
		}

		private async Task TwitterCommandClicked()
		{
			await Browser.OpenAsync(new Uri(AppResources.SettingsTwitter), BrowserLaunchMode.SystemPreferred);
		}
	}
}