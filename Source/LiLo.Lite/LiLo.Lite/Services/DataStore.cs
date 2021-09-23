// <copyright file="DataStore.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Services
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Net.Http;
	using System.Reflection;
	using System.Text;
	using System.Text.Json;
	using LiLo.Lite.Helpers;
	using LiLo.Lite.Models.Markets;
	using Xamarin.Essentials;

	/// <summary>Application data store.</summary>
	public static class DataStore
	{
		/// <summary>Markets list.</summary>
		private static List<MarketModel> marketsData;

		private static List<MarketModel> allMarketsData = null;

		/// <summary>Get ordered markets feed list.</summary>
		/// <returns>IEnumerable{MarketsModel} ordered by rank.</returns>
		public static IEnumerable<MarketModel> GetMarketsForFeed()
		{
			List<FavouriteOrderedCurrency> foc = new List<FavouriteOrderedCurrency>
			{
				new FavouriteOrderedCurrency { Rank = 1, SymbolString = "XRP" },
				new FavouriteOrderedCurrency { Rank = 2, SymbolString = "BTC" },
				new FavouriteOrderedCurrency { Rank = 3, SymbolString = "ETH" },
				new FavouriteOrderedCurrency { Rank = 4, SymbolString = "TRX" },
				new FavouriteOrderedCurrency { Rank = 5, SymbolString = "DOGE" },
			};

			string serialisedFoc = JsonSerializer.Serialize(foc);
			Preferences.Set(Constants.Preferences.Favourites.FavouriteOrderedCurrency, serialisedFoc);
			//// Preferences.Remove(Constants.Preferences.Favourites.FavouriteOrderedCurrency);

			try
			{
				using HttpClient client = new HttpClient();
				HttpResponseMessage response = client.GetAsync("https://raw.githubusercontent.com/GeorgeLeithead/LiLo.Markets/main/Markets.json").Result; // Want to do this synchronously to ensure that we don't start anything else until this is complete!
				if (response.IsSuccessStatusCode)
				{
					string marketsJson = response.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrEmpty(marketsJson))
					{
						MarketsModel markets = JsonSerializer.Deserialize<MarketsModel>(marketsJson);
						marketsData = markets.Markets.OrderBy(n => n.Rank).ToList();
						string userPreferenceFavourites = Preferences.Get(Constants.Preferences.Favourites.FavouriteOrderedCurrency, Constants.Preferences.Favourites.FavouritesCategoryDefaultValue);
						if (!string.IsNullOrEmpty(userPreferenceFavourites))
						{
							List<FavouriteOrderedCurrency> userFavourites = new List<FavouriteOrderedCurrency>();
							userFavourites = JsonSerializer.Deserialize<List<FavouriteOrderedCurrency>>(userPreferenceFavourites);
							foreach (MarketModel market in marketsData)
							{
								FavouriteOrderedCurrency userFave = userFavourites.FirstOrDefault(uf => uf.SymbolString == market.SymbolString);
								if (userFave != null)
								{
									market.IsFavourite = false;
									market.Rank = userFave.Rank;
								}
								else
								{
									market.IsFavourite = true;
								}
							}
						}

						allMarketsData = marketsData;
						return marketsData.Where(md => !md.IsFavourite);
					}
				}
			}
			catch (HttpRequestException)
			{
				throw;
			}

			throw new HttpRequestException("No markets data found!");
		}

		/// <summary>Gets the list of all markets for settings.</summary>
		/// <returns>IEnumerable{MarketsModel} ordered by rank.</returns>
		public static IEnumerable<MarketModel> GetmarketsForSettings()
		{
			return allMarketsData;
		}

		/// <summary>Gets the markets WSS stream.</summary>
		/// <returns>WSS stream.</returns>
		internal static string MarketsWss()
		{
			StringBuilder marketsString = new StringBuilder();
			_ = marketsString.Append("wss://stream.binance.com:9443/stream?streams=");
			foreach (MarketModel market in marketsData)
			{
				_ = marketsString.Append(market.SymbolString.ToLower());
				_ = marketsString.Append("usdt@ticker/");
			}

			string marketWss = marketsString.ToString();
			if (marketWss.ToString().EndsWith("/"))
			{
				marketWss = marketWss[0..^1];
			}

			return marketWss;
		}
	}
}