//-----------------------------------------------------------------------
// <copyright file="Data.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Binance ticker symbol stream data.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Models.BinanceModels
{
	using System;
	using System.Linq;
	using System.Text.Json.Serialization;
	using System.Threading.Tasks;
	using LiLo.Lite.Models.Markets;
	using Xamarin.CommunityToolkit.ObjectModel;

	/// <summary>Binance ticker symbol stream data.</summary>
	public class BinanceTickerDataModel
	{
		[JsonPropertyName("c")]
		public string CurrentPrice { get; set; }

		[JsonPropertyName("h")]
		public string HighPrice { get; set; }

		public double HighPrice24h => Convert.ToDouble(this.HighPrice);

		public double LastPrice => Convert.ToDouble(this.CurrentPrice);

		[JsonPropertyName("l")]
		public string LowPrice { get; set; }

		public double LowPrice24h => Convert.ToDouble(this.LowPrice);

		[JsonPropertyName("P")]
		public string Percent { get; set; }

		public double Price24hPercent => Convert.ToDouble(this.Percent);

		[JsonPropertyName("s")]
		public string SymbolString { get; set; }

		public static async Task UpdateMarketList(BinanceTickerDataModel data, ObservableRangeCollection<MarketModel> marketsList)
		{
			if (data is null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			MarketModel clientItem = marketsList.SingleOrDefault(nl => (nl.SymbolString + "USDT") == data.SymbolString);
			if (clientItem == null)
			{
				await Task.FromResult(true);
				return;
			}

			if (data.LastPrice != 0)
			{
				clientItem.LastPrice = data.LastPrice;
			}

			if (data.Price24hPercent != 0)
			{
				clientItem.Price24hPercent = data.Price24hPercent;
			}

			if (data.LowPrice24h != 0)
			{
				clientItem.LowPrice24h = data.LowPrice24h;
			}

			if (data.HighPrice24h != 0)
			{
				clientItem.HighPrice24h = data.HighPrice24h;
			}
		}
	}
}