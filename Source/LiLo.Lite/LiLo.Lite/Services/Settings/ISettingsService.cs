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
		/// <summary>Gets a value indicating whether the device has a default theme option for the appropriate device and version.</summary>
		bool HasDefaultThemeOption { get; }

		/// <summary>Gets or sets the users selected currency symbol.</summary>
		string SymbolString { get; set; }

		/// <summary>Gets or sets the users selected theme.</summary>
		ThemeModel ThemeOption { get; set; }
	}
}