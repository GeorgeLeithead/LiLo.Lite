// <copyright file="SocketsService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Services.Sockets
{
	using LiLo.Lite.Services.Dialog;
	using LiLo.Lite.Services.Markets;
	using System.Diagnostics;
	using System.Threading.Tasks;
	using WebSocketSharp;
	using Xamarin.Forms;

	/// <summary>Web Sockets Service interface.</summary>
	public class SocketsService : ISocketsService
	{
		private readonly int delayBetweenTries = 3000;

		private IDialogService dialogService;

		/// <summary>Has the service been resumed.</summary>
		private bool isResumed;

		private IMarketsHelperService marketsHelperService;

		private int numberOfTries = 0;

		/// <summary>Web Socket.</summary>
		private WebSocket webSocket;

		/// <summary>Initialises a new instance of the <see cref="SocketsService"/> class.</summary>
		public SocketsService()
		{
		}

		/// <summary>Gets the dialogue service.</summary>
		public IDialogService DialogService => dialogService ??= DependencyService.Resolve<DialogService>();

		/// <summary>Gets a value indicating whether the sockets service is connected.</summary>
		private bool IsConnected => webSocket.ReadyState == WebSocketState.Open;

		private IMarketsHelperService MarketsHelperService => marketsHelperService ??= DependencyService.Resolve<MarketsHelperService>();

		/// <summary>Connects to the Sockets Service.</summary>
		/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
		public async Task Connect()
		{
			string wss = MarketsHelperService.GetWss();
			webSocket = new WebSocket(wss)
			{
				EmitOnPing = true,
			};
			webSocket.SslConfiguration.EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12;
			webSocket.SslConfiguration.ServerCertificateValidationCallback = (sender, certificate, chain, sslPolicyError) =>
			{
				return true;
			};

			await WebSocket_OnResume();
		}

		/// <summary>Handle when the application closes the sockets connection.</summary>
		/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
		public async Task WebSocket_Close()
		{
			_ = await Task.Factory.StartNew(async () =>
			{
				if (!IsConnected)
				{
					return;
				}

				await DialogService.ShowToastAsync("Closing connection!");
				if (webSocket == null)
				{
					_ = await Task.FromResult(true);
					return;
				}

				if (webSocket.IsAlive)
				{
					webSocket.CloseAsync(CloseStatusCode.Normal);
				}

				_ = await Task.FromResult(true);
			});
		}

		/// <summary>Handle when the application requests a sockets connection.</summary>
		/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
		public async Task WebSocket_OnConnect()
		{
			_ = await Task.Factory.StartNew(async () =>
			{
				if (IsConnected)
				{
					return;
				}

				await DialogService.ShowToastAsync("Connecting...");
				try
				{
					if (Device.RuntimePlatform != Device.UWP)
					{
						webSocket.ConnectAsync();
					}
					else
					{
						webSocket.Connect();
					}

					numberOfTries = 1;
				}
				catch (System.Net.Sockets.SocketException)
				{
					numberOfTries += 1;
					Debug.WriteLine($"Lost connection, awaiting {numberOfTries}");
					Task.Delay(numberOfTries * delayBetweenTries).Wait();
					await WebSocket_OnConnect();
				}

				_ = await Task.FromResult(true);
			});
		}

		/// <summary>Handle when the application resumes from sleep.</summary>
		/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
		public async Task WebSocket_OnResume()
		{
			if (!isResumed)
			{
				webSocket.OnMessage += MarketsHelperService.WebSockets_OnMessageAsync;
				webSocket.OnMessage += WebSocket_OnMessage;
				webSocket.OnError += WebSocket_OnError;
				webSocket.OnClose += WebSocket_OnClose;
				await WebSocket_OnConnect();
				isResumed = true;
			}

			_ = await Task.FromResult(true);
		}

		/// <summary>Handle when the application goes into sleep.</summary>
		/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
		public async Task WebSocket_OnSleep()
		{
			if (isResumed)
			{
				webSocket.OnClose -= WebSocket_OnClose;
				webSocket.OnError -= WebSocket_OnError;
				webSocket.OnMessage -= MarketsHelperService.WebSockets_OnMessageAsync;
				webSocket.OnMessage -= WebSocket_OnMessage;
				webSocket.CloseAsync(CloseStatusCode.Normal);
				isResumed = false;
			}

			_ = await Task.FromResult(true);
		}

		/// <summary>Handle when the sockets connection closes.</summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Close event arguments.</param>
		private async void WebSocket_OnClose(object sender, CloseEventArgs e)
		{
			_ = await Task.Factory.StartNew(async () =>
			{
				if (IsConnected)
				{
					return;
				}

				await DialogService.ShowToastAsync("Disconnected!");
				while (!webSocket.IsAlive)
				{
					numberOfTries += 1;
					Debug.WriteLine($"Lost connection, awaiting {numberOfTries}");
					Task.Delay(numberOfTries * delayBetweenTries).Wait();
					await WebSocket_OnConnect();
				}

				numberOfTries = 1;
			});
		}

		/// <summary>Handle when the sockets connection errors.</summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Error event arguments.</param>
		private void WebSocket_OnError(object sender, ErrorEventArgs e)
		{
			if (IsConnected)
			{
				_ = DialogService.ShowToastAsync(e.Message).ConfigureAwait(true);
			}
		}

		/// <summary>Handle when the sockets connection receives a message.</summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Message event arguments.</param>
		private async void WebSocket_OnMessage(object sender, MessageEventArgs e)
		{
			_ = await Task.Factory.StartNew(async () =>
			{
				if (e.IsText)
				{
					webSocket.OnMessage -= WebSocket_OnMessage;
				}

				_ = await Task.FromResult(true);
			});
		}
	}
}