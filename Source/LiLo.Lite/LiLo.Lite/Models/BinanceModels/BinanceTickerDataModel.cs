// <copyright file="BinanceTickerDataModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Models.BinanceModels
{
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Text.Json.Serialization;
	using System.Threading.Tasks;
	using LiLo.Lite.Models.Markets;
	using Xamarin.CommunityToolkit.ObjectModel;

	/// <summary>Binance ticker symbol stream data.</summary>
	public class BinanceTickerDataModel
	{
		private readonly CultureInfo enusCultureFormat = new CultureInfo("en-US");

		/// <summary>Gets or sets close price.</summary>
		[JsonPropertyName("c")]
		public string CurrentPrice { get; set; }

		/// <summary>Gets or sets high price.</summary>
		[JsonPropertyName("h")]
		public string HighPrice { get; set; }

		/// <summary>Gets the 24hr high price.</summary>
		public double HighPrice24h => Convert.ToDouble(this.HighPrice, this.enusCultureFormat);

		/// <summary>Gets the last price.</summary>
		public double LastPrice => Convert.ToDouble(this.CurrentPrice, this.enusCultureFormat);

		/// <summary>Gets or sets the low price.</summary>
		[JsonPropertyName("l")]
		public string LowPrice { get; set; }

		/// <summary>Gets the 24hr low price.</summary>
		public double LowPrice24h => Convert.ToDouble(this.LowPrice, this.enusCultureFormat);

		/// <summary>Gets or sets the price change percent.</summary>
		[JsonPropertyName("P")]
		public string Percent { get; set; }

		/// <summary>Gets or sets the price change.</summary>
		[JsonPropertyName("p")]
		public string PChange { get; set; }

		/// <summary>Gets the price change.</summary>
		public double PriceChange => Convert.ToDouble(this.PChange, this.enusCultureFormat);

		/// <summary>Gets the 24hr price change percent.</summary>
		public double Price24hPercent => Convert.ToDouble(this.Percent, this.enusCultureFormat);

		/// <summary>Gets or sets the symbol.</summary>
		[JsonPropertyName("s")]
		public string SymbolString { get; set; }

		/// <summary>Updates the market list data.</summary>
		/// <param name="data">Ticker data.</param>
		/// <param name="marketsList">Markets list.</param>
		/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
		public static async Task UpdateMarketList(BinanceTickerDataModel data, ObservableRangeCollection<MarketModel> marketsList)
		{
			if (data is null)
			{
				throw new ArgumentNullException(nameof(data));
			}

			MarketModel clientItem = marketsList.SingleOrDefault(nl => (nl.SymbolString + "USDT") == data.SymbolString);
			if (clientItem == null)
			{
				await Task.FromResult(true);
				return;
			}

			if (data.LastPrice != 0)
			{
				clientItem.LastPrice = data.LastPrice;
			}

			if (data.Price24hPercent != 0)
			{
				clientItem.Price24hPercent = data.Price24hPercent;
			}

			if (data.LowPrice24h != 0)
			{
				clientItem.LowPrice24h = data.LowPrice24h;
			}

			if (data.HighPrice24h != 0)
			{
				clientItem.HighPrice24h = data.HighPrice24h;
			}
		}
	}
}