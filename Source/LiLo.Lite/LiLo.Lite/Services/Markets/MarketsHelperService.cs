﻿// <copyright file="MarketsHelperService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Services.Markets
{
	using LiLo.Lite.Models.BinanceModels;
	using LiLo.Lite.Models.Markets;
	using LiLo.Lite.Services.Dialog;
	using LiLo.Lite.Services.LocalNotification;
	using System;
	using System.Collections.Generic;
	using System.Text.Json;
	using System.Threading.Tasks;
	using WebSocketSharp;
	using Xamarin.CommunityToolkit.ObjectModel;
	using Xamarin.Forms;

	/// <summary>Markets helper service.</summary>
	public class MarketsHelperService : IMarketsHelperService
	{
		private IDialogService dialogService;
		private INotificationManager notificationManager;

		/// <summary>Initialises a new instance of the <see cref="MarketsHelperService" /> class.</summary>
		public MarketsHelperService()
		{
			MarketsList = new ObservableRangeCollection<MarketModel>();
		}

		/// <summary>Gets the dialogue service.</summary>
		public IDialogService DialogService => dialogService ??= DependencyService.Resolve<DialogService>();

		/// <summary>Gets or sets an observable list of markets.</summary>
		public ObservableRangeCollection<MarketModel> MarketsList { get; set; }

		/// <summary>Gets the local notification manager.</summary>
		public INotificationManager NotificationManager => notificationManager ??= DependencyService.Get<INotificationManager>();

		/// <summary>Gets or sets an list of markets.</summary>
		public List<MarketModel> SourceMarketsList { get; set; } = new List<MarketModel>();

		/// <summary>Get WSS connection.</summary>
		/// <returns>Connection string.</returns>
		public string GetWss()
		{
			return DataStore.MarketsWss();
		}

		/// <summary>Initialises task for the markets helper service.</summary>
		/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
		public async Task Init()
		{
			_ = await Task.Factory.StartNew(async () =>
			{
				IEnumerable<MarketModel> markets = DataStore.GetMarketsForFeed();
				MarketsList.Clear();
				SourceMarketsList.Clear();
				foreach (MarketModel market in markets)
				{
					MarketsList.Add(market);
					SourceMarketsList.Add(market);
				}

				await Task.Delay(1);
			});
		}

		/// <summary>WebSockets message handler.</summary>
		/// <param name="sender">Sockets service.</param>
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
					await DialogService.ShowToastAsync(ex.Message);
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
				await BinanceTickerDataModel.UpdateMarketList(binanceStream.Data, MarketsList);
				await PriceNotifications.SendNotification(binanceStream.Data, NotificationManager);
			}

			_ = await Task.FromResult(true);
		}
	}
}