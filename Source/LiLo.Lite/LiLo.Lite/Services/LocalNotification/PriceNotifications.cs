// <copyright file="PriceNotifications.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>

namespace LiLo.Lite.Services.LocalNotification
{
	using System;
	using System.Threading.Tasks;
	using LiLo.Lite.Models.BinanceModels;
	using Xamarin.Essentials;

	/// <summary>Local price notifications class.</summary>
	public static class PriceNotifications
	{
		/// <summary>Send notification.</summary>
		/// <param name="data">Data feed.</param>
		/// <param name="notificationManager">Notification Manager.</param>
		/// <remarks>Target price: Alert Symbol, Alert Price, One time/Every time, IsActive
		/// Price Change: Alert Symbol, Percent, Duration (Binance only offers 24hr), IsActive.
		/// </remarks>
		/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
		public static async Task SendNotification(BinanceTickerDataModel data, INotificationManager notificationManager)
		{
			string targetPriceAlert = Preferences.Get($"TargetAlert{data.SymbolString}", string.Empty);
			string changePriceAlert = Preferences.Get($"ChangeAlert{data.SymbolString}", string.Empty);
			if (!string.IsNullOrEmpty(targetPriceAlert))
			{
				await SendTargetPriceAlert(notificationManager, data, targetPriceAlert);
			}

			if (!string.IsNullOrEmpty(changePriceAlert))
			{
				await SendChangePriceAlert(notificationManager, data, changePriceAlert);
			}

			return;
		}

		private static async Task SendTargetPriceAlert(INotificationManager notificationManager, BinanceTickerDataModel data, string targetAlerts)
		{
			if (data.LastPrice == 0 || data.PriceChange == 0)
			{
				return;
			}

			await Task.Factory.StartNew(() =>
			{
				bool changed = false;
				string[] alerts = targetAlerts.Split(';');
				for (var alertItem = 0; alertItem < alerts.Length; alertItem++)
				{
					if (string.IsNullOrWhiteSpace(alerts[alertItem]))
					{
						continue;
					}

					string[] alertDetails = alerts[alertItem].Split('|');
					bool isActive = Convert.ToBoolean(alertDetails[2]);
					if (!isActive)
					{
						continue;
					}

					double alertPrice = Convert.ToDouble(alertDetails[0]);
					double previousPrice = data.LastPrice + data.PriceChange;

					if (previousPrice < alertPrice && data.LastPrice >= alertPrice)
					{
						SendNotification(notificationManager, data.SymbolString, data.CurrentPrice, alertDetails[0], '≥');
						changed = true;
						alertDetails[2] = false.ToString();
						alerts[alertItem] = string.Join('|', alertDetails); // Set the alert IsActive to FALSE
					}

					if (previousPrice > alertPrice && data.LastPrice <= alertPrice)
					{
						SendNotification(notificationManager, data.SymbolString, data.CurrentPrice, alertDetails[0], '≤');
						changed = true;
						alertDetails[2] = false.ToString();
						alerts[alertItem] = string.Join('|', alertDetails); // Set the alert IsActive to FALSE
					}
				}

				if (changed)
				{
					Preferences.Set($"TargetAlert{data.SymbolString}", string.Join(';', alerts)); // Update the alerts to signify we made one or more alert(s) inactive
				}

				return;
			});
		}

		private static void SendNotification(INotificationManager notificationManager, string symbol, string currentPrice, string alertPrice, char priceChangeSymbol)
		{
			notificationManager.SendNotification(symbol.Replace("USDT", string.Empty), $"Price alert: {currentPrice} {priceChangeSymbol} {alertPrice}");
		}

		private static async Task SendChangePriceAlert(INotificationManager notificationManager, BinanceTickerDataModel data, string targetAlerts)
		{
			await Task.Factory.StartNew(() =>
			{
				return;
			});
		}
	}
}