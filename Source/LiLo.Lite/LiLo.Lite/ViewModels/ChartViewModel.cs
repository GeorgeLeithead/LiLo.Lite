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
	using System;
	using System.Collections.ObjectModel;
	using System.Globalization;
	using System.Threading.Tasks;
	using System.Windows.Input;
	using Lilo.Lite;
	using LiLo.Lite.Models.Markets;
	using LiLo.Lite.ViewModels.Base;
	using Xamarin.Forms;

	/// <summary>Chart view model.</summary>
	public class ChartViewModel : ViewModelBase
	{
		/// <summary>Observable list of markets.</summary>
		private ObservableCollection<MarketsModel> marketsList;

		/// <summary>View title.</summary>
		private string title = "Chart";

		/// <summary>Initialises a new instance of the <see cref="ChartViewModel"/> class.</summary>
		public ChartViewModel()
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

		/// <summary>Gets a markets TradingView web view.</summary>
		public HtmlWebViewSource MarketWebView
		{
			get
			{
				string htmlSource = GlobalSettings.TradingViewWebViewSource.Html.Replace("XX0XX", SettingsService.SymbolString).Replace("XX1XX", TimeZoneInfo.Local.ToString()).Replace("XX2XX", SettingsService.ThemeOption.ToString().ToLowerInvariant()).Replace("XX3XX", CultureInfo.CurrentCulture.IetfLanguageTag.Substring(0, 2));
				var htmlViewSource = new HtmlWebViewSource() { Html = htmlSource };
				return htmlViewSource;
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
				item.IsVisible = item.SymbolString == SettingsService.SymbolString;
			}

			MarketsList = data;
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
			await NavigationService.NavigateToAsync<HomeViewModel>();
		}
	}
}