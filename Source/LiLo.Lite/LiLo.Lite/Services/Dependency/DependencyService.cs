//-----------------------------------------------------------------------
// <copyright file="DependencyService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Dependency service.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Services.Dependency
{
	/// <summary>Dependency service.</summary>
	public class DependencyService : IDependencyService
	{
		/// <summary>Get a dependent service.</summary>
		/// <typeparam name="T">Service type</typeparam>
		/// <returns>Dependant service</returns>
		public T Get<T>() where T : class
		{
			return Xamarin.Forms.DependencyService.Get<T>();
		}
	}
}