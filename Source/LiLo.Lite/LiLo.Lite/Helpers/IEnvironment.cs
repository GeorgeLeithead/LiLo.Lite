// <copyright file="IEnvironment.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Helpers
{
	using System.Drawing;

	/// <summary>Environment interface.</summary>
	public interface IEnvironment
	{
		/// <summary>Set the status bar colour and tint.</summary>
		/// <param name="color">Bar colour.</param>
		/// <param name="darkStatusBarTint">Tint the icons and text.</param>
		void SetStatusBarColor(Color color, bool darkStatusBarTint);
	}
}