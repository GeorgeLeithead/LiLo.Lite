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
	using LiLo.Lite.Models.Markets;
	using LiLo.Lite.Models.Provider;
	using LiLo.Lite.Services;
	using LiLo.Lite.ViewModels.Base;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Threading.Tasks;
	using System.Windows.Input;
	using Xamarin.Forms;

	/// <summary>Home view model.</summary>
	public class HomeViewModel : ViewModelBase
	{
		/// <summary>Observable list of markets.</summary>
		private ObservableCollection<MarketsModel> marketsList;

		private ObservableCollection<ProvidersModel> providers;

		public ObservableCollection<ProvidersModel> Providers {
			get => providers;
			set
			{
				if (providers != value)
				{
					providers = value;
					NotifyPropertyChanged(() => Providers);
				}
			}
		}

		/// <summary>View title.</summary>
		private string title = "Markets";

		private string providerName = "";

		/// <summary>Initializes a new instance of the <see cref="HomeViewModel"/> class.</summary>
		public HomeViewModel()
		{
		}

		/// <summary>Gets or sets a collection of values to be displayed in the markets view.</summary>
		public ObservableCollection<MarketsModel> MarketsList
		{
			get => marketsList;
			set
			{
				if (marketsList != value)
				{
					marketsList = value;
					NotifyPropertyChanged(() => MarketsList);
				}
			}
		}

		/// <summary>Gets the command that will be executed when an item is selected.</summary>
		public ICommand TapGestureCommand => new Command<ItemTappedEventArgs>(async (item) => await TapGestureRecognizer_Tapped(item));

		/// <summary>Gets or sets the page title.</summary>
		public string Title
		{
			get => title;
			set
			{
				if (title != value)
				{
					title = value;
					NotifyPropertyChanged(() => Title);
				}
			}
		}

		public string ProviderName
		{
			get => providerName;
			set
			{
				if (providerName != value && !string.IsNullOrEmpty(value))
				{
					providerName = value;
					NotifyPropertyChanged(() => ProviderName);
					Task.Factory.StartNew(async () =>
					{
						DataStore.SetFeed(value);
						await MarketsHelperService.Init();
						MarketsList = MarketsHelperService.MarketsList;
						await SocketsService.WebSocket_OnSleep();
						await SocketsService.Connect();
						await SocketsService.WebSocket_OnResume();
					});
				}
			}
		}

		/// <summary>Initializes the view model.</summary>
		/// <returns>Base results.</returns>
		public override async Task InitializeAsync(object parameter)
		{
			IsBusy = true;
			await base.InitializeAsync(parameter);
			MarketsList = MarketsHelperService.MarketsList;
			Providers = new ObservableCollection<ProvidersModel>(DataStore.Providers);
			ProviderName = (Providers.First(p => p.IsSelected)).Provider;
			//await SocketsService.WebSocket_OnResume();
			IsBusy = false;
		}

		/// <summary>Changes the markets item selected and resets the order view if necessary.</summary>
		/// <param name="e">Item tapped.</param>
		/// <returns>Async task result.</returns>
		private async Task TapGestureRecognizer_Tapped(ItemTappedEventArgs e)
		{
			// new market selected, so reset everything on the orders view.
			MarketsModel selectedmarket = e.Item as MarketsModel;
			await NavigationService.NavigateToAsync<ChartViewModel>(selectedmarket.SymbolString);
		}
	}
}