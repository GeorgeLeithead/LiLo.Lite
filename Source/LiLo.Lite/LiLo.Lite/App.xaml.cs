// <copyright file="App.xaml.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite
{
	using LiLo.Lite.Helpers;
	using LiLo.Lite.Services.Dialog;
	using LiLo.Lite.Services.Markets;
	using LiLo.Lite.Services.Sockets;
	using Microsoft.AppCenter;
	using Microsoft.AppCenter.Analytics;
	using Microsoft.AppCenter.Crashes;
	using Xamarin.Essentials;
	using Xamarin.Forms;

	/// <summary>LiLo application class.</summary>
	public partial class App : Application
	{
		/// <summary>Sockets Service.</summary>
		private readonly ISocketsService socketsService;

		/// <summary>Initialises a new instance of the <see cref="App" /> class.</summary>
		public App()
		{
			InitializeComponent();
			DependencyService.Register<SocketsService>();
			socketsService = DependencyService.Resolve<SocketsService>();
			DependencyService.Register<DialogService>();
			DependencyService.Register<MarketsHelperService>();
			Current.MainPage = new AppShell();
		}

		/// <summary>Perform actions when the application resumes from a sleeping state.</summary>
		protected override void OnResume()
		{
			base.OnResume();
			if (!DesignMode.IsDesignModeEnabled)
			{
				_ = socketsService?.WebSocket_OnResume();
			}

			SetTheme();
			RequestedThemeChanged += App_RequestedThemeChanged;
		}

		/// <summary>Perform actions when the application enters the sleeping state.</summary>
		protected override void OnSleep()
		{
			base.OnSleep();
			if (!DesignMode.IsDesignModeEnabled)
			{
				_ = socketsService?.WebSocket_OnSleep();
			}

			SetTheme();
			RequestedThemeChanged -= App_RequestedThemeChanged;
		}

		/// <summary>Perform actions when the application starts.</summary>
		protected override void OnStart()
		{
			base.OnStart();
			AppCenter.Start("android=4d413467-bf37-45b0-bf18-b8d15d98a182;ios=fc7532d3-fdc1-4447-99a7-33d07c9bae08;", typeof(Analytics), typeof(Crashes));
			if (!DesignMode.IsDesignModeEnabled)
			{
				_ = socketsService?.Connect();
			}

			SetTheme();
		}

		private void App_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
		{
			int themeRequested = (int)e.RequestedTheme;
			Preferences.Set(Constants.Preferences.Settings.Theme, themeRequested);
			SetTheme();
		}

		private void SetTheme()
		{
			int theme = Preferences.Get(Constants.Preferences.Settings.Theme, Constants.Preferences.Settings.ThemeDefaultValue);
			MainThread.BeginInvokeOnMainThread(() =>
			{
				Current.UserAppTheme = theme switch
				{
					1 => OSAppTheme.Light,
					2 => OSAppTheme.Dark,
					_ => OSAppTheme.Unspecified,
				};

				IEnvironment env = DependencyService.Get<IEnvironment>();
				if (Current.RequestedTheme == OSAppTheme.Dark)
				{
					env?.SetStatusBarColor(Color.Black, false);
				}
				else
				{
					env?.SetStatusBarColor(Color.White, true);
				}
			});
		}
	}
}