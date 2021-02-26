//-----------------------------------------------------------------------
// <copyright file="Ticker.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Binance ticker symbol stream.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Models.BinanceModels
{
	using System.Text.Json.Serialization;

	/// <summary>Binance ticker symbol stream.</summary>
	public class BinanceTickerModel
	{
		[JsonPropertyName("data")]
		public BinanceTickerDataModel Data { get; set; }

		[JsonPropertyName("stream")]
		public string Stream { get; set; }
	}
}