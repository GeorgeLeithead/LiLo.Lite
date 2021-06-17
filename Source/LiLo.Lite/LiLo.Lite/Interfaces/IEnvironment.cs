// <copyright file="IEnvironment.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>

namespace LiLo.Lite.Interfaces
{
	using System.Threading.Tasks;

	/// <summary>Theme enumerator.</summary>
	public enum Theme
	{
		/// <summary>Light theme.</summary>
		Light = 0,

		/// <summary>Dark theme.</summary>
		Dark = 1,
	}

	/// <summary>Environment interface.</summary>
	public interface IEnvironment
	{
		/// <summary>Get operating system theme.</summary>
		/// <returns>Theme enumeration.</returns>
		Theme GetOperatingSystemTheme();

		/// <summary>Asynchronous get operating system theme.</summary>
		/// <returns>A <see cref="Task{Theme}"/> representing the asynchronous operation.</returns>
		Task<Theme> GetOperatingSystemThemeAsync();
	}
}