//-----------------------------------------------------------------------
// <copyright file="SocketsService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Web Sockets Service interface.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Services.Sockets
{
	using System;
	using System.ComponentModel;
	using System.Threading.Tasks;
	using Lilo.Lite.Services;
	using LiLo.Lite.Services.Dialog;
	using LiLo.Lite.Services.Markets;
	using WebSocketSharp;
	using Xamarin.Forms;

	/// <summary>Web Sockets Service interface.</summary>
	public class SocketsService : NotifyPropertyChangedBase, ISocketsService
	{
		private IDialogService dialogService;
		private IMarketsHelperService marketsHelperService;

		/// <summary>Has the service been resumed.</summary>
		private bool isResumed;

		/// <summary>Web Socket.</summary>
		private WebSocket webSocket;

		private IMarketsHelperService MarketsHelperService => this.marketsHelperService ??= DependencyService.Resolve<MarketsHelperService>();
		public IDialogService DialogService => this.dialogService ??= DependencyService.Resolve<DialogService>();

		/// <summary>Raised when a public property of this object is set.</summary>
		public override event PropertyChangedEventHandler PropertyChanged
		{
			add { base.PropertyChanged += value; }
			remove { base.PropertyChanged -= value; }
		}

		/// <summary>Gets a value indicating whether the sockets service is connected.</summary>
		public bool IsConnected => this.webSocket.ReadyState == WebSocketState.Open;

		public async Task Connect()
		{
			string wss = "wss://stream.binance.com:9443/stream?streams=adausdt@ticker/algousdt@ticker/atomusdt@ticker/batusdt@ticker/bchusdt@ticker/bnbusdt@ticker/btcusdt@ticker/compusdt@ticker/dashusdt@ticker/dogeusdt@ticker/eosusdt@ticker/etcusdt@ticker/ethusdt@ticker/iostusdt@ticker/iotausdt@ticker/kncusdt@ticker/linkusdt@ticker/ltcusdt@ticker/neousdt@ticker/omgusdt@ticker/ontusdt@ticker/qtumusdt@ticker/sxpusdt@ticker/thetausdt@ticker/trxusdt@ticker/vetusdt@ticker/xlmusdt@ticker/xmrusdt@ticker/xrpusdt@ticker/xtzusdt@ticker/zecusdt@ticker/zilusdt@ticker/zrxusdt@ticker";
			this.webSocket = new WebSocket(wss)
			{
				EmitOnPing = true
			};
			this.webSocket.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12;
			this.webSocket.SslConfiguration.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyError) =>
			{
				return true;
			};

			await this.WebSocket_OnResume();
		}

		/// <summary>Handle when the application closes the sockets connection.</summary>
		/// <returns>Successful task</returns>
		public async Task WebSocket_Close()
		{
			await Task.Factory.StartNew(async () =>
			{
				if (this.webSocket == null)
				{
					await Task.FromResult(true);
					return;
				}

				if (this.webSocket.IsAlive)
				{
					this.webSocket.CloseAsync(CloseStatusCode.Normal);
				}

				await Task.FromResult(true);
			});
		}

		/// <summary>Handle when the application requests a sockets connection.</summary>
		/// <returns>Successful task.</returns>
		public async Task WebSocket_OnConnect()
		{
			await Task.Factory.StartNew(async () =>
			{
				if (Device.RuntimePlatform != Device.UWP)
				{
					this.webSocket.ConnectAsync();
				}
				else
				{
					this.webSocket.Connect();
				}

				await Task.FromResult(true);
			});
		}

		/// <summary>Handle when the application resumes from sleep.</summary>
		/// <returns>Successful task</returns>
		public async Task WebSocket_OnResume()
		{
			if (!this.isResumed)
			{
				this.webSocket.OnClose += this.WebSocket_OnClose;
				this.webSocket.OnError += this.WebSocket_OnError;
				this.webSocket.OnOpen += this.WebSocket_OnOpen;
				this.webSocket.OnMessage += this.WebSocket_OnMessage;
				this.webSocket.OnMessage += this.MarketsHelperService.WebSockets_OnMessageAsync;
				await this.WebSocket_OnConnect();
				this.isResumed = true;
			}

			await Task.FromResult(true);
		}

		/// <summary>Handle when the application goes into sleep.</summary>
		/// <returns>Successful task</returns>
		public async Task WebSocket_OnSleep()
		{
			if (this.isResumed)
			{
				this.webSocket.OnClose -= this.WebSocket_OnClose;
				this.webSocket.OnError -= this.WebSocket_OnError;
				this.webSocket.OnOpen -= this.WebSocket_OnOpen;
				this.webSocket.OnMessage -= this.MarketsHelperService.WebSockets_OnMessageAsync;
				this.webSocket.OnMessage -= this.WebSocket_OnMessage;
				this.webSocket.CloseAsync(CloseStatusCode.Normal);
				this.isResumed = false;
			}

			await Task.FromResult(true);
		}

		/// <summary>Handle when the sockets connection closes.</summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Close event arguments</param>
		private async void WebSocket_OnClose(object sender, CloseEventArgs e)
		{
			await Task.Factory.StartNew(async () =>
			{
				while (!this.webSocket.IsAlive)
				{
					Task.Delay(1000).Wait();
					await this.WebSocket_OnConnect();
				}
			});
		}

		/// <summary>Handle when the sockets connection errors.</summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Error event arguments</param>
		private void WebSocket_OnError(object sender, ErrorEventArgs e)
		{
			this.DialogService.ShowToastAsync(e.Message).ConfigureAwait(true);
		}

		/// <summary>Handle when the sockets connection receives a message.</summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Message event arguments</param>
		private async void WebSocket_OnMessage(object sender, MessageEventArgs e)
		{
			await Task.Factory.StartNew(async () =>
			{
				if (e.IsText)
				{
					this.webSocket.OnMessage -= this.WebSocket_OnMessage;
				}

				await Task.FromResult(true);
			});
		}

		/// <summary>Handle when the sockets connection is opened.</summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Event arguments</param>
		private async void WebSocket_OnOpen(object sender, EventArgs e)
		{
			await Task.Factory.StartNew(async () =>
			{
				string Subscription = "{\"method\":\"SUBSCRIBE\",\"id\": 1,\"params\": [\"adausdt@ticker\",\"algousdt@ticker\",\"atomusdt@ticker\",\"batusdt@ticker\",\"bchusdt@ticker\",\"bnbusdt@ticker\",\"btcusdt@ticker\",\"compusdt@ticker\",\"dashusdt@ticker\",\"dogeusdt@ticker\",\"eosusdt@ticker\",\"etcusdt@ticker\",\"ethusdt@ticker\",\"iostusdt@ticker\",\"iotausdt@ticker\",\"kncusdt@ticker\",\"linkusdt@ticker\",\"ltcusdt@ticker\",\"neousdt@ticker\",\"omgusdt@ticker\",\"ontusdt@ticker\",\"qtumusdt@ticker\",\"sxpusdt@ticker\",\"thetausdt@ticker\",\"trxusdt@ticker\",\"vetusdt@ticker\",\"xlmusdt@ticker\",\"xmrusdt@ticker\",\"xrpusdt@ticker\",\"xtzusdt@ticker\",\"zecusdt@ticker\",\"zilusdt@ticker\",\"zrxusdt@ticker\"]}";
				this.webSocket.Send(Subscription);
				await Task.FromResult(true);
			});
		}
	}
}