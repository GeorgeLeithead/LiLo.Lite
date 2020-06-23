//-----------------------------------------------------------------------
// <copyright file="IBybitAuthenticationService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Trigger by price enumeration.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Services.Bybit
{
	using System;

	/// <summary>ByBit authentication interface.</summary>
	public interface IBybitAuthenticationService
	{
		/// <summary>Secure WebSockets end point Uri</summary>
		/// <returns>Uri address.</returns>
		Uri WssEndPoint();
	}
}