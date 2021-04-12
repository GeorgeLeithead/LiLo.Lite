//-----------------------------------------------------------------------
// <copyright file="HomeViewModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Home view model.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.ViewModels
{
	using System;
	using System.Net.Http;
	using System.Threading.Tasks;
	using System.Windows.Input;
	using LiLo.Lite.Models.Markets;
	using LiLo.Lite.ViewModels.Base;
	using Xamarin.CommunityToolkit.ObjectModel;
	using Xamarin.Essentials;
	using Xamarin.Forms;

	/// <summary>Home view model.</summary>
	[QueryProperty("Symbol", "symbol")]
	public class HomeViewModel : ViewModelBase
	{
		/// <summary>Indicates whether the favourites was enabled or not.</summary>
		private bool favouritesEnabled;

		/// <summary>List of favourites.</summary>
		private string favouritesList;

		private int gridItemsLayoutSpan = 1;

		/// <summary>Observable list of markets.</summary>
		private ObservableRangeCollection<MarketModel> marketsList;

		private string symbol;

		/// <summary>Initialises a new instance of the <see cref="HomeViewModel"/> class.</summary>
		public HomeViewModel()
		{
			this.IsBusy = true;
			this.Title = "Markets";
			this.FavouritesList = Preferences.Get(App.FavouritesCategory, string.Empty);
			this.FavouritesEnabled = Preferences.Get("FavouritesEnabled", false);
			this.RetryButtonClicked = new AsyncCommand(this.Init);
			this.SwipeItemAlertCommand = new Command<MarketModel>(this.OnSwipeItemAlert);
			this.Init().ConfigureAwait(false);
		}

		/// <summary>Gets or sets a value indicating whether the favourites is enabled.</summary>
		public bool FavouritesEnabled
		{
			get => this.favouritesEnabled;
			set => this.favouritesEnabled = value;
		}

		/// <summary>Gets or sets the users favourites list.</summary>
		public string FavouritesList
		{
			get => this.favouritesList;
			set => this.favouritesList = value;
		}

		/// <summary>Gets or sets the items layout span.</summary>
		/// <remarks>To handle landscape and portrait orientation.</remarks>
		public int GridItemsLayoutSpan
		{
			get => this.gridItemsLayoutSpan;
			set
			{
				if (value != this.gridItemsLayoutSpan)
				{
					this.gridItemsLayoutSpan = value;
					this.NotifyPropertyChanged(() => this.GridItemsLayoutSpan);
				}
			}
		}

		/// <summary>Gets or sets a collection of values to be displayed in the markets view.</summary>
		public ObservableRangeCollection<MarketModel> MarketsList
		{
			get => this.marketsList;
			set
			{
				if (this.marketsList != value)
				{
					this.marketsList = value;
					this.NotifyPropertyChanged(() => this.MarketsList);
				}
			}
		}

		/// <summary>Gets or sets the retry button command.</summary>
		public IAsyncCommand RetryButtonClicked { get; set; }

		/// <summary>Gets or sets the selected item.</summary>
		public MarketModel SelectedItem
		{
			get => null;
			set
			{
				if (value != null)
				{
					MarketModel item = value;
					Shell.Current.GoToAsync($"//Chart?symbol={item.SymbolString}");
					this.NotifyPropertyChanged(() => this.SelectedItem);
				}
			}
		}

		/// <summary>Gets an swipe item Alert command.</summary>
		public ICommand SwipeItemAlertCommand { get; private set; }

		/// <summary>Gets or sets the market symbol.</summary>
		public string Symbol
		{
			get => this.symbol;
			set
			{
				if (!string.IsNullOrEmpty(value))
				{
					this.symbol = Uri.UnescapeDataString(value);
				}
			}
		}

		/// <summary>Initialise the home view model.</summary>
		/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
		public async Task Init()
		{
			await Task.Factory.StartNew(async () =>
			{
				NetworkAccess current = Connectivity.NetworkAccess;
				if (current == NetworkAccess.Internet)
				{
					// Connection to internet is available
					try
					{
						await this.MarketsHelperService.Init();
						this.SocketsService?.Connect();
						this.MarketsList = this.MarketsHelperService.MarketsList;
					}
					catch (HttpRequestException ex)
					{
						_ = this.DialogService.ShowAlertAsync(ex.Message, "Markets list error", "Dismiss");
					}
				}
				else
				{
					_ = this.DialogService.ShowAlertAsync("No network access!", "Network error", "Dismiss");
				}

				this.IsBusy = false;
				if (!string.IsNullOrEmpty(this.Symbol))
				{
					this.NotifyPropertyChanged(() => this.Symbol);
				}
			});
		}

		/// <summary>Market Model item has been swiped and Alert selected.</summary>
		/// <param name="item">{MarketModel} item.</param>
		private void OnSwipeItemAlert(MarketModel item)
		{
			// TODO: Implement the ability to set alerts for market items
			_ = this.DialogService.ShowAlertAsync($"Local alerts coming soon for {item.SymbolString}.", "Alerts", "Dismiss");
		}
	}
}