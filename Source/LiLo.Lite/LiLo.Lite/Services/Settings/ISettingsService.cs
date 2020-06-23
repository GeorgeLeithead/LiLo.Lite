//-----------------------------------------------------------------------
// <copyright file="ISettingsService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Application settings service interface.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Services.Settings
{
	using LiLo.Lite.Definitions;
	using LiLo.Lite.Models;

	/// <summary>Application settings service interface.</summary>
	public interface ISettingsService
	{
		/// <summary>Sets the users last selected currency.</summary>
		CurrencyEnum Currency { set; }

		/// <summary>Gets a value indicating whether the device has a default theme option for the appropriate device and version.</summary>
		bool HasDefaultThemeOption { get; }

		/// <summary>Gets a value indicating whether the user is network Authenticate-able.</summary>
		bool IsAuthenticatable { get; }

		/// <summary>Gets or sets the users MainNet API key.</summary>
		string MainNetApi { get; set; }

		/// <summary>Gets or sets the users MainNet Private key.</summary>
		string MainNetPrivate { get; set; }

		/// <summary>Gets or sets the users selected currency symbol.</summary>
		string Symbol { get; set; }

		/// <summary>Gets or sets a value indicating whether the network is TestNet.</summary>
		bool TestNet { get; set; }

		/// <summary>Gets or sets the users TestNet API key.</summary>
		string TestNetApi { get; set; }

		/// <summary>Gets or sets the users TestNet private key.</summary>
		string TestNetPrivate { get; set; }

		/// <summary>Gets or sets the users selected theme.</summary>
		ThemeModel ThemeOption { get; set; }
	}
}