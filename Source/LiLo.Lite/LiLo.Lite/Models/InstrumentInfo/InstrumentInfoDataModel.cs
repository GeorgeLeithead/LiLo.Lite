//-----------------------------------------------------------------------
// <copyright file="InstrumentInfoDataModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   ByBit instrument information data model.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Models.InstrumentInfo
{
	using System;
	using System.Text.Json.Serialization;

	/// <summary>ByBit instrument information data model.</summary>
	public class InstrumentInfoDataModel
	{
		/// <summary>24HR high price</summary>
		private double highPrice24h;

		/// <summary>Last price</summary>
		private double lastPrice;

		/// <summary>24HR low price</summary>
		private double lowPrice24h;

		/// <summary>1HR price percentage</summary>
		private double price1hPercent;

		/// <summary>24HR price percentage</summary>
		private double price24hPercent;

		/// <summary>24HR turnover</summary>
		private long turnover24h;

		/// <summary>Gets or sets Countdown hour</summary>
		[JsonPropertyName("countdown_hour")]
		public int CountDownHour { get; set; }

		/// <summary>Gets or sets Created at</summary>
		[JsonPropertyName("created_at")]
		public DateTime CreatedAt { get; set; }

		/// <summary>Gets or sets Cross sequence</summary>
		[JsonPropertyName("cross_seq")]
		public int CrossSequence { get; set; }

		/// <summary>Gets or sets Funding rate (E6 format)</summary>
		[JsonPropertyName("funding_rate_e6")]
		public int FundingRate { get; set; }

		/// <summary>Gets or sets 24HR high price</summary>
		[JsonPropertyName("high_price_24h_e4")]
		public double HighPrice24h
		{
			get => highPrice24h;
			set => highPrice24h = value / 1E4;
		}

		/// <summary>Gets or sets Unique Identifier</summary>
		[JsonPropertyName("id")]
		public int Id { get; set; }

		/// <summary>Gets or sets Index price (E4 format)</summary>
		[JsonPropertyName("index_price_e4")]
		public int IndexPrice { get; set; }

		/// <summary>Gets or sets Last price (E4 format)</summary>
		[JsonPropertyName("last_price_e4")]
		public double LastPrice
		{
			get => lastPrice;
			set => lastPrice = value / 1E4;
		}

		/// <summary>Gets or sets Last tick direction</summary>
		[JsonPropertyName("last_tick_direction")]
		public string LastTickDirection { get; set; }

		/// <summary>Gets or sets 24HR low price (E4 format)</summary>
		[JsonPropertyName("low_price_24h_e4")]
		public double LowPrice24h
		{
			get => lowPrice24h;
			set => lowPrice24h = value / 1E4;
		}

		/// <summary>Gets or sets Mark price (E4 format)</summary>
		[JsonPropertyName("mark_price_e4")]
		public int MarkPrice { get; set; }

		/// <summary>Gets or sets Next funding time</summary>
		[JsonPropertyName("next_funding_time")]
		public DateTime NextFundingTime { get; set; }

		/// <summary>Gets or sets Open interest</summary>
		[JsonPropertyName("open_interest")]
		public int OpenInternest { get; set; }

		/// <summary>Gets or sets Open value (E8 format)</summary>
		[JsonPropertyName("open_value_e8")]
		public long OpenValue { get; set; }

		/// <summary>Gets or sets Predicted funding rate (E6 format)</summary>
		[JsonPropertyName("predicted_funding_rate_e6")]
		public int PredictedFundingRate { get; set; }

		/// <summary>Gets or sets 1HR previous price (E4 format)</summary>
		[JsonPropertyName("prev_price_1h_e4")]
		public int PrevPrice1h { get; set; }

		/// <summary>Gets or sets 24HR previous price (E4 format)</summary>
		[JsonPropertyName("prev_price_24h_e4")]
		public int PrevPrice24h { get; set; }

		/// <summary>Gets or sets 1HR price percentage (E6 format)</summary>
		[JsonPropertyName("price_1h_pcnt_e6")]
		public double Price1hPercent
		{
			get => price1hPercent;
			set => price1hPercent = value / 1E4;
		}

		/// <summary>Gets or sets 24HR price percentage (E6 format)</summary>
		[JsonPropertyName("price_24h_pcnt_e6")]
		public double Price24hPercent
		{
			get => price24hPercent;
			set => price24hPercent = value / 1E4;
		}

		/// <summary>Gets or sets Symbol string</summary>
		[JsonPropertyName("symbol")]
		public string SymbolString { get; set; }

		/// <summary>Gets or sets Total turnover (E8 format)</summary>
		[JsonPropertyName("total_turnover_e8")]
		public long TotalTurnover { get; set; }

		/// <summary>Gets or sets Total volume</summary>
		[JsonPropertyName("total_volume")]
		public long TotalVolume { get; set; }

		/// <summary>Gets or sets 24HR turnover (E8 format)</summary>
		[JsonPropertyName("turnover_24h_e8")]
		public long Turnover24h
		{
			get => turnover24h;
			set => turnover24h = value / (long)1E8;
		}

		/// <summary>Gets or sets Updated at</summary>
		[JsonPropertyName("updated_at")]
		public DateTime UpdatedAt { get; set; }

		/// <summary>Gets or sets 24HR volume</summary>
		[JsonPropertyName("volume_24h")]
		public double Volume24h { get; set; }
	}
}