// <copyright file="HomeViewModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.ViewModels
{
	using System;
	using System.Net.Http;
	using System.Threading.Tasks;
	using System.Windows.Input;
	using LiLo.Lite.Helpers;
	using LiLo.Lite.Models.Markets;
	using LiLo.Lite.Resources;
	using LiLo.Lite.ViewModels.Base;
	using Xamarin.CommunityToolkit.ObjectModel;
	using Xamarin.Essentials;
	using Xamarin.Forms;

	/// <summary>Home view model.</summary>
	[QueryProperty(nameof(Symbol), "symbol")]
	public class HomeViewModel : ViewModelBase
	{
		private IAsyncCommand goToSettingsCommand;
		private int gridItemsLayoutSpan = 1;

		/// <summary>Observable list of markets.</summary>
		private ObservableRangeCollection<MarketModel> marketsList;

		private string symbol;

		/// <summary>Initialises a new instance of the <see cref="HomeViewModel"/> class.</summary>
		public HomeViewModel()
		{
			this.IsBusy = true;
			this.Title = AppResources.ViewTitleMarkets;
			this.FavouritesList = Preferences.Get(Constants.Preferences.Favourites.FavouritesCategory, Constants.Preferences.Favourites.FavouritesCategoryDefaultValue);
			this.FavouritesEnabled = Preferences.Get(Constants.Preferences.Favourites.FavouritesEnabled, Constants.Preferences.Favourites.FavouritesEnabledDefaultValue);
			this.RetryButtonClicked = new AsyncCommand(this.Init);
			this.SwipeItemAlertCommand = new Command<MarketModel>(this.OnSwipeItemAlert);
			_ = this.Init().ConfigureAwait(false);
		}

		/// <summary>Gets or sets a value indicating whether the favourites is enabled.</summary>
		public bool FavouritesEnabled { get; set; }

		/// <summary>Gets or sets the users favourites list.</summary>
		public string FavouritesList { get; set; }

		/// <summary>Gets the navigate to settings command.</summary>
		public IAsyncCommand GoToSettingsCommand => this.goToSettingsCommand ??= new AsyncCommand(this.GoToSettings);

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
					this.OnPropertyChanged(nameof(this.GridItemsLayoutSpan));
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
					this.OnPropertyChanged(nameof(this.MarketsList));
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
					_ = Shell.Current.GoToAsync($"{Constants.Navigation.Paths.Chart}?symbol={item.SymbolString}");
					this.OnPropertyChanged(nameof(this.SelectedItem));
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
			_ = await Task.Factory.StartNew(async () =>
			  {
				  NetworkAccess current = Connectivity.NetworkAccess;
				  if (current == NetworkAccess.Internet)
				  {
					  // Connection to internet is available
					  try
					  {
						  await this.MarketsHelperService.Init();
						  _ = this.SocketsService?.Connect();
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
					  this.OnPropertyChanged(nameof(this.Symbol));
				  }
			  });
		}

		private async Task GoToSettings()
		{
			await Shell.Current.GoToAsync(Constants.Navigation.Paths.Settings);
		}

		/// <summary>Market Model item has been swiped and Alert selected.</summary>
		/// <param name="item">{MarketModel} item.</param>
		private void OnSwipeItemAlert(MarketModel item)
		{
			_ = Shell.Current.GoToAsync($"{Constants.Navigation.Paths.Alert}?symbol={item.SymbolString}");
		}
	}
}