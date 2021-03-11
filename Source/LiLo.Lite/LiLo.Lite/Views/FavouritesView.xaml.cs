// <copyright file="FavouritesView.xaml.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
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
		public FavouritesView() => this.InitializeComponent();

		/// <summary>Handle the device back button being pressed.</summary>
		/// <remarks>As this is the root page, we have to prevent the back button otherwise it will exit the application.</remarks>
		/// <returns>true; cancellation of back button.</returns>
		protected override bool OnBackButtonPressed()
		{
			Shell.Current.GoToAsync("///Settings").ConfigureAwait(true);
			return true; // prevent users from clicking the back button and exiting the application from the root page.
		}

		private void DragGestureRecognizer_DragStarting_Collection(object sender, DragStartingEventArgs e)
		{
		}

		private void DropGestureRecognizer_Drop_Collection(object sender, DropEventArgs e)
		{
			// We handle reordering logic in the view model
			e.Handled = true;
		}
	}
}