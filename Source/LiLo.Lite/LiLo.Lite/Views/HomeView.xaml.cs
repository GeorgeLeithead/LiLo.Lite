// <copyright file="HomeView.xaml.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Views
{
	using LiLo.Lite.Helpers;
	using LiLo.Lite.Models.Markets;
	using LiLo.Lite.Resources;
	using LiLo.Lite.ViewModels;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using Xamarin.Essentials;
	using Xamarin.Forms;
	using Xamarin.Forms.Internals;
	using Xamarin.Forms.Xaml;

	/// <summary>Home page view.</summary>
	[Preserve(AllMembers = true)]
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeView : ContentPage
	{
		private HomeViewModel vm;

		/// <summary>Initialises a new instance of the <see cref="HomeView" /> class.</summary>
		public HomeView()
		{
			InitializeComponent();
		}

		private HomeViewModel VM => vm ??= (HomeViewModel)BindingContext;

		/// <inheritdoc/>
		protected override void OnAppearing()
		{
			base.OnAppearing();
			SearchBar.Unfocus();
			if (VM.FavouritesList != Preferences.Get(Constants.Preferences.Favourites.FavouritesCategory, Constants.Preferences.Favourites.FavouritesCategoryDefaultValue) || VM.FavouritesEnabled != Preferences.Get(Constants.Preferences.Favourites.FavouritesEnabled, Constants.Preferences.Favourites.FavouritesEnabledDefaultValue))
			{
				// Favourites have changed to we need to close the sockets connection, and re-initialise to as to show the updated markets list.
				VM.IsBusy = true;
				VM.FavouritesList = Preferences.Get(Constants.Preferences.Favourites.FavouritesCategory, Constants.Preferences.Favourites.FavouritesCategoryDefaultValue);
				VM.FavouritesEnabled = Preferences.Get(Constants.Preferences.Favourites.FavouritesEnabled, Constants.Preferences.Favourites.FavouritesEnabledDefaultValue);
				_ = VM.SocketsService.WebSocket_OnSleep(); // Sleep the connection
				_ = VM.SocketsService.WebSocket_Close(); // Close the connection
				_ = VM.Init().ConfigureAwait(false); // Re-initialise the markets and sockets connections.
			}

			if (VM.MagazineView != Preferences.Get(Constants.Preferences.Settings.MarketsView, Constants.Preferences.Settings.MarketsViewDefaulyValue))
			{
				// The user selected view has changed.  To change the DisplayTemplate we weed to clear the ItemSource and re-populate it.
				VM.IsBusy = true;
				VM.MagazineView = Preferences.Get(Constants.Preferences.Settings.MarketsView, Constants.Preferences.Settings.MarketsViewDefaulyValue);
				CollectionViewMarketsList.ItemsSource = "";
				CollectionViewMarketsList.ItemsSource = VM.MarketsList;
				VM.IsBusy = false;
			}
		}

		/// <summary>Handle the device back button being pressed.</summary>
		/// <remarks>As this is the root page, we have to prevent the back button otherwise it will exit the application.</remarks>
		/// <returns>true; cancellation of back button.</returns>
		protected override bool OnBackButtonPressed()
		{
			// Begin an asynchronous task on the UI thread because we intend to ask the users permission.
			Device.BeginInvokeOnMainThread(async () =>
			{
				bool trulyExitConfirm = await VM.DialogService.ShowConfirmAsync(AppResources.ExitModalTitle, AppResources.ExitModalMessage, AppResources.ExitModalOkText, AppResources.ExitModalCancelText);
				if (trulyExitConfirm)
				{
					_ = base.OnBackButtonPressed();
					_ = Process.GetCurrentProcess().CloseMainWindow();
					Process.GetCurrentProcess().Close();
				}
			});

			return true;
		}

		/// <inheritdoc/>
		protected override void OnDisappearing()
		{
			base.OnDisappearing();
		}

		/// <inheritdoc/>
		/// <remarks>1 = Portrait mode, 2 = Landscape mode.</remarks>
		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);
			VM.GridItemsLayoutSpan = width > height ? 2 : 1;
		}

		/// <summary>Search Bar text changed.</summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Text changed event arguments.</param>
		private void SearchBarTextChanged(object sender, TextChangedEventArgs e)
		{
			string searchTerm = e.NewTextValue;
			if (string.IsNullOrWhiteSpace(searchTerm))
			{
				searchTerm = string.Empty;
				VM.IsSearchVisible = false;
				SearchBar.Unfocus();
			}

			searchTerm = searchTerm.ToUpperInvariant();
			List<MarketModel> originList = VM.MarketsHelperService.SourceMarketsList;
			List<MarketModel> filteredMarkets = originList.Where(ol => ol.SymbolString.Contains(searchTerm)).ToList();
			VM.MarketsList.Clear();
			if (string.IsNullOrEmpty(searchTerm))
			{
				foreach (MarketModel market in originList)
				{
					VM.MarketsList.Add(market);
				}

				return;
			}

			foreach (MarketModel market in from MarketModel market in originList
										   let matchingMarket = filteredMarkets.Any(fm => fm.SymbolString == market.SymbolString)
										   where matchingMarket
										   select market)
			{
				VM.MarketsList.Add(market);
			}
		}
	}
}