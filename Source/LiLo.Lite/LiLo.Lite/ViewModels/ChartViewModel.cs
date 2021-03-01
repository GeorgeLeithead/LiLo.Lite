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
	using LiLo.Lite.Models.Markets;
	using LiLo.Lite.ViewModels.Base;
	using Xamarin.Forms;

	/// <summary>Chart view model.</summary>
	[QueryProperty("Symbol", "symbol")]
	public class ChartViewModel : ViewModelBase
	{
		private MarketModel selectedItem;
		private HtmlWebViewSource tradingViewChart = new HtmlWebViewSource();

		/// <summary>Trading View public Widget HTML string.</summary>
		private const string TradingViewString = @"
<html>
<body class=""XX1XX"">
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
				interval: ""15"",
				timezone: ""XX0XX"",
				theme: ""XX1XX"",
				locale: ""XX2XX"",
				enable_publishing: false,
				hide_legend: false,
				save_image: false,
				hide_side_toolbar: true,
				debug: false,
				preset: ""mobile"",
				studies: [
					""RSI@tv-basicstudies"",
				],
				container_id: ""tradingview_lilo""
			});
	}

	CreateChart('XX3XX');
</script>
<!-- TradingView Widget END -->
</body>
</html>
";

		/// <summary>Initialises a new instance of the <see cref="ChartViewModel"/> class.</summary>
		public ChartViewModel()
		{
			this.IsBusy = true;
			this.IsBusy = false;
		}

		public string Symbol
		{
			set
			{
				string symbol = Uri.UnescapeDataString(value);
				this.SelectedItem = this.MarketsHelperService.MarketsList.Where(m => m.SymbolString == symbol).First();
				this.Title = symbol;
			}
		}

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

		public HtmlWebViewSource TradingViewChart
		{
			get => this.tradingViewChart;
			set
			{
				if (this.SelectedItem == null)
				{
					return;
				}

				string symbol = $"BINANCE:{this.SelectedItem.SymbolString}USDT";
				string colorTheme = Application.Current.UserAppTheme == OSAppTheme.Dark ? "dark" : "light";
				this.tradingViewChart = new HtmlWebViewSource() { Html = TradingViewString.Replace("XX0XX", TimeZoneInfo.Local.ToString()).Replace("XX1XX", colorTheme).Replace("XX2XX", CultureInfo.CurrentCulture.IetfLanguageTag.Substring(0, 2)).Replace("XX3XX", symbol) };
				this.NotifyPropertyChanged(() => this.TradingViewChart);
			}
		}
	}
}