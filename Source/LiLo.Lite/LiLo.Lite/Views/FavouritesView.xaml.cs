// <copyright file="FavouritesView.xaml.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Views
{
	using Xamarin.Forms;
	using Xamarin.Forms.Xaml;

	/// <summary>Favourites page view.</summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FavouritesView : ContentPage
	{
		/// <summary>Initialises a new instance of the <see cref="FavouritesView"/> class.</summary>
		public FavouritesView()
		{
			this.InitializeComponent();
		}

		/// <summary>Handle the device back button being pressed.</summary>
		/// <returns>true; cancellation of back button.</returns>
		protected override bool OnBackButtonPressed()
		{
			_ = Shell.Current.GoToAsync("..");
			return true; // prevent users from clicking the back button and exiting the application from the root page.
		}
	}
}