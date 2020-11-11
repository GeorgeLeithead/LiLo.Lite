//-----------------------------------------------------------------------
// <copyright file="providersModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// <summary>
//   Providers model.
// </summary>

namespace LiLo.Lite.Models.Provider
{
	using System;

	/// <summary>Providers model.</summary>
	public class ProvidersModel
	{
		/// <summary>Gets or sets the provider display name.</summary>
		public string DisplayName { get; set; }

		/// <summary>Gets or sets a value indicating whether the provider is selected.</summary>
		public bool IsSelected { get; set; }

		/// <summary>Gets or sets the provider.</summary>
		/// <remarks>For use in TradingView.</remarks>
		public string Provider { get; set; }

		/// <summary>Gets or sets the WSS feed subscription string.</summary>
		public string Subscription { get; set; }

		/// <summary>Gets or sets the provider title.</summary>
		public string Title { get; set; }

		/// <summary>Gets or sets the provider TradingView chart string.</summary>
		public string TradingView { get; set; }

		/// <summary>Gets or sets the provider WSS feed URI</summary>
		public Uri Wss { get; set; }
	}
}