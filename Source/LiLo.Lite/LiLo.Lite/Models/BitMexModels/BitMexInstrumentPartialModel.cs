//-----------------------------------------------------------------------
// <copyright file="BitMexInstrumentPartialModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   BitMex instrument partial model.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Models.BitMexModels
{
	using System.Text.Json.Serialization;

	/// <summary>BitMex instrument partial model.</summary>
	public class BitMexInstrumentPartialModel
	{
		[JsonPropertyName("table")]
		public string Table { get; set; }

		[JsonPropertyName("action")]
		public string Action { get; set; }

		[JsonPropertyName("keys")]
		public object Keys { get; set; }

		[JsonPropertyName("types")]
		public object Types { get; set; }

		[JsonPropertyName("foreignKeys")]
		public object ForeignKeys { get; set; }

		[JsonPropertyName("attributes")]
		public object Attributes { get; set; }

		[JsonPropertyName("filter")]
		public object Filter { get; set; }

		[JsonPropertyName("data")]
#pragma warning disable CA1819 // Properties should not return arrays
		public BitMexDataModel[] Data { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays
	}
}