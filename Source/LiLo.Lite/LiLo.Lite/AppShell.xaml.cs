//-----------------------------------------------------------------------
// <copyright file="AppShell.xaml.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   App shell.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite
{
    using LiLo.Lite.Views;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;

	/// <summary>App shell.</summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AppShell
	{
		/// <summary>Initialises a new instance of the <see cref="AppShell"/> class.</summary>
		public AppShell()
		{
			this.InitializeComponent();

			Routing.RegisterRoute("Chart", typeof(ChartView));
			Routing.RegisterRoute("Settings", typeof(SettingsView));
			Routing.RegisterRoute("Favourites", typeof(FavouritesView));
			Routing.RegisterRoute("Alerts", typeof(AlertsView));
		}
	}
}