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

	/// <summary>Application data store.</summary>
	public static class DataStore
	{
		public static List<MarketsModel> Markets;

		/// <summary>Data store.</summary>
		/// <remarks>SVG icons from https://github.com/spothq/cryptocurrency-icons under SVG/colour.</remarks>
		static DataStore()
		{
			List<MarketsModel> markets = new List<MarketsModel>
			{
				// Binance Futures (MainNet)
				new MarketsModel { Rank = 1, DecimalPlaces = 2, SymbolString = "BTC" },
				new MarketsModel { Rank = 2, DecimalPlaces = 2, SymbolString = "ETH" },
				new MarketsModel { Rank = 3, DecimalPlaces = 4, SymbolString = "BNB" },
				//// #4 is USDT
				new MarketsModel { Rank = 5, DecimalPlaces = 5, SymbolString = "ADA" },
				new MarketsModel { Rank = 6, DecimalPlaces = 2, SymbolString = "DOT" },
				new MarketsModel { Rank = 7, DecimalPlaces = 5, SymbolString = "XRP" },
				new MarketsModel { Rank = 8, DecimalPlaces = 2, SymbolString = "LTC" },
				new MarketsModel { Rank = 9, DecimalPlaces = 4, SymbolString = "LINK" },
				new MarketsModel { Rank = 10, DecimalPlaces = 2, SymbolString = "BCH" },
				new MarketsModel { Rank = 11, DecimalPlaces = 5, SymbolString = "XLM" },
				//// #12 is USDC
				new MarketsModel { Rank = 13, DecimalPlaces = 2, SymbolString = "UNI" },
				new MarketsModel { Rank = 14, DecimalPlaces = 7, SymbolString = "DOGE" },
				//// #15 is WBTC
				//// #16 is OKB
				new MarketsModel { Rank = 17, DecimalPlaces = 4, SymbolString = "XEM" },
				new MarketsModel { Rank = 18, DecimalPlaces = 3, SymbolString = "ATOM" },
				new MarketsModel { Rank = 19, DecimalPlaces = 2, SymbolString = "AAVE" }, // from ALT source
				new MarketsModel { Rank = 20, DecimalPlaces = 2, SymbolString = "SOL" }, // from ALT source
				//// #21 is CRO
				new MarketsModel { Rank = 22, DecimalPlaces = 2, SymbolString = "XMR" },
				new MarketsModel { Rank = 23, DecimalPlaces = 4, SymbolString = "EOS" },
				//// #24 is BSV
				new MarketsModel { Rank = 25, DecimalPlaces = 5, SymbolString = "TRX" },
				//// #26 is HT
				new MarketsModel { Rank = 27, DecimalPlaces = 4, SymbolString = "IOTA" },
				new MarketsModel { Rank = 28, DecimalPlaces = 5, SymbolString = "THETA" },
				new MarketsModel { Rank = 29, DecimalPlaces = 3, SymbolString = "SNX" }, // from ALT source
				new MarketsModel { Rank = 30, DecimalPlaces = 3, SymbolString = "NEO" },
				new MarketsModel { Rank = 31, DecimalPlaces = 4, SymbolString = "XTZ" },
				new MarketsModel { Rank = 32, DecimalPlaces = 2, SymbolString = "LUNA" }, // from ALT source
				new MarketsModel { Rank = 33, DecimalPlaces = 6, SymbolString = "VET" },
				new MarketsModel { Rank = 34, DecimalPlaces = 2, SymbolString = "FTT" }, // from ALT source
				new MarketsModel { Rank = 35, DecimalPlaces = 2, SymbolString = "DASH" },
				new MarketsModel { Rank = 36, DecimalPlaces = 2, SymbolString = "GRT" }, // from ALT source
				new MarketsModel { Rank = 37, DecimalPlaces = 2, SymbolString = "AVAX" }, // from ALT source
				//// #38 is DAI, but it's not really available in the spot market!
				////new MarketsModel { Rank = 38, DecimalPlaces = 6, SymbolString = "DAI" },
				new MarketsModel { Rank = 39, DecimalPlaces = 4, SymbolString = "BUSD" }, // from ALT source
				//// #40 is CDAI
				new MarketsModel { Rank = 41, DecimalPlaces = 2, SymbolString = "KSM" }, // from ALT source
				new MarketsModel { Rank = 42, DecimalPlaces = 2, SymbolString = "SUSHI" }, // from ALT source
				new MarketsModel { Rank = 43, DecimalPlaces = 2, SymbolString = "MKR" },
				//// #44 is CETH
				new MarketsModel { Rank = 45, DecimalPlaces = 2, SymbolString = "EGLD" }, // from ALT source
				new MarketsModel { Rank = 46, DecimalPlaces = 2, SymbolString = "FIL" },
				//// #47 is CEL
				new MarketsModel { Rank = 48, DecimalPlaces = 5, SymbolString = "FTM" }, // from ALT source
				//// #49 is LEO
				new MarketsModel { Rank = 50, DecimalPlaces = 2, SymbolString = "COMP" },
				new MarketsModel { Rank = 51, DecimalPlaces = 2, SymbolString = "DCR" },
				//// #52 is CUSDC
				new MarketsModel { Rank = 53, DecimalPlaces = 2, SymbolString = "CAKE" }, // from ALT source
				//// # 54 is VGX
				new MarketsModel { Rank = 55, DecimalPlaces = 5, SymbolString = "RVN" },
				new MarketsModel { Rank = 56, DecimalPlaces = 2, SymbolString = "ZEC" },
				new MarketsModel { Rank = 57, DecimalPlaces = 5, SymbolString = "ZIL" },
				new MarketsModel { Rank = 58, DecimalPlaces = 4, SymbolString = "ETC" },
				new MarketsModel { Rank = 59, DecimalPlaces = 2, SymbolString = "UMA" },
				new MarketsModel { Rank = 60, DecimalPlaces = 2, SymbolString = "YFI" },
				//// #61 is HBTC
				//// #62 is NEXO
				new MarketsModel { Rank = 63, DecimalPlaces = 2, SymbolString = "RUNE" }, // from ALT source
				new MarketsModel { Rank = 64, DecimalPlaces = 2, SymbolString = "NEAR" }, // from ALT source
				new MarketsModel { Rank = 65, DecimalPlaces = 4, SymbolString = "ZRX" },
				new MarketsModel { Rank = 66, DecimalPlaces = 2, SymbolString = "REN" },
				new MarketsModel { Rank = 67, DecimalPlaces = 2, SymbolString = "WAVES" },
				//// #68 is XSUSHI
				new MarketsModel { Rank = 69, DecimalPlaces = 2, SymbolString = "ICX" },
				new MarketsModel { Rank = 70, DecimalPlaces = 2, SymbolString = "STX" },
				new MarketsModel { Rank = 71, DecimalPlaces = 5, SymbolString = "HBAR" }, // from ALT source
				//// #72 is AMP
				new MarketsModel { Rank = 73, DecimalPlaces = 7, SymbolString = "BTT" },
				//// #74 is MDX
				new MarketsModel { Rank = 75, DecimalPlaces = 5, SymbolString = "MATIC" },
				//// #76 is RENBTC
				//// #77 is CHSB
				new MarketsModel { Rank = 78, DecimalPlaces = 6, SymbolString = "IOST" },
				new MarketsModel { Rank = 79, DecimalPlaces = 4, SymbolString = "ALGO" },
				new MarketsModel { Rank = 80, DecimalPlaces = 4, SymbolString = "PAX" },
				new MarketsModel { Rank = 81, DecimalPlaces = 5, SymbolString = "DGB" },
				new MarketsModel { Rank = 82, DecimalPlaces = 2, SymbolString = "ONT" },
				new MarketsModel { Rank = 83, DecimalPlaces = 2, SymbolString = "NANO" },
				new MarketsModel { Rank = 84, DecimalPlaces = 4, SymbolString = "BAT" },
				new MarketsModel { Rank = 85, DecimalPlaces = 5, SymbolString = "LRC" },
				//// #86 is ZKS
				new MarketsModel { Rank = 87, DecimalPlaces = 4, SymbolString = "OMG" },
				//// #88 is HUSD
				new MarketsModel { Rank = 89, DecimalPlaces = 2, SymbolString = "BNT" },
				//// #90 is UST
				new MarketsModel { Rank = 91, DecimalPlaces = 2, SymbolString = "ZEN" },
				new MarketsModel { Rank = 92, DecimalPlaces = 3, SymbolString = "QTUM" },
				new MarketsModel { Rank = 93, DecimalPlaces = 7, SymbolString = "NPXS" },
				new MarketsModel { Rank = 94, DecimalPlaces = 7, SymbolString = "HOT" },
				////new MarketsModel { Rank = 95, DecimalPlaces = 2, SymbolString = "XVS" }, // NEED PNG
				new MarketsModel { Rank = 96, DecimalPlaces = 5, SymbolString = "ENJ" },
				//// #97 is BTMX
				new MarketsModel { Rank = 98, DecimalPlaces = 2, SymbolString = "CRV" }, // from ALT source
				new MarketsModel { Rank = 99, DecimalPlaces = 7, SymbolString = "SC" },
				//// # 100 is BTG
				new MarketsModel { Rank = 118, DecimalPlaces = 3, SymbolString = "KNC" },
				new MarketsModel { Rank = 149, DecimalPlaces = 3, SymbolString = "SXP" },
			};

			Markets = new List<MarketsModel>(markets);
		}

		/// <summary>Get ordered markets feed list.</summary>
		/// <returns>IEnumerable{MarketsModel} ordered by rank.</returns>
		internal static IEnumerable<MarketsModel> GetMarketsForFeed()
		{
			var x = Markets.OrderBy(n => n.Rank);
			////string y = JsonSerializer.Serialize(x);
			////string z = y;
			return Markets.OrderBy(n => n.Rank);
		}

		/// <summary>Gets the markets WSS stream.</summary>
		/// <returns>WSS stream.</returns>
		internal static string MarketsWss()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("wss://stream.binance.com:9443/stream?streams=");
			foreach (MarketsModel market in GetMarketsForFeed())
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