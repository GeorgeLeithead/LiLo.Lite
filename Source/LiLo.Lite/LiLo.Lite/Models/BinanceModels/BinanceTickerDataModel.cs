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
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Text.Json.Serialization;
	using System.Threading.Tasks;
	using LiLo.Lite.Models.Markets;

	/// <summary>Binance ticker symbol stream data.</summary>
	public class BinanceTickerDataModel
	{
		private string symbolString;

		[JsonPropertyName("e")]
		public string EventType { get; set; }

		[JsonPropertyName("E")]
		public long EventTime { get; set; }

		[JsonPropertyName("s")]
		public string Symbol
		{
			get => symbolString;
			set => symbolString = value;
		}

		public string SymbolString {
			get => symbolString;
		}

		[JsonPropertyName("p")]
		public string PriceChange { get; set; }

		[JsonPropertyName("P")]
		public string P { get; set; }

		public double Price24hPercent
		{
			get => Convert.ToDouble(P);
		}

		[JsonPropertyName("w")]
		public string WeightedAveragePrice { get; set; }

		/// <summary>First Trade(f)-1 price (first trade before the 24HR rolling window)</summary>
		[JsonPropertyName("x")]
		public string FirstTradeprice { get; set; }

		[JsonPropertyName("c")]
		public string c { get; set; }

		public double LastPrice
		{
			get => Convert.ToDouble(c);
		}

		[JsonPropertyName("Q")]
		public string LastQuantity { get; set; }

		[JsonPropertyName("b")]
		public string BestBidPrice { get; set; }

		[JsonPropertyName("B")]
		public string BestBidQuantity { get; set; }

		[JsonPropertyName("a")]
		public string BestAskPrice { get; set; }

		[JsonPropertyName("A")]
		public string BestAskQuantity { get; set; }

		[JsonPropertyName("o")]
		public string OpenPrice { get; set; }

		[JsonPropertyName("h")]
		public string HighPrice { get; set; }

		public double HighPrice24h
		{
			get => Convert.ToDouble(HighPrice);
		}

		[JsonPropertyName("l")]
		public string LowPrice { get; set; }

		public double LowPrice24h
		{
			get => Convert.ToDouble(LowPrice);
		}

		/// <summary>Total traded base asset volume</summary>
		[JsonPropertyName("v")]
		public string Volume { get; set; }

		public long Volume24hr
		{
			get => Convert.ToInt32(Volume);
		}

		[JsonPropertyName("q")]
		public string TotalTradedQuoteAssetVolume { get; set; }

		[JsonPropertyName("O")]
		public long StatisticsOpenTime { get; set; }

		[JsonPropertyName("C")]
		public long StatisticsCloseTime { get; set; }

		[JsonPropertyName("F")]
		public int FirstTradeId { get; set; }

		[JsonPropertyName("L")]
		public int LastTradeId { get; set; }

		[JsonPropertyName("n")]
		public int NumberOftrades { get; set; }

		public static async Task UpdateMarketList(BinanceTickerDataModel data, ObservableCollection<MarketsModel> marketsList)
		{
			if (data is null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			MarketsModel clientItem = marketsList.SingleOrDefault(nl => nl.SymbolString == data.SymbolString);
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

			/*
			if (data.Volume24hr != 0)
			{
				clientItem.Turnover24h = data.Volume24hr;
			}
			*/
		}

	}
}
