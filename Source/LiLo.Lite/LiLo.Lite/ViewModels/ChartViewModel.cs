//-----------------------------------------------------------------------
// <copyright file="ChartViewModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Chart view model.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.ViewModels
{
	using LiLo.Lite.Models.Markets;
	using LiLo.Lite.ViewModels.Base;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Threading.Tasks;

	/// <summary>Chart view model.</summary>
	public class ChartViewModel : ViewModelBase
	{
		/// <summary>Observable list of markets.</summary>
		private ObservableCollection<MarketsModel> marketsList;

		/// <summary>Selected currency</summary>
		private string selectedCurrency;

		/// <summary>View title.</summary>
		private string title = "Chart";

		/// <summary>Initialises a new instance of the <see cref="ChartViewModel"/> class.</summary>
		public ChartViewModel()
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

		public string SelectedCurrency
		{
			get => selectedCurrency;
			set
			{
				selectedCurrency = SelectedCurrency;
				NotifyPropertyChanged(() => SelectedCurrency);
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
		/// <remarks>Re-orders the markets list, so that the swipe is in the correct order starting from the selected symbol!</remarks>
		/// <returns>Base results.</returns>
		public override async Task InitializeAsync(object parameter)
		{
			IsBusy = true;
			await base.InitializeAsync(parameter);
			List<MarketsModel> markets = new List<MarketsModel>();
			string selectedMarket = parameter as string;
			ObservableCollection<MarketsModel> ListOfMarkets = MarketsHelperService.MarketsList;
			MarketsModel selectedItem = ListOfMarkets.Where(m => m.SymbolString == selectedMarket).First();
			selectedCurrency = selectedItem.SymbolString;
			int selectedMarketIndex = ListOfMarkets.IndexOf(selectedItem);
			for(int mi = selectedMarketIndex; mi <= ListOfMarkets.Count-1; mi++)
			{
				markets.Add(ListOfMarkets[mi]);
			}

			for (int mi = 0; mi < selectedMarketIndex; mi++)
			{
				markets.Add(ListOfMarkets[mi]);
			}

			MarketsList = new ObservableCollection<MarketsModel>(markets);
			IsBusy = false;
		}
	}
}