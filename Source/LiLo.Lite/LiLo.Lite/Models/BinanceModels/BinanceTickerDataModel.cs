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
	using LiLo.Lite.Models.Markets;
	using System;
	using System.Linq;
	using System.Text.Json.Serialization;
	using System.Threading.Tasks;
	using Xamarin.CommunityToolkit.ObjectModel;

	/// <summary>Binance ticker symbol stream data.</summary>
	public class BinanceTickerDataModel
	{
		private string symbolString;

		[JsonPropertyName("s")]
		public string SymbolString
		{
			get => symbolString;
			set => symbolString = value;
		}

		[JsonPropertyName("P")]
		public string Percent { get; set; }

		public double Price24hPercent
		{
			get => Convert.ToDouble(Percent);
		}

		[JsonPropertyName("c")]
		public string CurrentPrice { get; set; }

		public double LastPrice
		{
			get => Convert.ToDouble(CurrentPrice);
		}

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

		public static async Task UpdateMarketList(BinanceTickerDataModel data, ObservableRangeCollection<MarketsModel> marketsList)
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
		}

	}
}
