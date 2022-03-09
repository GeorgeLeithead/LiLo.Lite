// <copyright file="AppShell.xaml.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite
{
	using LiLo.Lite.Helpers;
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
			InitializeComponent();

			Routing.RegisterRoute(Constants.Navigation.Paths.Chart, typeof(ChartView));
			Routing.RegisterRoute(Constants.Navigation.Paths.Settings, typeof(SettingsView));
			Routing.RegisterRoute($"{Constants.Navigation.Paths.Settings}/{Constants.Navigation.Paths.Favourites}", typeof(FavouritesView));
		}
	}
}