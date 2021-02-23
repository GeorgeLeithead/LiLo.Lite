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
	using LiLo.Lite.ViewModels.Base;
	using Xamarin.CommunityToolkit.ObjectModel;
	using Xamarin.Forms;

	/// <summary>Home view model.</summary>
	public class HomeViewModel : ViewModelBase
	{
		/// <summary>Observable list of markets.</summary>
		private ObservableRangeCollection<MarketsModel> marketsList;

		/// <summary>Initializes a new instance of the <see cref="HomeViewModel"/> class.</summary>
		public HomeViewModel()
		{
			this.IsBusy = true;
			this.Title = "Markets";
			this.MarketsHelperService.Init();
			this.MarketsList = this.MarketsHelperService.MarketsList;
			this.IsBusy = false;
		}

		/// <summary>Gets or sets a collection of values to be displayed in the markets view.</summary>
		public ObservableRangeCollection<MarketsModel> MarketsList
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

		/// <summary>Sets selected item.</summary>
		public MarketsModel SelectedItem
		{
			get => null;
			set
			{
				if (value != null)
				{
					MarketsModel item = value;
					Shell.Current.GoToAsync($"//Chart?symbol={item.SymbolString}");
					this.NotifyPropertyChanged(() => this.SelectedItem);
				}
			}
		}
	}
}