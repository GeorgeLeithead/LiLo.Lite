// <copyright file="MarketsModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Models.Markets
{
	/// <summary>Markets data model.</summary>
	public class MarketsModel
	{
		/// <summary>Gets or sets an array of markets.</summary>
		public MarketModel[] Markets { get; set; }

		/// <summary>Gets or sets the icon source for Android.</summary>
		public string IconSourceDroid { get; set; }

		/// <summary>Gets or sets the icon source for IOS.</summary>
		public string IconSourceIos { get; set; }
	}
}