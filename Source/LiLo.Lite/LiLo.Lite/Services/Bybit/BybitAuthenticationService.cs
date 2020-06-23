//-----------------------------------------------------------------------
// <copyright file="BybitAuthenticationService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   ByBit authentication service.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Services.Bybit
{
	using System;
	using Lilo.Lite;

	/// <summary>ByBit authentication service.</summary>
	public class BybitAuthenticationService : IBybitAuthenticationService
	{
		/// <summary>Initialises a new instance of the <see cref="BybitAuthenticationService" /> class.</summary>
		public BybitAuthenticationService()
		{
		}

		/// <summary>Generate the ByBit WSS endpoint.</summary>
		/// <returns>WSS End Point</returns>
		public Uri WssEndPoint()
		{
			Uri baseUri = GlobalSettings.MainNetWss;
			return baseUri;
		}
	}
}