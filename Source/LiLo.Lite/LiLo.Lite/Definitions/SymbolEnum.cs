//-----------------------------------------------------------------------
// <copyright file="SymbolEnum.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Currency symbol enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Definitions
{
	/// <summary>Currency symbol enumeration.</summary>
	public enum SymbolEnum
	{
		/// <summary>BTC with a matching pairing of USD.</summary>
		BTCUSD,

		/// <summary>ETH with a matching pairing of USD.</summary>
		ETHUSD,

		/// <summary>EOS with a matching pairing of USD.</summary>
		EOSUSD,

		/// <summary>XRP with a matching pairing of USD.</summary>
		XRPUSD
	}
}