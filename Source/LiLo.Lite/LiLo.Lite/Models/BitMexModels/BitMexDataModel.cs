//-----------------------------------------------------------------------
// <copyright file="BitMexDataModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   BitMex data model.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Models.BitMexModels
{
	using LiLo.Lite.Models.Markets;
	using System;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Text.Json.Serialization;
	using System.Threading.Tasks;

	/// <summary>BitMex data model.</summary>
	public class BitMexDataModel
	{
		private string symbolString;

		[JsonPropertyName("symbol")]
		public string Symbol
		{
			get => symbolString;
			set => symbolString = value;
		}

		public string SymbolString => symbolString;

		[JsonPropertyName("quoteCurrency")]
		public string QuoteCurrency { get; set; }

		[JsonPropertyName("maxOrderQty")]
		public double? MaxOrderQty { get; set; }

		[JsonPropertyName("maxPrice")]
		public float? MaxPrice { get; set; }

		[JsonPropertyName("tickSize")]
		public float? TickSize { get; set; }

		[JsonPropertyName("turnover24h")]
		public long Turnover24h { get; set; }

		[JsonPropertyName("highPrice")]
		public double HighPrice24h { get; set; }

		[JsonPropertyName("lowPrice")]
		public double LowPrice24h { get; set; }

		[JsonPropertyName("lastPrice")]
		public double LastPrice { get; set; }

		[JsonPropertyName("lastTickDirection")]
		public string LastTickDirection { get; set; }

		[JsonPropertyName("lastChangePcnt")]
		public double LastChangePcnt { get; set; }

		[JsonPropertyName("markPrice")]
		public float? MarkPrice { get; set; }

		public static async Task UpdateMarketList(BitMexDataModel data, ObservableCollection<MarketsModel> marketsList)
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

			if (data.LastChangePcnt != 0)
			{
				clientItem.Price24hPercent = data.LastChangePcnt;
			}

			if (data.LowPrice24h != 0)
			{
				clientItem.LowPrice24h = data.LowPrice24h;
			}

			if (data.HighPrice24h != 0)
			{
				clientItem.HighPrice24h = data.HighPrice24h;
			}

			if (!string.IsNullOrEmpty(data.LastTickDirection))
			{
				clientItem.LastTickDirection = data.LastTickDirection;
			}

			if (data.Turnover24h != 0)
			{
				clientItem.Turnover24h = data.Turnover24h;
			}
		}
	}
}