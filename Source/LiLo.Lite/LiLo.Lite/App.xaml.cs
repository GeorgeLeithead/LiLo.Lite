//-----------------------------------------------------------------------
// <copyright file="App.xaml.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   LiLo application class.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite
{
	using LiLo.Lite.Services.Dialog;
	using LiLo.Lite.Services.Markets;
	using LiLo.Lite.Services.Sockets;
	using Microsoft.AppCenter;
	using Microsoft.AppCenter.Analytics;
	using Microsoft.AppCenter.Crashes;
	using Microsoft.AppCenter.Distribute;
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
			this.socketsService = DependencyService.Resolve<SocketsService>();
			DependencyService.Register<IDialogService>();
			DependencyService.Register<MarketsHelperService>();
			this.MainPage = new AppShell();
		}

		public static object UIParent { get; set; } = null;

		/// <summary>Perform actions when the application resumes from a sleeping state.</summary>
		protected override void OnResume()
		{
			base.OnResume();
			if (!DesignMode.IsDesignModeEnabled)
			{
				this.socketsService.WebSocket_OnResume();
			}
		}

		/// <summary>Perform actions when the application enters the sleeping state.</summary>
		protected override void OnSleep()
		{
			base.OnStart();
			if (!DesignMode.IsDesignModeEnabled)
			{
				this.socketsService.WebSocket_OnSleep();
			}
		}

		/// <summary>Perform actions when the application starts.</summary>
		protected override void OnStart()
		{
			base.OnStart();
			AppCenter.Start("android=4d413467-bf37-45b0-bf18-b8d15d98a182;", typeof(Analytics), typeof(Crashes), typeof(Distribute));
			if (!DesignMode.IsDesignModeEnabled)
			{
				this.socketsService.Connect();
			}

			Current.UserAppTheme = Current.RequestedTheme;
		}
	}
}