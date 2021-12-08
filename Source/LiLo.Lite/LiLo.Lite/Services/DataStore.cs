// <copyright file="DataStore.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Services
{
	using LiLo.Lite.Helpers;
	using LiLo.Lite.Models.Markets;
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using System.Net.Http;
	using System.Reflection;
	using System.Text;
	using System.Text.Json;
	using Xamarin.Essentials;

	/// <summary>Application data store.</summary>
	public static class DataStore
	{
		/// <summary>Markets list.</summary>
		private static List<MarketModel> marketsData;

		/// <summary>Gets the application version.</summary>
		private static string Version => AppInfo.VersionString;

		/// <summary>Get markets grouped by favourites.</summary>
		/// <returns>IEnumerable{ItemViewModel} of categorised markets.</returns>
		public static IEnumerable<ItemViewModel> GetMarketsGroupedByFavourites()
		{
			List<ItemViewModel> marketsGroupedByFavourites = new();
			IOrderedEnumerable<MarketModel> marketsAllList = GetAllLocalMarkets().OrderBy(m => m.Rank);
			string savedFavourites = Preferences.Get(Constants.Preferences.Favourites.FavouritesCategory, Constants.Preferences.Favourites.FavouritesCategoryDefaultValue);
			IEnumerable<string> favourites = savedFavourites.Split(',').ToList();
			if (string.IsNullOrWhiteSpace(savedFavourites))
			{
				// Must have at least 1 in the "Favourite" category
				favourites = favourites.Concat(new[] { "BTC" });
			}

			foreach (string favourite in favourites.Where(f => !string.IsNullOrEmpty(f)))
			{
				marketsGroupedByFavourites.Add(new ItemViewModel { Category = Constants.Preferences.Favourites.FavouritesCategory, Symbol = favourite });
			}

			foreach (MarketModel marketItem in marketsAllList)
			{
				if (!favourites.Any(f => f == marketItem.SymbolString))
				{
					marketsGroupedByFavourites.Add(new ItemViewModel { Category = Constants.Preferences.Favourites.UnlovedCategory, Symbol = marketItem.SymbolString });
				}
			}

			return marketsGroupedByFavourites;
		}

		/// <summary>Get ordered markets feed list.</summary>
		/// <returns>IEnumerable{MarketsModel} ordered by rank.</returns>
		internal static IEnumerable<MarketModel> GetMarketsForFeed()
		{
			if (Preferences.Get(Constants.Preferences.Favourites.FavouritesEnabled, Constants.Preferences.Favourites.FavouritesEnabledDefaultValue))
			{
				try
				{
					return GetFavouriteMarkets();
				}
				catch (ArgumentNullException)
				{
				}
			}

			return GetExternalMarketsFeed();
		}

		/// <summary>Gets the markets WSS stream.</summary>
		/// <returns>WSS stream.</returns>
		internal static string MarketsWss()
		{
			StringBuilder marketsString = new();
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

		private static List<MarketModel> GetAllLocalMarkets()
		{
			string marketsJson = string.Empty;
			Assembly assemblyThis = typeof(DataStore).GetTypeInfo().Assembly;
			Stream streamJson = assemblyThis.GetManifestResourceStream("LiLo.Lite.Services.Markets.json");
			using (StreamReader reader = new(streamJson))
			{
				marketsJson = reader.ReadToEnd();
			}

			return string.IsNullOrEmpty(marketsJson)
				? throw new ArgumentNullException("No markets data found!")
				: JsonSerializer.Deserialize<MarketsModel>(marketsJson).Markets.ToList();
		}

		private static IEnumerable<MarketModel> GetExternalMarketsFeed()
		{
			string defaultMarketsJsonFile = "https://raw.githubusercontent.com/GeorgeLeithead/LiLo.Markets/main/Markets.json";
			string versionMarketsJsonFile = "https://raw.githubusercontent.com/GeorgeLeithead/LiLo.Markets/main/Markets" + Version + ".json";

			try
			{
				using HttpClient client = new();
				HttpResponseMessage response = client.GetAsync(versionMarketsJsonFile).Result; // Want to do this synchronously to ensure that we don't start anything else until this is complete!
				if (response.IsSuccessStatusCode)
				{
					string marketsJson = response.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrEmpty(marketsJson))
					{
						MarketsModel markets = JsonSerializer.Deserialize<MarketsModel>(marketsJson);
						marketsData = markets.Markets.ToList();
						return marketsData.OrderBy(n => n.Rank);
					}
				}
				else
				{
					if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
					{
						response = client.GetAsync(defaultMarketsJsonFile).Result; // Want to do this synchronously to ensure that we don't start anything else until this is complete!
						if (response.IsSuccessStatusCode)
						{
							string marketsJson = response.Content.ReadAsStringAsync().Result;
							if (!string.IsNullOrEmpty(marketsJson))
							{
								MarketsModel markets = JsonSerializer.Deserialize<MarketsModel>(marketsJson);
								marketsData = markets.Markets.ToList();
								return marketsData.OrderBy(n => n.Rank);
							}
						}
					}
				}
			}
			catch (HttpRequestException)
			{
				throw;
			}

			throw new HttpRequestException("No markets data found!");
		}

		private static IEnumerable<MarketModel> GetFavouriteMarkets()
		{
			List<MarketModel> marketsAllList = GetAllLocalMarkets();
			string savedFavourites = Preferences.Get(Constants.Preferences.Favourites.FavouritesCategory, Constants.Preferences.Favourites.FavouritesCategoryDefaultValue);
			if (string.IsNullOrEmpty(savedFavourites))
			{
				throw new ArgumentNullException("No favourite markets found!");
			}

			List<string> favourites = savedFavourites.Split(',').ToList();
			List<MarketModel> favouriteMarkets = new();
			foreach (string favourite in favourites)
			{
				MarketModel match = marketsAllList.First(m => m.SymbolString == favourite);
				favouriteMarkets.Add(match);
			}

			marketsData = favouriteMarkets.ToList();
			return marketsData;
		}
	}
}