// <copyright file="HomeViewModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.ViewModels
{
	using LiLo.Lite.Helpers;
	using LiLo.Lite.Models.Markets;
	using LiLo.Lite.Resources;
	using LiLo.Lite.ViewModels.Base;
	using System;
	using System.Net.Http;
	using System.Threading.Tasks;
	using System.Windows.Input;
	using Xamarin.CommunityToolkit.ObjectModel;
	using Xamarin.Essentials;
	using Xamarin.Forms;

	/// <summary>Home view model.</summary>
	[QueryProperty(nameof(Symbol), "symbol")]
	public class HomeViewModel : ViewModelBase
	{
		private IAsyncCommand goToSettingsCommand;
		private int gridItemsLayoutSpan = 1;

		private bool isSearchVisible = false;

		/// <summary>Observable list of markets.</summary>
		private ObservableRangeCollection<MarketModel> marketsList;

		private string symbol;

		/// <summary>Initialises a new instance of the <see cref="HomeViewModel"/> class.</summary>
		public HomeViewModel()
		{
			IsBusy = true;
			Title = AppResources.ViewTitleMarkets;
			FavouritesList = Preferences.Get(Constants.Preferences.Favourites.FavouritesCategory, Constants.Preferences.Favourites.FavouritesCategoryDefaultValue);
			FavouritesEnabled = Preferences.Get(Constants.Preferences.Favourites.FavouritesEnabled, Constants.Preferences.Favourites.FavouritesEnabledDefaultValue);
			RetryButtonClicked = new AsyncCommand(Init);
			SwipeItemAlertCommand = new Command<MarketModel>(OnSwipeItemAlert);
			ShowSearchCommand = new Command(ShowSearch);
			_ = Init().ConfigureAwait(false);
		}

		/// <summary>Gets or sets a value indicating whether the favourites is enabled.</summary>
		public bool FavouritesEnabled { get; set; }

		/// <summary>Gets or sets the users favourites list.</summary>
		public string FavouritesList { get; set; }

		/// <summary>Gets the navigate to settings command.</summary>
		public IAsyncCommand GoToSettingsCommand => goToSettingsCommand ??= new AsyncCommand(GoToSettings);

		/// <summary>Gets or sets the items layout span.</summary>
		/// <remarks>To handle landscape and portrait orientation.</remarks>
		public int GridItemsLayoutSpan
		{
			get => gridItemsLayoutSpan;
			set
			{
				if (value != gridItemsLayoutSpan)
				{
					gridItemsLayoutSpan = value;
					OnPropertyChanged(nameof(GridItemsLayoutSpan));
				}
			}
		}

		/// <summary>Gets or sets the search visibility.</summary>
		public bool IsSearchVisible
		{
			get => isSearchVisible;
			set
			{
				if (value != isSearchVisible)
				{
					isSearchVisible = value;
					OnPropertyChanged(nameof(IsSearchVisible));
				}
			}
		}

		/// <summary>Gets or sets a collection of values to be displayed in the markets view.</summary>
		public ObservableRangeCollection<MarketModel> MarketsList
		{
			get => marketsList;
			set
			{
				if (marketsList != value)
				{
					marketsList = value;
					OnPropertyChanged(nameof(MarketsList));
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
					OnPropertyChanged(nameof(SelectedItem));
				}
			}
		}

		/// <summary>Gets a show search command.</summary>
		public ICommand ShowSearchCommand { get; private set; }

		/// <summary>Gets an swipe item Alert command.</summary>
		public ICommand SwipeItemAlertCommand { get; private set; }

		/// <summary>Gets or sets the market symbol.</summary>
		public string Symbol
		{
			get => symbol;
			set
			{
				if (!string.IsNullOrEmpty(value))
				{
					symbol = Uri.UnescapeDataString(value);
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
						  await MarketsHelperService.Init();
						  _ = SocketsService?.Connect();
						  MarketsList = MarketsHelperService.MarketsList;
					  }
					  catch (HttpRequestException ex)
					  {
						  _ = DialogService.ShowAlertAsync(ex.Message, AppResources.TitleMarketsListError, AppResources.DismissButton);
					  }
				  }
				  else
				  {
					  _ = DialogService.ShowAlertAsync(AppResources.ErrorNoNetwork, AppResources.TitleNetworkError, AppResources.DismissButton);
				  }

				  if (!string.IsNullOrEmpty(Symbol))
				  {
					  OnPropertyChanged(nameof(Symbol));
				  }

				  IsBusy = false;
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

		private void ShowSearch()
		{
			IsSearchVisible = !isSearchVisible;
		}
	}
}