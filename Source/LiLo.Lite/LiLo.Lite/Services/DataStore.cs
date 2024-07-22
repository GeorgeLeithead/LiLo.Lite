// <copyright file="DataStore.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Services
{
	using LiLo.Lite.Helpers;
	using LiLo.Lite.Models.Markets;
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Net.Http;
	using System.Text;
	using System.Text.Json;
	using Xamarin.Essentials;
	using Xamarin.Forms;

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
				UriImageSource symbolImage = marketsAllList.Find(f => f.SymbolString == favourite).SymbolImage;
				marketsGroupedByFavourites.Add(new ItemViewModel { Category = Constants.Preferences.Favourites.FavouritesCategory, Symbol = favourite, SymbolImage = symbolImage });
			}

			foreach (MarketModel marketItem in marketsAllList)
			{
				if (!favourites.Any(f => f == marketItem.SymbolString))
				{
					marketsGroupedByFavourites.Add(new ItemViewModel { Category = Constants.Preferences.Favourites.UnlovedCategory, Symbol = marketItem.SymbolString, SymbolImage = marketItem.SymbolImage });
				}
			}

			return marketsGroupedByFavourites;
		}

		internal static IEnumerable<MarketModel> GetExternalMarketsFeed()
		{
			string versionMarketsJsonFile = string.Format(Constants.Sources.MarketFeed.Versioned, Version);

			try
			{
				string droidSource = null;
				string iosSource = null;
				HttpClientHandler httpClientHandler = new()
				{
					ServerCertificateCustomValidationCallback = (_, _, _, _) => true
				};
				using HttpClient client = new(httpClientHandler);
				HttpResponseMessage response = client.GetAsync(versionMarketsJsonFile).Result; // Want to do this synchronously to ensure that we don't start anything else until this is complete!
				if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
				{
					response = client.GetAsync(Constants.Sources.MarketFeed.Default).Result; // Want to do this synchronously to ensure that we don't start anything else until this is complete!
				}

				if (response.IsSuccessStatusCode)
				{
					string marketsJson = response.Content.ReadAsStringAsync().Result;
					if (!string.IsNullOrEmpty(marketsJson))
					{
						MarketsModel markets = JsonSerializer.Deserialize<MarketsModel>(marketsJson);
						if (string.IsNullOrEmpty(markets.IconSourceDroid))
						{
							droidSource = Constants.Sources.Icons.DroidSource;
							iosSource = Constants.Sources.Icons.IosSource;
						}
						else
						{
							droidSource = markets.IconSourceDroid;
							iosSource = markets.IconSourceIos;
						}

						marketsData = markets.Markets.OrderBy(n => n.Rank).ToList();
					}
				}

				if (marketsData.Count > 0)
				{
					string imageSource = null;
					switch (Device.RuntimePlatform)
					{
						case Device.iOS:
							imageSource = iosSource;
							break;

						case Device.UWP:
							break;

						default:
							imageSource = droidSource;
							break;
					}

					foreach (MarketModel market in marketsData)
					{
						market.SymbolImage = new UriImageSource
						{
							Uri = new Uri(string.Format(imageSource, market.SymbolString.ToLowerInvariant())),
							CachingEnabled = true,
							CacheValidity = TimeSpan.FromDays(Constants.Sources.Icons.CacheDuration)
						};
					}
				}

				return marketsData;
			}
			catch (HttpRequestException)
			{
				throw new HttpRequestException(Resources.AppResources.ErrorNoMarkets);
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
			if (marketWss.EndsWith('/'))
			{
				marketWss = marketWss[0..^1];
			}

			return marketWss;
		}
	}
}