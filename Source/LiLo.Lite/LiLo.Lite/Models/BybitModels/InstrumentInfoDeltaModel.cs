//-----------------------------------------------------------------------
// <copyright file="InstrumentInfoDeltaModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   ByBit instrument information delta model.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Models.BybitModels
{
	using System.Text.Json.Serialization;

	/// <summary>ByBit instrument information delta model.</summary>
	public class InstrumentInfoDeltaModel
	{
		/// <summary>Gets or sets Cross Sequence</summary>
		[JsonPropertyName("cross_seq")]
		public int CrossSequence { get; set; }

		/// <summary>Gets or sets Instrument Information Delta Data</summary>
		[JsonPropertyName("data")]
		public InstrumentInfoDeltaDataModel Data { get; set; }

		/// <summary>Gets or sets timestamp (E6 format)</summary>
		[JsonPropertyName("timestamp_e6")]
		public long TimeStamp { get; set; }

		/// <summary>Gets or sets subscription topic</summary>
		[JsonPropertyName("topic")]
		public string Topic { get; set; }

		/// <summary>Gets or sets subscription type</summary>
		[JsonPropertyName("type")]
		public string Type { get; set; }
	}
}