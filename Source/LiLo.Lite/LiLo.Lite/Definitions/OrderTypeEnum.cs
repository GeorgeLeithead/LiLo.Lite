//-----------------------------------------------------------------------
// <copyright file="OrderTypeEnum.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Order type enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Definitions
{
	/// <summary>Order type enumeration.</summary>
	public enum OrderTypeEnum
	{
		/// <summary>Limit order</summary>
		/// <remarks>Setting of an execution price for the other.  Only when last traded price reaches the order price, will the system fulfil the order.</remarks>
		Limit,

		/// <summary>Market order</summary>
		/// <remarks>A traditional market price order, will be filled at the best available price.  "Price" can be set to be "" if and only if you are placing a market price order.</remarks>
		Market
	}
}