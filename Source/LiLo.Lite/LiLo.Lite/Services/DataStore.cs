using System;
using System.Collections.Generic;
using System.Linq;
using LiLo.Lite.Models.Markets;
using LiLo.Lite.Models.Provider;

namespace LiLo.Lite.Services
{
	public static class DataStore
	{
		public static List<MarketsModel> Markets;

		public static List<ProvidersModel> Providers;

		static DataStore()
		{
			List<MarketsModel> markets = new List<MarketsModel>
			{
				// Binance Futures (MainNet)
				new MarketsModel { FeedProvider = "BINANCE", Rank = 7, DecimalPlaces = 5, ItemImage = "ada.png", SymbolString = "ADAUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 45, DecimalPlaces = 4, ItemImage = "algo.png", SymbolString = "ALGOUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 25, DecimalPlaces = 3, ItemImage = "atom.png", SymbolString = "ATOMUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 33, DecimalPlaces = 4, ItemImage = "bat.png", SymbolString = "BATUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 5, DecimalPlaces = 2, ItemImage = "bch.png", SymbolString = "BCHUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 10, DecimalPlaces = 4, ItemImage = "bnb.png", SymbolString = "BNBUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 1, DecimalPlaces = 2, ItemImage = "btc.png", SymbolString = "BTCUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 37, DecimalPlaces = 2, ItemImage = "comp.png", SymbolString = "COMPUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 23, DecimalPlaces = 2, ItemImage = "dash.png", SymbolString = "DASHUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 30, DecimalPlaces = 7, ItemImage = "doge.png", SymbolString = "DOGEUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 11, DecimalPlaces = 4, ItemImage = "eos.png", SymbolString = "EOSUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 21, DecimalPlaces = 4, ItemImage = "etc.png", SymbolString = "ETCUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 2, DecimalPlaces = 2, ItemImage = "eth.png", SymbolString = "ETHUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 90, DecimalPlaces = 6, ItemImage = "iost.png", SymbolString = "IOSTUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 24, DecimalPlaces = 4, ItemImage = "iota.png", SymbolString = "IOTAUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 41, DecimalPlaces = 3, ItemImage = "knc.png", SymbolString = "KNCUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 12, DecimalPlaces = 4, ItemImage = "link.png", SymbolString = "LINKUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 8, DecimalPlaces = 2, ItemImage = "ltc.png", SymbolString = "LTCUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 22, DecimalPlaces = 3, ItemImage = "neo.png", SymbolString = "NEOUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 48, DecimalPlaces = 4, ItemImage = "omg.png", SymbolString = "OMGUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 28, DecimalPlaces = 4, ItemImage = "ont.png", SymbolString = "ONTUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 47, DecimalPlaces = 3, ItemImage = "qtum.png", SymbolString = "QTUMUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 83, DecimalPlaces = 3, ItemImage = "sxp.png", SymbolString = "SXPUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 51, DecimalPlaces = 5, ItemImage = "theta.png", SymbolString = "THETAUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 16, DecimalPlaces = 5, ItemImage = "trx.png", SymbolString = "TRXUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 20, DecimalPlaces = 6, ItemImage = "vet.png", SymbolString = "VETUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 14, DecimalPlaces = 5, ItemImage = "xlm.png", SymbolString = "XLMUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 15, DecimalPlaces = 2, ItemImage = "xmr.png", SymbolString = "XMRUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 3, DecimalPlaces = 5, ItemImage = "xrp.png", SymbolString = "XRPUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 13, DecimalPlaces = 4, ItemImage = "xtz.png", SymbolString = "XTZUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 26, DecimalPlaces = 2, ItemImage = "zec.png", SymbolString = "ZECUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 54, DecimalPlaces = 5, ItemImage = "zil.png", SymbolString = "ZILUSDT" },
				new MarketsModel { FeedProvider = "BINANCE", Rank = 43, DecimalPlaces = 4, ItemImage = "zrx.png", SymbolString = "ZRXUSDT" },

				// ByBit Perpetual
				new MarketsModel { FeedProvider = "BYBIT", Rank = 1, DecimalPlaces = 2, ItemImage = "btc.png", SymbolString = "BTCUSD" },
				new MarketsModel { FeedProvider = "BYBIT", Rank = 2, DecimalPlaces = 2, ItemImage = "eth.png", SymbolString = "ETHUSD" },
				new MarketsModel { FeedProvider = "BYBIT", Rank = 11, DecimalPlaces = 3, ItemImage = "eos.png", SymbolString = "EOSUSD" },
				new MarketsModel { FeedProvider = "BYBIT", Rank = 3, DecimalPlaces = 4, ItemImage = "xrp.png", SymbolString = "XRPUSD" },

				// ByBit (TestNet) Perpetual
				new MarketsModel { FeedProvider = "BYBITTestNet", Rank = 1, DecimalPlaces = 2, ItemImage = "btc.png", SymbolString = "BTCUSD" },
				new MarketsModel { FeedProvider = "BYBITTestNet", Rank = 2, DecimalPlaces = 2, ItemImage = "eth.png", SymbolString = "ETHUSD" },
				new MarketsModel { FeedProvider = "BYBITTestNet", Rank = 11, DecimalPlaces = 3, ItemImage = "eos.png", SymbolString = "EOSUSD" },
				new MarketsModel { FeedProvider = "BYBITTestNet", Rank = 3, DecimalPlaces = 4, ItemImage = "xrp.png", SymbolString = "XRPUSD" },
			};

			Markets = new List<MarketsModel>(markets);

			List<ProvidersModel> providers = new List<ProvidersModel>
			{
				new ProvidersModel {
					Provider = "BINANCE",
					IsSelected = true,
					Title = "Binance",
					DisplayName = "Binance Futures",
					TradingView = "BINANCE",
					Wss = new Uri("wss://stream.binance.com:9443/stream?streams=adausdt@ticker/algousdt@ticker/atomusdt@ticker/batusdt@ticker/bchusdt@ticker/bnbusdt@ticker/btcusdt@ticker/compusdt@ticker/dashusdt@ticker/dogeusdt@ticker/eosusdt@ticker/etcusdt@ticker/ethusdt@ticker/iostusdt@ticker/iotausdt@ticker/kncusdt@ticker/linkusdt@ticker/ltcusdt@ticker/neousdt@ticker/omgusdt@ticker/ontusdt@ticker/qtumusdt@ticker/sxpusdt@ticker/thetausdt@ticker/trxusdt@ticker/vetusdt@ticker/xlmusdt@ticker/xmrusdt@ticker/xrpusdt@ticker/xtzusdt@ticker/zecusdt@ticker/zilusdt@ticker/zrxusdt@ticker"),
					Subscription = "{\"method\":\"SUBSCRIBE\",\"id\": 1,\"params\": [\"adausdt@ticker\",\"algousdt@ticker\",\"atomusdt@ticker\",\"batusdt@ticker\",\"bchusdt@ticker\",\"bnbusdt@ticker\",\"btcusdt@ticker\",\"compusdt@ticker\",\"dashusdt@ticker\",\"dogeusdt@ticker\",\"eosusdt@ticker\",\"etcusdt@ticker\",\"ethusdt@ticker\",\"iostusdt@ticker\",\"iotausdt@ticker\",\"kncusdt@ticker\",\"linkusdt@ticker\",\"ltcusdt@ticker\",\"neousdt@ticker\",\"omgusdt@ticker\",\"ontusdt@ticker\",\"qtumusdt@ticker\",\"sxpusdt@ticker\",\"thetausdt@ticker\",\"trxusdt@ticker\",\"vetusdt@ticker\",\"xlmusdt@ticker\",\"xmrusdt@ticker\",\"xrpusdt@ticker\",\"xtzusdt@ticker\",\"zecusdt@ticker\",\"zilusdt@ticker\",\"zrxusdt@ticker\"]}"
				},
				new ProvidersModel {
					Provider = "BYBIT",
					Title = "ByBit",
					DisplayName = "ByBit Perpetual",
					TradingView = "BYBIT",
					Wss = new Uri("wss://stream.bybit.com/realtime"),
					Subscription = "{\"op\":\"subscribe\",\"args\": [\"instrument_info.100ms.BTCUSD|ETHUSD|EOSUSD|XRPUSD\"]}"
				},
/*				new ProvidersModel {
					Provider = "BYBITTestNet",
					Title = "ByBit (TestNet)",
					DisplayName = "ByBit (TestNet) Perpetual",
					TradingView = "BYBIT",
					Wss = new Uri("wss://stream-testnet.bybit.com/realtime"),
					Subscription = "{\"op\":\"subscribe\",\"args\": [\"instrument_info.100ms.BTCUSD|ETHUSD|EOSUSD|XRPUSD\"]}"
				},
*/
			};

			Providers = new List<ProvidersModel>(providers);
		}

		internal static ProvidersModel GetFeed()
		{
			return Providers.FirstOrDefault(p => p.IsSelected);
		}

		internal static IEnumerable<MarketsModel> GetMarketsForFeed()
		{
			string obj = GetFeed().Provider;
			return Markets.Where(n => n.FeedProvider.Equals(obj));
		}

		internal static void SetFeed(string providerName)
		{
			Providers.All(p => p.IsSelected = false);
			var selectedProvider = Providers.FirstOrDefault(p => p.Provider.Equals(providerName));
			if (selectedProvider != null)
			{
				selectedProvider.IsSelected = true;
			} else
			{
				Providers[0].IsSelected = true;
			}
		}
	}
}