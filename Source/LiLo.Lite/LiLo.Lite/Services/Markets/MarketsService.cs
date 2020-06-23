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
				new MarketsModel { Currency = Definitions.CurrencyEnum.BTC, CurrencyString = Definitions.CurrencyEnum.BTC.ToString(), ItemImage = "btc.png", Symbol = Definitions.SymbolEnum.BTCUSD, SymbolString = Definitions.SymbolEnum.BTCUSD.ToString(), MinPrice = 0.5, MaxPrice = 999999.5, TickSize = 0.5, MaxQuantity = 1000000 },
				new MarketsModel { Currency = Definitions.CurrencyEnum.ETH, CurrencyString = Definitions.CurrencyEnum.ETH.ToString(), ItemImage = "eth.png", Symbol = Definitions.SymbolEnum.ETHUSD, SymbolString = Definitions.SymbolEnum.ETHUSD.ToString(), MinPrice = 0.05, MaxPrice = 99999.95, TickSize = 0.05, MaxQuantity = 1000000 },
				new MarketsModel { Currency = Definitions.CurrencyEnum.EOS, CurrencyString = Definitions.CurrencyEnum.EOS.ToString(), DecimalPlaces = 3, ItemImage = "eos.png", Symbol = Definitions.SymbolEnum.EOSUSD, SymbolString = Definitions.SymbolEnum.EOSUSD.ToString(), MinPrice = 0.001, MaxPrice = 1999.999, TickSize = 0.001, MaxQuantity = 1000000 },
				new MarketsModel { Currency = Definitions.CurrencyEnum.XRP, CurrencyString = Definitions.CurrencyEnum.XRP.ToString(), DecimalPlaces = 4, ItemImage = "xrp.png", Symbol = Definitions.SymbolEnum.XRPUSD, SymbolString = Definitions.SymbolEnum.XRPUSD.ToString(), MinPrice = 0.0001, MaxPrice = 199.9999, TickSize = 0.0001, MaxQuantity = 1000000 }
			};
			return await Task.FromResult(marketsModel);
		}
	}
}
