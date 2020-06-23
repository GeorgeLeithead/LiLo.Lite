//-----------------------------------------------------------------------
// <copyright file="InstrumentInfoDeltaDataModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   ByBit instrument information delta data model.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Models.InstrumentInfo
{
	using System.Text.Json.Serialization;

	/// <summary>ByBit instrument information delta data model.</summary>
	public class InstrumentInfoDeltaDataModel
	{
		/// <summary>Gets or sets delete object property.</summary>
		[JsonPropertyName("delete")]
		public object Delete { get; set; }

		/// <summary>Gets or sets Instrument Information data model.</summary>
		[JsonPropertyName("update")]
#pragma warning disable CA1819 // Properties should not return arrays
		public InstrumentInfoDataModel[] Update { get; set; }
#pragma warning restore CA1819 // Properties should not return arrays

		/// <summary>Gets or sets insert object property.</summary>
		[JsonPropertyName("insert")]
		public object Insert { get; set; }
	}
}
