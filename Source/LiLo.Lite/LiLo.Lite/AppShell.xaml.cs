// <copyright file="AppShell.xaml.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

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
			Routing.RegisterRoute("Settings/Favourites", typeof(FavouritesView));
			Routing.RegisterRoute("Alerts", typeof(AlertsView));
		}
	}
}