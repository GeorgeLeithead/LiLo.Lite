//-----------------------------------------------------------------------
// <copyright file="IDependencyService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Dependency service interface.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Services.Dependency
{
	/// <summary>Dependency service interface.</summary>
	public interface IDependencyService
	{
		/// <summary>Get a dependent service.</summary>
		/// <typeparam name="T">Service type</typeparam>
		/// <returns>Dependant service</returns>
		T Get<T>() where T : class;
	}
}