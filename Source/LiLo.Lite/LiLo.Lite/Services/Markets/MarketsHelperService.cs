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

namespace LiLo.Lite.Services.Markets
{
	using System;
	using System.Collections.ObjectModel;
	using System.ComponentModel;
	using System.Text.Json;
	using System.Threading.Tasks;
	using Lilo.Lite.Services;
	using LiLo.Lite.Models.BinanceModels;
	using LiLo.Lite.Models.BybitModels;
	using LiLo.Lite.Models.Markets;
	using LiLo.Lite.Models.Provider;
	using LiLo.Lite.Services.Dialog;
	using WebSocketSharp;

	/// <summary>Markets helper service.</summary>
	public class MarketsHelperService : NotifyPropertyChangedBase, IMarketsHelperService
	{
		/// <summary>Dialog service</summary>
		private readonly IDialogService dialogService;

		/// <summary>Initialises a new instance of the <see cref="MarketsHelperService" /> class.</summary>
		/// <param name="marketServiceConstructor">Markets service constructor via dependency injection.</param>
		/// <param name="dialogueServiceConstructor">Dialog service constructor via dependency injection.</param>
		public MarketsHelperService(IDialogService dialogueServiceConstructor)
		{
			dialogService = dialogueServiceConstructor;
		}
		/// <summary>Initialises task for the markets helper service.</summary>
		/// <returns>Task results of initialisation.</returns>
		public Task Init()
		{
			FeedsModel = DataStore.GetFeed();
			MarketsList = new ObservableCollection<MarketsModel>(DataStore.GetMarketsForFeed());
			return Task.FromResult(true);
		}


		/// <summary>Raised when a public property of this object is set.</summary>
		public override event PropertyChangedEventHandler PropertyChanged
		{
			add { base.PropertyChanged += value; }
			remove { base.PropertyChanged -= value; }
		}

		/// <summary>Gets or sets an observable list of markets.</summary>
		public ObservableCollection<MarketsModel> MarketsList { get; set; }

		public ProvidersModel FeedsModel { get; set; }

		/// <summary>WebSockets message handler.</summary>
		/// <param name="sender">Sockets service</param>
		/// <param name="e">Message event arguments.</param>
		public async void WebSockets_OnMessageAsync(object sender, MessageEventArgs e)
		{
			if (sender is null)
			{
				throw new ArgumentNullException(nameof(sender));
			}

			if (e is null)
			{
				throw new ArgumentNullException(nameof(e));
			}

			if (e.IsPing)
			{
				// Do something to notify that a ping has been received.
				return;
			}

			if (e.IsText)
			{
				try
				{
					await GetMessageType(e.Data);
				}
				catch (Exception ex)
				{
					await dialogService.ShowToastAsync(ex.Message);
				}
			}
		}

		/// <summary>Get the message type.</summary>
		/// <param name="message">Sockets message.</param>
		/// <returns>Task result.</returns>
		private async Task GetMessageType(string message)
		{
			if (string.IsNullOrEmpty(message))
			{
				throw new ArgumentException("message", nameof(message));
			}

			if (message.Contains("\"topic\":\"instrument_info"))
			{
				if (message.Contains("\"type\":\"delta\""))
				{
					InstrumentInfoDeltaModel delta = JsonSerializer.Deserialize<InstrumentInfoDeltaModel>(message);
					foreach (InstrumentInfoDataModel updateItem in delta.Data.Update)
					{
						await InstrumentInfoDataModel.UpdateMarketList(updateItem, MarketsList);
					}
				}

				if (message.Contains("\"type\":\"snapshot\""))
				{
					InstrumentInfoSnapshotModel snapshot = JsonSerializer.Deserialize<InstrumentInfoSnapshotModel>(message);
					await InstrumentInfoDataModel.UpdateMarketList(snapshot.Data, MarketsList);
				}
			}
			if (message.Contains("\"stream\":"))
			{
				BinanceTickerModel binanceStream = JsonSerializer.Deserialize<BinanceTickerModel>(message);
				await BinanceTickerDataModel.UpdateMarketList(binanceStream.Data, MarketsList);
			}

			await Task.FromResult(true);
		}
	}
}