//-----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Assembly info
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite
{
	using System.Threading.Tasks;
	using LiLo.Lite.Services.Navigation;
	using LiLo.Lite.Services.Settings;
	using LiLo.Lite.Services.Sockets;
	using LiLo.Lite.Themes;
	using LiLo.Lite.ViewModels.Base;
	using Xamarin.Forms;

	/// <summary>LiLo application class.</summary>
	public partial class App : Application
	{
		/// <summary>Settings Service.</summary>
		private ISettingsService settingsService;

		/// <summary>Sockets Service.</summary>
		private ISocketsService socketsService;

		/// <summary>Initialises a new instance of the <see cref="App" /> class.</summary>summary>
		public App()
		{
			InitializeComponent();
		}

		/// <summary>Perform actions when the application resumes from a sleeping state.</summary>
		protected override void OnResume()
		{
			base.OnResume();
			ThemeHelper.Init(settingsService);
			ThemeHelper.ChangeTheme(settingsService.ThemeOption, true);
			if (!DesignMode.IsDesignModeEnabled)
			{
				socketsService.WebSocket_OnResume();
			}
		}

		/// <summary>Perform actions when the application enters the sleeping state.</summary>
		protected override void OnSleep()
		{
			base.OnStart();
			if (!DesignMode.IsDesignModeEnabled)
			{
				socketsService.WebSocket_OnSleep();
			}
		}

		/// <summary>Perform actions when the application starts.</summary>
		protected override async void OnStart()
		{
			await InitSettings();
			await InitNavigation();

			ThemeHelper.Init(settingsService);
			ThemeHelper.ChangeTheme(settingsService.ThemeOption, true);
		}

		/// <summary>Initialises the navigation service.</summary>
		/// <returns>Initialisation async task.</returns>
		private Task InitNavigation()
		{
			INavigationService navigationService = ViewModelLocator.Resolve<INavigationService>();
			return navigationService.InitializeAsync();
		}

		/// <summary>Initialises the settings and sockets services.</summary>
		/// <returns>Async Task result.</returns>
		private Task InitSettings()
		{
			settingsService = ViewModelLocator.Resolve<ISettingsService>();
			if (!DesignMode.IsDesignModeEnabled)
			{
				socketsService = ViewModelLocator.Resolve<ISocketsService>();
				socketsService.InitAsync();
			}

			return Task.FromResult(true);
		}
	}
}