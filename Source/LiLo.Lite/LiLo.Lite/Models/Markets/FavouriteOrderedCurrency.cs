// <copyright file="FavouriteOrderedCurrency.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Models.Markets
{
	/// <summary>User Favourite Ordered Currency Model.</summary>
	public class FavouriteOrderedCurrency
	{
		/// <summary>Gets or sets the currency Symbol as a string.</summary>
		public string SymbolString { get; set; }

		/// <summary>Gets or sets the user selected rank.</summary>
		public int Rank { get; set; }
	}
}