// <copyright file="ChartViewModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.ViewModels
{
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Windows.Input;
	using LiLo.Lite.Helpers;
	using LiLo.Lite.Models.Markets;
	using LiLo.Lite.Resources;
	using LiLo.Lite.ViewModels.Base;
	using Xamarin.Essentials;
	using Xamarin.Forms;

	/// <summary>Chart view model.</summary>
	[QueryProperty(nameof(Symbol), "symbol")]
	public class ChartViewModel : ViewModelBase
	{
		private readonly string tradingViewString = AppResources.TradingViewPage;
		private MarketModel selectedItem;
		private HtmlWebViewSource tradingViewChart = new HtmlWebViewSource();
		private string symbol;

		/// <summary>Initialises a new instance of the <see cref="ChartViewModel"/> class.</summary>
		public ChartViewModel()
		{
			this.IsBusy = true;
			this.Title = AppResources.ViewTitleChart;
		}

		/// <summary>Gets or sets the selected market item.</summary>
		public MarketModel SelectedItem
		{
			get => this.selectedItem;
			set
			{
				this.selectedItem = value;
				this.OnPropertyChanged(nameof(this.SelectedItem));
				this.TradingViewChart = new HtmlWebViewSource();
			}
		}

		/// <summary>Gets an swipe item Alert command.</summary>
		public ICommand SwipeItemAlertCommand { get; private set; }

		/// <summary>Sets the market symbol.</summary>
		public string Symbol
		{
			set
			{
				this.symbol = Uri.UnescapeDataString(value);
				this.SelectedItem = this.MarketsHelperService.MarketsList.First(m => m.SymbolString == this.symbol);
				this.Title = this.symbol;
				this.IsBusy = false;
			}
		}

		/// <summary>Gets or sets the trading view chart source.</summary>
		public HtmlWebViewSource TradingViewChart
		{
			get => this.tradingViewChart;
			set
			{
				if (this.SelectedItem == null)
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

				string formattedTradingViewString = this.tradingViewString.Replace("X0X", this.SelectedItem.SymbolString);
				formattedTradingViewString = formattedTradingViewString.Replace("X1X", theme == OSAppTheme.Dark ? "dark" : "light");
				formattedTradingViewString = formattedTradingViewString.Replace("X2X", TimeZoneInfo.Local.ToString());
				formattedTradingViewString = formattedTradingViewString.Replace("X3X", CultureInfo.CurrentCulture.IetfLanguageTag.Substring(0, 2));
				formattedTradingViewString = formattedTradingViewString.Replace("X4X", Preferences.Get(Constants.Preferences.Chart.ChartInterval, Constants.Preferences.Chart.ChartIntervalDefaultValue));
				formattedTradingViewString = formattedTradingViewString.Replace("X5X", Preferences.Get(Constants.Preferences.Chart.ChartBarStyle, Constants.Preferences.Chart.ChartBaryDefaultValue));
				formattedTradingViewString = formattedTradingViewString.Replace("X6X", Preferences.Get(Constants.Preferences.Chart.ChartStudyIndicator, Constants.Preferences.Chart.ChartStudyIndicatorDefaultValue));
				formattedTradingViewString = formattedTradingViewString.Replace("X7X", Preferences.Get(Constants.Preferences.Chart.ChartToolBar, Constants.Preferences.Chart.ChartToolBarDefaultValue).ToString().ToLower());
				this.tradingViewChart = new HtmlWebViewSource() { Html = formattedTradingViewString };
				this.OnPropertyChanged(nameof(this.TradingViewChart));
			}
		}
	}
}