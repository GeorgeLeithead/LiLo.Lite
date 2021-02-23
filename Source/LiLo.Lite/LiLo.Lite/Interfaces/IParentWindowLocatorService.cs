//-----------------------------------------------------------------------
// <copyright file="IParentWindowLocatorService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Simple platform specific service that is responsible for locating a parent window service.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Interfaces
{
	/// <summary>Simple platform specific service that is responsible for locating a parent window service.</summary>
	public interface IParentWindowLocatorService
	{
		/// <summary>Get current parent window.</summary>
		/// <returns>Current parent window object.</returns>
		object GetCurrentParentWindow();
	}
}