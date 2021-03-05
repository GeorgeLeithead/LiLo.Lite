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
		private int gridItemsLayoutSpan = 1;

		/// <summary>Observable list of markets.</summary>
		private ObservableRangeCollection<MarketModel> marketsList;

		private string symbol;

		/// <summary>Initialises a new instance of the <see cref="HomeViewModel"/> class.</summary>
		public HomeViewModel()
		{
			this.IsBusy = true;
			this.Title = "Markets";
			this.RetryButtonClicked = new Command(() => this.Init());
			this.Init();
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
		public ICommand RetryButtonClicked { get; set; }

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

		/// <summary>Gets or sets the market symbol.</summary>
		public string Symbol
		{
			get => this.symbol;
			set
			{
				this.symbol = Uri.UnescapeDataString(value);
			}
		}

		/// <summary>Initialise the home view model.</summary>
		private void Init()
		{
			NetworkAccess current = Connectivity.NetworkAccess;
			if (current == NetworkAccess.Internet)
			{
				// Connection to internet is available
				try
				{
					this.MarketsHelperService.Init();
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
		}
	}
}