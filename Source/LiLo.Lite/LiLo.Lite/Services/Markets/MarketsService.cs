//-----------------------------------------------------------------------
// <copyright file="MarketsService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Markets service.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Services.Markets
{
	using System.Collections.ObjectModel;
	using System.Threading.Tasks;
	using LiLo.Lite.Models.Markets;

	/// <summary>Markets service.</summary>
	public class MarketsService : IMarketsService
	{
		/// <summary>Initialises a new instance of the <see cref="MarketsService" /> class.</summary>
		public MarketsService()
		{
		}

		/// <summary>Generates a list of all available markets.</summary>
		/// <remarks>This allows us to set a default list of markets and information.</remarks>
		/// <returns>Task{ObservableCollection{MarketsModel}} of markets.</returns>
		public async Task<ObservableCollection<MarketsModel>> GetMarketsAsync()
		{
			var marketsModel = new ObservableCollection<MarketsModel>
			{
				new MarketsModel { DecimalPlaces = 5, ItemImage = "ada.png", SymbolString = Definitions.SymbolEnum.ADAUSDT.ToString() },

				new MarketsModel { DecimalPlaces = 3, ItemImage = "algo.png", SymbolString = Definitions.SymbolEnum.ALGOUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 3, ItemImage = "atom.png", SymbolString = Definitions.SymbolEnum.ATOMUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 4, ItemImage = "bat.png", SymbolString = Definitions.SymbolEnum.BATUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 2, ItemImage = "bch.png", SymbolString = Definitions.SymbolEnum.BCHUSDT.ToString() },

				new MarketsModel { DecimalPlaces = 3, ItemImage = "bnb.png", SymbolString = Definitions.SymbolEnum.BNBUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 2, ItemImage = "btc.png", SymbolString = Definitions.SymbolEnum.BTCUSDT.ToString() },


				new MarketsModel { DecimalPlaces = 2, ItemImage = "comp.png", SymbolString = Definitions.SymbolEnum.COMPUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 2, ItemImage = "dash.png", SymbolString = Definitions.SymbolEnum.DASHUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 6, ItemImage = "doge.png", SymbolString = Definitions.SymbolEnum.DOGEUSDT.ToString() },

				new MarketsModel { DecimalPlaces = 3, ItemImage = "eos.png", SymbolString = Definitions.SymbolEnum.EOSUSDT.ToString() },

				new MarketsModel { DecimalPlaces = 3, ItemImage = "etc.png", SymbolString = Definitions.SymbolEnum.ETCUSDT.ToString() },

				new MarketsModel { DecimalPlaces = 2, ItemImage = "eth.png", SymbolString = Definitions.SymbolEnum.ETHUSDT.ToString() },


				new MarketsModel { DecimalPlaces = 6, ItemImage = "iost.png", SymbolString = Definitions.SymbolEnum.IOSTUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 4, ItemImage = "iota.png", SymbolString = Definitions.SymbolEnum.IOTAUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 5, ItemImage = "knc.png", SymbolString = Definitions.SymbolEnum.KNCUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 3, ItemImage = "link.png", SymbolString = Definitions.SymbolEnum.LINKUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 2, ItemImage = "ltc.png", SymbolString = Definitions.SymbolEnum.LTCUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 3, ItemImage = "neo.png", SymbolString = Definitions.SymbolEnum.NEOUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 4, ItemImage = "omg.png", SymbolString = Definitions.SymbolEnum.OMGUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 4, ItemImage = "ont.png", SymbolString = Definitions.SymbolEnum.ONTUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 3, ItemImage = "qtum.png", SymbolString = Definitions.SymbolEnum.QTUMUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 4, ItemImage = "sxp.png", SymbolString = Definitions.SymbolEnum.SXPUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 4, ItemImage = "theta.png", SymbolString = Definitions.SymbolEnum.THETAUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 5, ItemImage = "trx.png", SymbolString = Definitions.SymbolEnum.TRXUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 6, ItemImage = "vet.png", SymbolString = Definitions.SymbolEnum.VETUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 5, ItemImage = "xlm.png", SymbolString = Definitions.SymbolEnum.XLMUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 2, ItemImage = "xmr.png", SymbolString = Definitions.SymbolEnum.XMRUSDT.ToString() },

				new MarketsModel { DecimalPlaces = 4, ItemImage = "xrp.png", SymbolString = Definitions.SymbolEnum.XRPUSDT.ToString() },

				new MarketsModel { DecimalPlaces = 3, ItemImage = "xtz.png", SymbolString = Definitions.SymbolEnum.XTZUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 2, ItemImage = "zec.png", SymbolString = Definitions.SymbolEnum.ZECUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 5, ItemImage = "zil.png", SymbolString = Definitions.SymbolEnum.ZILUSDT.ToString() },
				new MarketsModel { DecimalPlaces = 4, ItemImage = "zrx.png", SymbolString = Definitions.SymbolEnum.ZRXUSDT.ToString() },
			};
			return await Task.FromResult(marketsModel);
		}
	}
}