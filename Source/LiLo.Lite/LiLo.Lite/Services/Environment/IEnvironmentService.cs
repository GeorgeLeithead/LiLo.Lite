//-----------------------------------------------------------------------
// <copyright file="IEnvironmentService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Application environment interface.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Services.Environment
{
	using System.Drawing;

	/// <summary>Application environment interface.</summary>
	public interface IEnvironmentService
	{
		/// <summary>Set the application status bar colour</summary>
		/// <param name="color">Light colour.</param>
		/// <param name="darkStatusBarTint">Dark colour tint.</param>
		void SetStatusBarColor(Color color, bool darkStatusBarTint);
	}
}