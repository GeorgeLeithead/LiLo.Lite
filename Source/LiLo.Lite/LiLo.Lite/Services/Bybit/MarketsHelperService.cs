//-----------------------------------------------------------------------
// <copyright file="MarketsHelperService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Markets helper service.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Services.Bybit
{
	using System.Collections.ObjectModel;
	using System.ComponentModel;
	using System.Linq;
	using System.Text.Json;
	using System.Threading.Tasks;
	using Lilo.Lite.Services;
	using LiLo.Lite.Models.InstrumentInfo;
	using LiLo.Lite.Models.Markets;
	using LiLo.Lite.Services.Markets;
	using WebSocketSharp;

	/// <summary>Markets helper service.</summary>
	public class MarketsHelperService : NotifyPropertyChangedBase, IMarketsHelperService
	{
		/// <summary>Markets service</summary>
		private readonly IMarketsService marketService;

		/// <summary>Initialises a new instance of the <see cref="MarketsHelperService" /> class.</summary>
		/// <param name="marketServiceConstructor">Markets service constructor via dependency injection.</param>
		public MarketsHelperService(IMarketsService marketServiceConstructor)
		{
			marketService = marketServiceConstructor;
			Task.Factory.StartNew(async () =>
			{
				MarketsList = await marketService.GetMarketsAsync().ConfigureAwait(true);
			});
		}

		/// <summary>Raised when a public property of this object is set.</summary>
		public override event PropertyChangedEventHandler PropertyChanged
		{
			add { base.PropertyChanged += value; }
			remove { base.PropertyChanged -= value; }
		}

		/// <summary>Gets or sets an observable list of markets.</summary>
		public ObservableCollection<MarketsModel> MarketsList { get; set; }

		/// <summary>WebSockets message handler.</summary>
		/// <param name="sender">Sockets service</param>
		/// <param name="e">Message event arguments.</param>
		public async void WebSockets_OnMessageAsync(object sender, MessageEventArgs e)
		{
			if (sender is null)
			{
				throw new System.ArgumentNullException(nameof(sender));
			}

			if (e is null)
			{
				throw new System.ArgumentNullException(nameof(e));
			}

			if (e.IsPing)
			{
				// Do something to notify that a ping has been received.
				return;
			}

			if (e.IsText)
			{
				await GetMessageType(e.Data);
			}
		}

		/// <summary>Get the message type.</summary>
		/// <param name="message">Sockets message.</param>
		/// <returns>Task result.</returns>
		private async Task GetMessageType(string message)
		{
			if (string.IsNullOrEmpty(message))
			{
				throw new System.ArgumentException("message", nameof(message));
			}

			if (message.Contains("\"topic\":\"instrument_info"))
			{
				if (message.Contains("\"type\":\"delta\""))
				{
					InstrumentInfoDeltaModel delta = JsonSerializer.Deserialize<InstrumentInfoDeltaModel>(message);
					foreach (InstrumentInfoDataModel updateItem in delta.Data.Update)
					{
						await UpdateMarketList(updateItem);
					}
				}

				if (message.Contains("\"type\":\"snapshot\""))
				{
					InstrumentInfoSnapshotModel snapshot = JsonSerializer.Deserialize<InstrumentInfoSnapshotModel>(message);
					await UpdateMarketList(snapshot.Data);
				}
			}

			await Task.FromResult(true);
		}

		/// <summary>Update markets list.</summary>
		/// <param name="instrumentData">Sockets message</param>
		/// <returns>Task result</returns>
		private async Task UpdateMarketList(InstrumentInfoDataModel instrumentData)
		{
			if (instrumentData is null)
			{
				throw new System.ArgumentNullException(nameof(instrumentData));
			}

			MarketsModel clientItem = MarketsList.Single(nl => nl.SymbolString == instrumentData.SymbolString);
			if (clientItem == null)
			{
				await Task.FromResult(true);
			}

			if (instrumentData.LastPrice != 0)
			{
				clientItem.LastPrice = instrumentData.LastPrice;
			}

			if (!string.IsNullOrEmpty(instrumentData.LastTickDirection))
			{
				clientItem.LastTickDirection = instrumentData.LastTickDirection;
			}

			if (instrumentData.Price24hPercent != 0)
			{
				clientItem.Price24hPercent = instrumentData.Price24hPercent;
			}

			if (instrumentData.LowPrice24h != 0)
			{
				clientItem.LowPrice24h = instrumentData.LowPrice24h;
			}

			if (instrumentData.HighPrice24h != 0)
			{
				clientItem.HighPrice24h = instrumentData.HighPrice24h;
			}

			if (instrumentData.Turnover24h != 0)
			{
				clientItem.Turnover24h = instrumentData.Turnover24h;
			}

			if (instrumentData.Price1hPercent != 0)
			{
				clientItem.Price1hPercent = instrumentData.Price1hPercent;
			}

			await Task.FromResult(true);
		}
	}
}