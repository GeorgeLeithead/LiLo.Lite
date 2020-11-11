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
	using LiLo.Lite.Services.Navigation;
	using LiLo.Lite.Services.Sockets;
	using LiLo.Lite.ViewModels.Base;
	using Microsoft.AppCenter;
	using Microsoft.AppCenter.Analytics;
	using Microsoft.AppCenter.Crashes;
	using Microsoft.AppCenter.Distribute;
	using System.Threading.Tasks;
	using Xamarin.Forms;

	/// <summary>LiLo application class.</summary>
	public partial class App : Application
	{
		/// <summary>Sockets Service.</summary>
		private ISocketsService socketsService;

		/// <summary>Initialises a new instance of the <see cref="App" /> class.</summary>summary>
		public App()
		{
			Xamarin.Forms.Device.SetFlags(new string[] { "AppTheme_Experimental" });
			InitializeComponent();
			Current.RequestedThemeChanged += (s, a) =>
			{
				Current.UserAppTheme = Current.RequestedTheme;
			};
		}

		/// <summary>Perform actions when the application resumes from a sleeping state.</summary>
		protected override void OnResume()
		{
			base.OnResume();
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
			base.OnStart();
			AppCenter.Start("android=4d413467-bf37-45b0-bf18-b8d15d98a182;", typeof(Analytics), typeof(Crashes), typeof(Distribute));
			if (!DesignMode.IsDesignModeEnabled)
			{
				socketsService = ViewModelLocator.Resolve<ISocketsService>();
				await socketsService.InitAsync();
			}

			Current.UserAppTheme = Current.RequestedTheme;
			await InitNavigation();
		}

		/// <summary>Initialises the navigation service.</summary>
		/// <returns>Initialisation async task.</returns>
		private Task InitNavigation()
		{
			INavigationService navigationService = ViewModelLocator.Resolve<INavigationService>();
			return navigationService.InitializeAsync();
		}
	}
}