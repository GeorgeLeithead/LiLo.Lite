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
	using System.Collections.Generic;
	using System.ComponentModel;
	using System.Linq;
	using System.Text.Json;
	using System.Threading.Tasks;
	using Lilo.Lite.Services;
	using LiLo.Lite.Models.BinanceModels;
	using LiLo.Lite.Models.Markets;
	using LiLo.Lite.Services.Dialog;
	using WebSocketSharp;
	using Xamarin.CommunityToolkit.ObjectModel;
	using Xamarin.Forms;

	/// <summary>Markets helper service.</summary>
	public class MarketsHelperService : NotifyPropertyChangedBase, IMarketsHelperService
	{
		private IDialogService dialogService;

		/// <summary>Initialises a new instance of the <see cref="MarketsHelperService" /> class.</summary>
		public MarketsHelperService()
		{
			this.MarketsList = new ObservableRangeCollection<MarketsModel>();
		}

		/// <summary>Raised when a public property of this object is set.</summary>
		public override event PropertyChangedEventHandler PropertyChanged
		{
			add { base.PropertyChanged += value; }
			remove { base.PropertyChanged -= value; }
		}

		public IDialogService DialogService => this.dialogService ??= DependencyService.Resolve<DialogService>();

		/// <summary>Gets or sets an observable list of markets.</summary>
		public ObservableRangeCollection<MarketsModel> MarketsList { get; set; }

		public string GetWss()
		{
			return DataStore.MarketsWss();
		}

		/// <summary>Initialises task for the markets helper service.</summary>
		/// <returns>Task results of initialisation.</returns>
		public void Init()
		{
			IEnumerable<MarketsModel> markets = DataStore.GetMarketsForFeed();
			foreach (MarketsModel market in markets)
			{
				if (!this.MarketsList.Any(m => m == market))
				{
					this.MarketsList.Add(market);
				}
			}
		}

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
					await this.GetMessageType(e.Data);
				}
				catch (Exception ex)
				{
					await this.DialogService.ShowToastAsync(ex.Message);
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

			BinanceTickerModel binanceStream = JsonSerializer.Deserialize<BinanceTickerModel>(message);
			if (binanceStream.Data != null)
			{
				await BinanceTickerDataModel.UpdateMarketList(binanceStream.Data, this.MarketsList);
			}

			await Task.FromResult(true);
		}
	}
}