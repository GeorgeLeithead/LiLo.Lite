//-----------------------------------------------------------------------
// <copyright file="HomeView.xaml.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Home page view.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Views
{
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq;
	using System.Threading.Tasks;
	using LiLo.Lite.Models.Markets;
	using LiLo.Lite.ViewModels;
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
		public HomeView() => this.InitializeComponent();

		private HomeViewModel VM => this.vm ??= (HomeViewModel)this.BindingContext;

		/// <inheritdoc/>
		protected override void OnAppearing()
		{
			base.OnAppearing();
			this.searchBar.Unfocus();
			if (this.VM.FavouritesList != Preferences.Get(App.FavouritesCategory, string.Empty) || this.VM.FavouritesEnabled != Preferences.Get("FavouritesEnabled", false))
			{
				// Favourites have changed to we need to close the sockets connection, and re-initialise to as to show the updated markets list.
				this.VM.IsBusy = true;
				this.VM.FavouritesList = Preferences.Get(App.FavouritesCategory, string.Empty);
				this.VM.FavouritesEnabled = Preferences.Get("FavouritesEnabled", false);
				this.VM.SocketsService.WebSocket_OnSleep(); // Sleep the connection
				this.VM.SocketsService.WebSocket_Close(); // Close the connection
				this.VM.Init().ConfigureAwait(false); // Re-initialise the markets and sockets connections.
			}

			if (!string.IsNullOrEmpty(this.VM.Symbol))
			{
				Task.Factory.StartNew(() =>
				{
					// await Task.Delay(500); // This causes a real problem with the app performance!
					MarketModel matchingItem = this.VM.MarketsList.Where(m => m.SymbolString == this.VM.Symbol).FirstOrDefault();
					if (matchingItem != null)
					{
						this.CollectionViewMarketsList.ScrollTo(item: matchingItem, group: null, position: ScrollToPosition.Start, animate: true);
					}
				});
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
				Acr.UserDialogs.PromptResult trulyExit = await this.VM.DialogService.ShowPromptAsync("Exit?", "Are you sure you want to exit the app?", "Yes", "Cancel");
				if (trulyExit.Ok)
				{
					base.OnBackButtonPressed();
					Process.GetCurrentProcess().CloseMainWindow();
					Process.GetCurrentProcess().Close();
				}
			});

			return true;
		}

		/// <inheritdoc/>
		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);
			if (width > height)
			{
				// Landscape mode
				this.VM.GridItemsLayoutSpan = 2;
			}
			else
			{
				// Portrait mode
				this.VM.GridItemsLayoutSpan = 1;
			}
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
			}

			searchTerm = searchTerm.ToUpperInvariant();
			List<MarketModel> originList = this.VM.MarketsHelperService.SourceMarketsList;
			List<MarketModel> filteredMarkets = originList.Where(ol => ol.SymbolString.Contains(searchTerm)).ToList();
			this.VM.MarketsList.Clear();
			foreach (MarketModel market in originList)
			{
				bool matchingMarket = filteredMarkets.Any(fm => fm.SymbolString == market.SymbolString);
				if (matchingMarket)
				{
					this.VM.MarketsList.Add(market);
				}
			}
		}
	}
}