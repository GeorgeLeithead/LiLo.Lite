//-----------------------------------------------------------------------
// <copyright file="GlobalSettings.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Global application settings.
// </summary>
//-----------------------------------------------------------------------

namespace Lilo.Lite
{
	using System;
	using Xamarin.Forms;

	/// <summary>Global application settings.</summary>
	public static class GlobalSettings
	{
		/// <summary>Height of an individual markets list item.</summary>
		public const int MarketsItemHeight = 90;

		/// <summary>Padding of an individual markets list item.</summary>
		public const int MarketsItemHeightPadding = 33;

		/// <summary>Uri to download the LiLo application.</summary>
		public static readonly Uri GetApp = new Uri("https://georgeleithead.github.io/LiLo.Lite/");

		/// <summary>ByBit subscription for anonymous users.</summary>
		public static readonly string InstrumentInfoAnonSubscription = "{\"op\":\"subscribe\",\"args\": [\"instrument_info.100ms.BTCUSD|ETHUSD|EOSUSD|XRPUSD\"]}";

		/// <summary>ByBit WSS for MainNet Real-Time.</summary>
		public static readonly Uri MainNetWss = new Uri("wss://stream.bybit.com/realtime");

		/// <summary>Web view source.</summary>
		public static readonly HtmlWebViewSource TradingViewWebViewSource = new HtmlWebViewSource() { Html = TradingViewString };

		/// <summary>Official twitter account for the LiLo application.</summary>
		public static readonly Uri TwitterUri = new Uri("https://twitter.com/LiLoMobileApp");

		/// <summary>Trading View public Widget HTML string.</summary>
		private const string TradingViewString = @"
<html>
<body class=""XX2XX"">
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
			new TradingView.widget(
			{
				autosize: true,
				symbol: ""BYBIT:XX0XXUSD"",
				interval: ""15"",
				timezone: ""XX1XX"",
				theme: ""XX2XX"",
				locale: ""XX3XX"",
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
</script>
<!-- TradingView Widget END -->
</body>
</html>
";
	}
}