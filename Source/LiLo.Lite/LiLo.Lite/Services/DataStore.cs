// <copyright file="DataStore.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Services
{
	using LiLo.Lite.Helpers;
	using LiLo.Lite.Models.Markets;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net.Http;
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
			List<MarketModel> marketsAllList = marketsData;
			string savedFavourites = Preferences.Get(Constants.Preferences.Favourites.FavouritesCategory, Constants.Preferences.Favourites.FavouritesCategoryDefaultValue);
			IEnumerable<string> favourites = savedFavourites.Split(',').ToList();
			if (string.IsNullOrWhiteSpace(savedFavourites))
			{
				// Must have at least 1 in the "Favourite" category
				favourites = new List<string>() { "BTC" };
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

		/// <summary>Gets the markets WSS stream.</summary>
		/// <returns>WSS stream.</returns>
		internal static string MarketsWss()
		{
			StringBuilder marketsString = new();
			_ = marketsString.Append(Constants.Sources.MarketFeed.WssData);
			foreach (MarketModel market in marketsData)
			{
				_ = marketsString.Append(market.SymbolString.ToLower());
				_ = marketsString.Append(Constants.Sources.MarketFeed.DataFeedSeparator);
			}

			string marketWss = marketsString.ToString();
			if (marketWss.ToString().EndsWith("/"))
			{
				marketWss = marketWss[0..^1];
			}

			return marketWss;
		}

		internal static IEnumerable<MarketModel> GetExternalMarketsFeed()
		{
			string versionMarketsJsonFile = string.Format(Constants.Sources.MarketFeed.Versioned, Version);

			try
			{
				HttpClientHandler httpClientHandler = new()
				{
					ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
				};
				using HttpClient client = new(httpClientHandler);
				HttpResponseMessage response = client.GetAsync(versionMarketsJsonFile).Result; // Want to do this synchronously to ensure that we don't start anything else until this is complete!
				if (response.IsSuccessStatusCode)
				{
					string marketsJson = response.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrEmpty(marketsJson))
					{
						MarketsModel markets = JsonSerializer.Deserialize<MarketsModel>(marketsJson);
						marketsData = markets.Markets.OrderBy(n => n.Rank).ToList();
						return marketsData;
					}
				}
				else
				{
					if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
					{
						response = client.GetAsync(Constants.Sources.MarketFeed.Default).Result; // Want to do this synchronously to ensure that we don't start anything else until this is complete!
						if (response.IsSuccessStatusCode)
						{
							string marketsJson = response.Content.ReadAsStringAsync().Result;
							if (!string.IsNullOrEmpty(marketsJson))
							{
								MarketsModel markets = JsonSerializer.Deserialize<MarketsModel>(marketsJson);
								marketsData = markets.Markets.OrderBy(n => n.Rank).ToList();
								return marketsData;
							}
						}
					}
				}
			}
			catch (HttpRequestException)
			{
				throw;
			}

			throw new HttpRequestException(Resources.AppResources.ErrorNoMarkets);
		}

		internal static IEnumerable<MarketModel> GetFavouriteMarkets()
		{
			string savedFavourites = Preferences.Get(Constants.Preferences.Favourites.FavouritesCategory, Constants.Preferences.Favourites.FavouritesCategoryDefaultValue);
			IEnumerable<string> favourites = savedFavourites.Split(',').ToList();
			if (string.IsNullOrWhiteSpace(savedFavourites))
			{
				// Must have at least 1 in the "Favourite" category
				favourites = new List<string>() { "BTC" };
			}

			List<MarketModel> favouriteMarkets = new();
			foreach (string favourite in favourites.Where(f => !string.IsNullOrWhiteSpace(f)))
			{
				MarketModel match = marketsData.First(m => m.SymbolString == favourite);
				favouriteMarkets.Add(match);
			}

			return favouriteMarkets.ToList();
		}
	}
}