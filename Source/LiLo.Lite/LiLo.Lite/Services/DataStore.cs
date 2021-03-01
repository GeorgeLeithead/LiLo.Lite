//-----------------------------------------------------------------------
// <copyright file="DataStore.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Application data store.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Services
{
	using System.Collections.Generic;
	using System.Linq;
	using System.Text;
	using System.Text.Json;
	using LiLo.Lite.Models.Markets;
	using System.Net.Http;

	/// <summary>Application data store.</summary>
	public static class DataStore
	{
		public static List<MarketModel> Markets;

		/// <summary>Data store.</summary>
		/// <remarks>SVG icons from https://github.com/spothq/cryptocurrency-icons under SVG/colour.</remarks>
		static DataStore()
		{
			List<MarketModel> markets = new List<MarketModel>
			{
				// Binance Futures (MainNet)
				new MarketModel { Rank = 1, DecimalPlaces = 2, SymbolString = "BTC" },
				new MarketModel { Rank = 2, DecimalPlaces = 2, SymbolString = "ETH" },
				new MarketModel { Rank = 3, DecimalPlaces = 4, SymbolString = "BNB" },
				//// #4 is USDT
				new MarketModel { Rank = 5, DecimalPlaces = 5, SymbolString = "ADA" },
				new MarketModel { Rank = 6, DecimalPlaces = 2, SymbolString = "DOT" },
				new MarketModel { Rank = 7, DecimalPlaces = 5, SymbolString = "XRP" },
				new MarketModel { Rank = 8, DecimalPlaces = 2, SymbolString = "LTC" },
				new MarketModel { Rank = 9, DecimalPlaces = 4, SymbolString = "LINK" },
				new MarketModel { Rank = 10, DecimalPlaces = 2, SymbolString = "BCH" },
				new MarketModel { Rank = 11, DecimalPlaces = 5, SymbolString = "XLM" },
				//// #12 is USDC
				new MarketModel { Rank = 13, DecimalPlaces = 2, SymbolString = "UNI" },
				new MarketModel { Rank = 14, DecimalPlaces = 7, SymbolString = "DOGE" },
				//// #15 is WBTC
				//// #16 is OKB
				new MarketModel { Rank = 17, DecimalPlaces = 4, SymbolString = "XEM" },
				new MarketModel { Rank = 18, DecimalPlaces = 3, SymbolString = "ATOM" },
				new MarketModel { Rank = 19, DecimalPlaces = 2, SymbolString = "AAVE" }, // from ALT source
				new MarketModel { Rank = 20, DecimalPlaces = 2, SymbolString = "SOL" }, // from ALT source
				//// #21 is CRO
				new MarketModel { Rank = 22, DecimalPlaces = 2, SymbolString = "XMR" },
				new MarketModel { Rank = 23, DecimalPlaces = 4, SymbolString = "EOS" },
				//// #24 is BSV
				new MarketModel { Rank = 25, DecimalPlaces = 5, SymbolString = "TRX" },
				//// #26 is HT
				new MarketModel { Rank = 27, DecimalPlaces = 4, SymbolString = "IOTA" },
				new MarketModel { Rank = 28, DecimalPlaces = 5, SymbolString = "THETA" },
				new MarketModel { Rank = 29, DecimalPlaces = 3, SymbolString = "SNX" }, // from ALT source
				new MarketModel { Rank = 30, DecimalPlaces = 3, SymbolString = "NEO" },
				new MarketModel { Rank = 31, DecimalPlaces = 4, SymbolString = "XTZ" },
				new MarketModel { Rank = 32, DecimalPlaces = 2, SymbolString = "LUNA" }, // from ALT source
				new MarketModel { Rank = 33, DecimalPlaces = 6, SymbolString = "VET" },
				new MarketModel { Rank = 34, DecimalPlaces = 2, SymbolString = "FTT" }, // from ALT source
				new MarketModel { Rank = 35, DecimalPlaces = 2, SymbolString = "DASH" },
				new MarketModel { Rank = 36, DecimalPlaces = 2, SymbolString = "GRT" }, // from ALT source
				new MarketModel { Rank = 37, DecimalPlaces = 2, SymbolString = "AVAX" }, // from ALT source
				//// #38 is DAI, but it's not really available in the spot market!
				////new MarketsModel { Rank = 38, DecimalPlaces = 6, SymbolString = "DAI" },
				new MarketModel { Rank = 39, DecimalPlaces = 4, SymbolString = "BUSD" }, // from ALT source
				//// #40 is CDAI
				new MarketModel { Rank = 41, DecimalPlaces = 2, SymbolString = "KSM" }, // from ALT source
				new MarketModel { Rank = 42, DecimalPlaces = 2, SymbolString = "SUSHI" }, // from ALT source
				new MarketModel { Rank = 43, DecimalPlaces = 2, SymbolString = "MKR" },
				//// #44 is CETH
				new MarketModel { Rank = 45, DecimalPlaces = 2, SymbolString = "EGLD" }, // from ALT source
				new MarketModel { Rank = 46, DecimalPlaces = 2, SymbolString = "FIL" },
				//// #47 is CEL
				new MarketModel { Rank = 48, DecimalPlaces = 5, SymbolString = "FTM" }, // from ALT source
				//// #49 is LEO
				new MarketModel { Rank = 50, DecimalPlaces = 2, SymbolString = "COMP" },
				new MarketModel { Rank = 51, DecimalPlaces = 2, SymbolString = "DCR" },
				//// #52 is CUSDC
				new MarketModel { Rank = 53, DecimalPlaces = 2, SymbolString = "CAKE" }, // from ALT source
				//// # 54 is VGX
				new MarketModel { Rank = 55, DecimalPlaces = 5, SymbolString = "RVN" },
				new MarketModel { Rank = 56, DecimalPlaces = 2, SymbolString = "ZEC" },
				new MarketModel { Rank = 57, DecimalPlaces = 5, SymbolString = "ZIL" },
				new MarketModel { Rank = 58, DecimalPlaces = 4, SymbolString = "ETC" },
				new MarketModel { Rank = 59, DecimalPlaces = 2, SymbolString = "UMA" },
				new MarketModel { Rank = 60, DecimalPlaces = 2, SymbolString = "YFI" },
				//// #61 is HBTC
				//// #62 is NEXO
				new MarketModel { Rank = 63, DecimalPlaces = 2, SymbolString = "RUNE" }, // from ALT source
				new MarketModel { Rank = 64, DecimalPlaces = 2, SymbolString = "NEAR" }, // from ALT source
				new MarketModel { Rank = 65, DecimalPlaces = 4, SymbolString = "ZRX" },
				new MarketModel { Rank = 66, DecimalPlaces = 2, SymbolString = "REN" },
				new MarketModel { Rank = 67, DecimalPlaces = 2, SymbolString = "WAVES" },
				//// #68 is XSUSHI
				new MarketModel { Rank = 69, DecimalPlaces = 2, SymbolString = "ICX" },
				new MarketModel { Rank = 70, DecimalPlaces = 2, SymbolString = "STX" },
				new MarketModel { Rank = 71, DecimalPlaces = 5, SymbolString = "HBAR" }, // from ALT source
				//// #72 is AMP
				new MarketModel { Rank = 73, DecimalPlaces = 7, SymbolString = "BTT" },
				//// #74 is MDX
				new MarketModel { Rank = 75, DecimalPlaces = 5, SymbolString = "MATIC" },
				//// #76 is RENBTC
				//// #77 is CHSB
				new MarketModel { Rank = 78, DecimalPlaces = 6, SymbolString = "IOST" },
				new MarketModel { Rank = 79, DecimalPlaces = 4, SymbolString = "ALGO" },
				new MarketModel { Rank = 80, DecimalPlaces = 4, SymbolString = "PAX" },
				new MarketModel { Rank = 81, DecimalPlaces = 5, SymbolString = "DGB" },
				new MarketModel { Rank = 82, DecimalPlaces = 2, SymbolString = "ONT" },
				new MarketModel { Rank = 83, DecimalPlaces = 2, SymbolString = "NANO" },
				new MarketModel { Rank = 84, DecimalPlaces = 4, SymbolString = "BAT" },
				new MarketModel { Rank = 85, DecimalPlaces = 5, SymbolString = "LRC" },
				//// #86 is ZKS
				new MarketModel { Rank = 87, DecimalPlaces = 4, SymbolString = "OMG" },
				//// #88 is HUSD
				new MarketModel { Rank = 89, DecimalPlaces = 2, SymbolString = "BNT" },
				//// #90 is UST
				new MarketModel { Rank = 91, DecimalPlaces = 2, SymbolString = "ZEN" },
				new MarketModel { Rank = 92, DecimalPlaces = 3, SymbolString = "QTUM" },
				new MarketModel { Rank = 93, DecimalPlaces = 7, SymbolString = "NPXS" },
				new MarketModel { Rank = 94, DecimalPlaces = 7, SymbolString = "HOT" },
				////new MarketsModel { Rank = 95, DecimalPlaces = 2, SymbolString = "XVS" }, // NEED PNG
				new MarketModel { Rank = 96, DecimalPlaces = 5, SymbolString = "ENJ" },
				//// #97 is BTMX
				new MarketModel { Rank = 98, DecimalPlaces = 2, SymbolString = "CRV" }, // from ALT source
				new MarketModel { Rank = 99, DecimalPlaces = 7, SymbolString = "SC" },
				//// # 100 is BTG
				new MarketModel { Rank = 118, DecimalPlaces = 3, SymbolString = "KNC" },
				new MarketModel { Rank = 149, DecimalPlaces = 3, SymbolString = "SXP" },
			};

			////Markets = new List<MarketModel>(markets);
		}

		/// <summary>Get ordered markets feed list.</summary>
		/// <returns>IEnumerable{MarketsModel} ordered by rank.</returns>
		internal static IEnumerable<MarketModel> GetMarketsForFeed()
		{
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
						Markets = markets.Markets.ToList();
						return Markets.OrderBy(n => n.Rank);
					}
				}
			}
			catch (HttpRequestException)
			{
				throw;
			}

			throw new HttpRequestException("No markets data found!");
		}

		/// <summary>Gets the markets WSS stream.</summary>
		/// <returns>WSS stream.</returns>
		internal static string MarketsWss()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("wss://stream.binance.com:9443/stream?streams=");
			foreach (MarketModel market in Markets)
			{
				sb.Append(market.SymbolString.ToLower());
				sb.Append("usdt@ticker/");
			}

			string marketWss = sb.ToString();
			if (marketWss.ToString().EndsWith("/"))
			{
				marketWss = marketWss.Substring(0, marketWss.Length - 1);
			}

			return marketWss;
		}
	}
}