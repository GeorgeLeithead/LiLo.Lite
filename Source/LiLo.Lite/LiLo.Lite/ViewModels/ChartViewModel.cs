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
	using System.Globalization;
	using System.Linq;
	using System.Windows.Input;
	using LiLo.Lite.Models.Markets;
	using LiLo.Lite.ViewModels.Base;
	using Xamarin.Essentials;
	using Xamarin.Forms;

	/// <summary>Chart view model.</summary>
	[QueryProperty("Symbol", "symbol")]
	public class ChartViewModel : ViewModelBase
	{
		/// <summary>Trading View public Widget HTML string.</summary>
		private const string TradingViewString = @"
<html>
<body class=""X1X"">
<style type=""text/css"">
body { margin: 0; }
.dark {
	background-color: black;
	color: white;
}

.light {
	background-color: white;
	color: black;
}
iframe.body {
	-moz-transform:scale(0.75);
	-moz-transform-origin: 0 0;
	-o-transform: scale(0.75);
	-o-transform-origin: 0 0;
	-webkit-transform: scale(0.75);
	-webkit-transform-origin: 0 0;
}
</style>
<!-- TradingView Widget BEGIN -->
<div class=""tradingview-widget-container"">
  <div id=""tradingview_lilo""></div>
  <script type=""text/javascript"" src=""https://s3.tradingview.com/tv.js""></script>
</div>
<script type=""text/javascript"">
	function CreateChart(displaySymbol) {
			new TradingView.widget(
			{
				autosize: true,
				symbol: displaySymbol,
				interval: ""X4X"",
				timezone: ""X2X"",
				theme: ""X1X"",
				locale: ""X3X"",
				enable_publishing: false,
				hide_legend: false,
				save_image: false,
				style: ""X5X"",
				hide_side_toolbar: X7X,
				debug: false,
				preset: ""mobile"",
				studies: [
					""X6X"",
				],
				container_id: ""tradingview_lilo""
			});
	}

	CreateChart('X0X');
</script>
<!-- TradingView Widget END -->
</body>
</html>
";

		private MarketModel selectedItem;
		private HtmlWebViewSource tradingViewChart = new HtmlWebViewSource();

		/// <summary>Initialises a new instance of the <see cref="ChartViewModel"/> class.</summary>
		public ChartViewModel()
		{
			this.IsBusy = true;
			this.SwipeItemAlertCommand = new Command(this.OnSwipeItemAlert);
			this.IsBusy = false;
		}

		/// <summary>Gets or sets the selected market item.</summary>
		public MarketModel SelectedItem
		{
			get => this.selectedItem;
			set
			{
				this.selectedItem = value;
				this.NotifyPropertyChanged(() => this.SelectedItem);
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
				string symbol = Uri.UnescapeDataString(value);
				this.SelectedItem = this.MarketsHelperService.MarketsList.First(m => m.SymbolString == symbol);
				this.Title = symbol;
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

				OSAppTheme theme = OSAppTheme.Light;
				if (Application.Current.UserAppTheme == OSAppTheme.Unspecified)
				{
					theme = Application.Current.RequestedTheme;
				}
				else
				{
					int appTheme = Preferences.Get("Theme", 0);
					theme = (OSAppTheme)appTheme;
				}

				string tradingViewString = TradingViewString.Replace("X0X", $"BINANCE:{this.SelectedItem.SymbolString}USDT");
				tradingViewString = tradingViewString.Replace("X1X", theme == OSAppTheme.Dark ? "dark" : "light");
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