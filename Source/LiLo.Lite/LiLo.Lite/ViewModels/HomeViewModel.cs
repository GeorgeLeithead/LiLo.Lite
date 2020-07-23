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
	using System.Collections.ObjectModel;
	using System.Threading.Tasks;
	using System.Windows.Input;
	using LiLo.Lite.Models.Markets;
	using LiLo.Lite.ViewModels.Base;
	using Xamarin.Forms;

	/// <summary>Home view model.</summary>
	public class HomeViewModel : ViewModelBase
	{
		/// <summary>Observable list of markets.</summary>
		private ObservableCollection<MarketsModel> marketsList;

		/// <summary>View title.</summary>
		private string title = "Markets";

		/// <summary>Initializes a new instance of the <see cref="HomeViewModel"/> class.</summary>
		public HomeViewModel()
		{
		}

		/// <summary>Gets the command that will be executed when an item is selected.</summary>
		public ICommand ListViewItemTappedCommand => new Command<ItemTappedEventArgs>(async (item) => await ListViewItemTappedCommandAsync(item));

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

		/// <summary>Initializes the view model.</summary>
		/// <returns>Base results.</returns>
		public override async Task InitializeAsync()
		{
			IsBusy = true;
			await base.InitializeAsync();
			var data = new ObservableCollection<MarketsModel>(MarketsHelperService.MarketsList);
			foreach (MarketsModel item in data)
			{
				item.IsVisible = true;
			}

			MarketsList = data;
			await SocketsService.WebSocket_OnResume();
			IsBusy = false;
		}

		/// <summary>Changes the markets item selected and resets the order view if necessary.</summary>
		/// <param name="e">List View item.</param>
		/// <returns>Async task result.</returns>
		private async Task ListViewItemTappedCommandAsync(ItemTappedEventArgs e)
		{
			// new market selected, so reset everything on the orders view.
			MarketsModel selectedmarket = e.Item as MarketsModel;
			SettingsService.SymbolString = selectedmarket.SymbolString;
			await NavigationService.NavigateToAsync<ChartViewModel>();
		}
	}
}