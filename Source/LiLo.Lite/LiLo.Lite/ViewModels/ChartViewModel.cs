// <copyright file="ChartViewModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.ViewModels
{
	using LiLo.Lite.Helpers;
	using LiLo.Lite.Models.Markets;
	using LiLo.Lite.Resources;
	using LiLo.Lite.ViewModels.Base;
	using System;
	using System.Globalization;
	using System.Linq;
	using Xamarin.CommunityToolkit.ObjectModel;
	using Xamarin.Essentials;
	using Xamarin.Forms;

	/// <summary>Chart view model.</summary>
	[QueryProperty(nameof(Symbol), "symbol")]
	public class ChartViewModel : ViewModelBase
	{
		private readonly string tradingViewString = AppResources.TradingViewPage;
		private ObservableRangeCollection<MarketModel> marketsList;
		private HtmlWebViewSource tradingViewChart = new();

		/// <summary>Initialises a new instance of the <see cref="ChartViewModel"/> class.</summary>
		public ChartViewModel()
		{
			IsBusy = true;
			Title = AppResources.ViewTitleChart;
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

		/// <summary>Sets the market symbol.</summary>
		public string Symbol
		{
			set
			{
				string symbol = Uri.UnescapeDataString(value);
				MarketModel selectedItem = MarketsHelperService.MarketsList.First(m => m.SymbolString == symbol);
				Title = selectedItem.DisplayName ?? symbol;
				marketsList = new ObservableRangeCollection<MarketModel>() { selectedItem };
				TradingViewChart = new HtmlWebViewSource();
				OnPropertyChanged(nameof(MarketsList));
				IsBusy = false;
			}
		}

		/// <summary>Gets or sets the trading view chart source.</summary>
		public HtmlWebViewSource TradingViewChart
		{
			get => tradingViewChart;
			set
			{
				if (MarketsList.Count == 0)
				{
					return;
				}

				OSAppTheme theme;
				if (Application.Current.UserAppTheme == OSAppTheme.Unspecified)
				{
					theme = Application.Current.RequestedTheme;
				}
				else
				{
					int appTheme = Preferences.Get(Constants.Preferences.Settings.Theme, Constants.Preferences.Settings.ThemeDefaultValue);
					theme = (OSAppTheme)appTheme;
				}

				MarketModel selectedItem = MarketsList.First();
				string formattedTradingViewString = tradingViewString.Replace("X0X", selectedItem.SymbolString);
				formattedTradingViewString = formattedTradingViewString.Replace("X1X", theme == OSAppTheme.Dark ? "dark" : "light");
				formattedTradingViewString = formattedTradingViewString.Replace("X2X", TimeZoneInfo.Local.ToString());
				formattedTradingViewString = formattedTradingViewString.Replace("X3X", CultureInfo.CurrentCulture.IetfLanguageTag[..2]);
				formattedTradingViewString = formattedTradingViewString.Replace("X4X", Preferences.Get(Constants.Preferences.Chart.ChartInterval, Constants.Preferences.Chart.ChartIntervalDefaultValue));
				formattedTradingViewString = formattedTradingViewString.Replace("X5X", Preferences.Get(Constants.Preferences.Chart.ChartBarStyle, Constants.Preferences.Chart.ChartBaryDefaultValue));
				formattedTradingViewString = formattedTradingViewString.Replace("X6X", Preferences.Get(Constants.Preferences.Chart.ChartStudyIndicator, Constants.Preferences.Chart.ChartStudyIndicatorDefaultValue));
				formattedTradingViewString = formattedTradingViewString.Replace("X7X", Preferences.Get(Constants.Preferences.Chart.ChartToolBar, Constants.Preferences.Chart.ChartToolBarDefaultValue).ToString().ToLower());
				tradingViewChart = new HtmlWebViewSource() { Html = formattedTradingViewString };
				OnPropertyChanged(nameof(TradingViewChart));
			}
		}
	}
}