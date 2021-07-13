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

				Theme theme = Theme.Light;
				if (Application.Current.UserAppTheme == OSAppTheme.Unspecified)
				{
					theme = Application.Current.RequestedTheme;
				}
				else
				{
					int appTheme = Preferences.Get("Theme", 0);
					appTheme--;
					theme = (Theme)appTheme;
				}

				string tradingViewString = TradingViewString.Replace("X0X", $"BINANCE:{this.SelectedItem.SymbolString}USDT");
				tradingViewString = tradingViewString.Replace("X1X", theme == Theme.Dark ? "dark" : "light");
				tradingViewString = tradingViewString.Replace("X2X", TimeZoneInfo.Local.ToString());
				tradingViewString = tradingViewString.Replace("X3X", CultureInfo.CurrentCulture.IetfLanguageTag.Substring(0, 2));
				tradingViewString = tradingViewString.Replace("X4X", Preferences.Get("ChartInterval", "15"));
				tradingViewString = tradingViewString.Replace("X5X", Preferences.Get("ChartBarStyle", "1"));
				tradingViewString = tradingViewString.Replace("X6X", Preferences.Get("ChartStudyIndicator", "RSI@tv-basicstudies"));
				tradingViewString = tradingViewString.Replace("X7X", Preferences.Get("ChartToolBar", true).ToString().ToLower());

				this.tradingViewChart = new HtmlWebViewSource() { Html = tradingViewString };
				this.NotifyPropertyChanged(() => this.TradingViewChart);
			}
		}

		/// <summary>Item has been swiped and Alert selected.</summary>
		private void OnSwipeItemAlert()
		{
			// TODO: Implement the ability to set alerts for market items
			MarketModel item = this.SelectedItem;
			_ = Shell.Current.GoToAsync($"//Alerts?symbol={item.SymbolString}");
		}
	}
}