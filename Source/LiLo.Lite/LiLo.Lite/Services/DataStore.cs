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
	using LiLo.Lite.Models.Markets;

	/// <summary>Application data store.</summary>
	public static class DataStore
	{
		public static List<MarketsModel> Markets;

		static DataStore()
		{
			List<MarketsModel> markets = new List<MarketsModel>
			{
				// Binance Futures (MainNet)
				new MarketsModel { Rank = 7, DecimalPlaces = 5, ItemImage = "ada.png", SymbolString = "ADAUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 45, DecimalPlaces = 4, ItemImage = "algo.png", SymbolString = "ALGOUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 25, DecimalPlaces = 3, ItemImage = "atom.png", SymbolString = "ATOMUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 33, DecimalPlaces = 4, ItemImage = "bat.png", SymbolString = "BATUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 5, DecimalPlaces = 2, ItemImage = "bch.png", SymbolString = "BCHUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 10, DecimalPlaces = 4, ItemImage = "bnb.png", SymbolString = "BNBUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 1, DecimalPlaces = 2, ItemImage = "btc.png", SymbolString = "BTCUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 37, DecimalPlaces = 2, ItemImage = "comp.png", SymbolString = "COMPUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 23, DecimalPlaces = 2, ItemImage = "dash.png", SymbolString = "DASHUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 30, DecimalPlaces = 7, ItemImage = "doge.png", SymbolString = "DOGEUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 11, DecimalPlaces = 4, ItemImage = "eos.png", SymbolString = "EOSUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 21, DecimalPlaces = 4, ItemImage = "etc.png", SymbolString = "ETCUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 2, DecimalPlaces = 2, ItemImage = "eth.png", SymbolString = "ETHUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 90, DecimalPlaces = 6, ItemImage = "iost.png", SymbolString = "IOSTUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 24, DecimalPlaces = 4, ItemImage = "iota.png", SymbolString = "IOTAUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 41, DecimalPlaces = 3, ItemImage = "knc.png", SymbolString = "KNCUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 12, DecimalPlaces = 4, ItemImage = "link.png", SymbolString = "LINKUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 8, DecimalPlaces = 2, ItemImage = "ltc.png", SymbolString = "LTCUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 22, DecimalPlaces = 3, ItemImage = "neo.png", SymbolString = "NEOUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 48, DecimalPlaces = 4, ItemImage = "omg.png", SymbolString = "OMGUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 28, DecimalPlaces = 4, ItemImage = "ont.png", SymbolString = "ONTUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 47, DecimalPlaces = 3, ItemImage = "qtum.png", SymbolString = "QTUMUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 83, DecimalPlaces = 3, ItemImage = "sxp.png", SymbolString = "SXPUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 51, DecimalPlaces = 5, ItemImage = "theta.png", SymbolString = "THETAUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 16, DecimalPlaces = 5, ItemImage = "trx.png", SymbolString = "TRXUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 20, DecimalPlaces = 6, ItemImage = "vet.png", SymbolString = "VETUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 14, DecimalPlaces = 5, ItemImage = "xlm.png", SymbolString = "XLMUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 15, DecimalPlaces = 2, ItemImage = "xmr.png", SymbolString = "XMRUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 3, DecimalPlaces = 5, ItemImage = "xrp.png", SymbolString = "XRPUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 13, DecimalPlaces = 4, ItemImage = "xtz.png", SymbolString = "XTZUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 26, DecimalPlaces = 2, ItemImage = "zec.png", SymbolString = "ZECUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 54, DecimalPlaces = 5, ItemImage = "zil.png", SymbolString = "ZILUSDT", LastTickDirection = "X" },
				new MarketsModel { Rank = 43, DecimalPlaces = 4, ItemImage = "zrx.png", SymbolString = "ZRXUSDT", LastTickDirection = "X" },
			};

			Markets = new List<MarketsModel>(markets);
		}

		internal static IEnumerable<MarketsModel> GetMarketsForFeed()
		{
			return Markets.OrderBy(n => n.Rank);
		}
	}
}