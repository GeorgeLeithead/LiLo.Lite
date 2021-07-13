// <copyright file="PriceNotifications.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Services.LocalNotification
{
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using LiLo.Lite.Models.BinanceModels;
	using LiLo.Lite.Models.Notifications;
	using Xamarin.Essentials;

	/// <summary>Local price notifications class.</summary>
	public static class PriceNotifications
	{
		/// <summary>Gets a list of price notifications for a given symbol.</summary>
		/// <param name="symbol">Given symbol.</param>
		/// <returns>List{priceAlertNotification} for the given symbol.</returns>
		public static List<PriceAlertNotification> GetPriceAlertNotificationList(string symbol)
		{
			List<PriceAlertNotification> alerts = new List<PriceAlertNotification>();
			List<PriceAlertNotification> targetAlerts = new List<PriceAlertNotification>();
			List<PriceAlertNotification> changeAlerts = new List<PriceAlertNotification>();
			string targetPriceAlert = Preferences.Get($"TargetAlert{symbol}", string.Empty);
			string changePriceAlert = Preferences.Get($"ChangeAlert{symbol}", string.Empty);
			if (!string.IsNullOrEmpty(targetPriceAlert))
			{
				targetAlerts = ParseNotifications(targetPriceAlert, symbol, true);
			}

			if (!string.IsNullOrEmpty(changePriceAlert))
			{
				changeAlerts = ParseNotifications(changePriceAlert, symbol, false);
			}

			alerts.AddRange(targetAlerts);
			alerts.AddRange(changeAlerts);
			return alerts;
		}

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

		/// <summary>Parse notification.</summary>
		/// <param name="alertInformation">Alert information.</param>
		/// <param name="symbol">Alert symbol.</param>
		/// <param name="isTarget">Alert type.</param>
		/// <remarks>Target price: Alert Symbol, Alert Price, One time/Every time, IsActive
		/// Price Change: Alert Symbol, Percent, Duration (Binance only offers 24hr), IsActive.
		/// </remarks>
		/// <returns>List{PriceAlertNotification} for target type.</returns>
		private static List<PriceAlertNotification> ParseNotifications(string alertInformation, string symbol, bool isTarget = true)
		{
			List<PriceAlertNotification> returnAlerts = new List<PriceAlertNotification>();
			string[] alerts = alertInformation.Split(';');
			for (int alertItem = 0; alertItem < alerts.Length; alertItem++)
			{
				if (string.IsNullOrWhiteSpace(alerts[alertItem]))
				{
					continue;
				}

				string[] alertDetails = alerts[alertItem].Split('|');
				bool alertRepeat = false;
				double alertPrice = 0;
				int alertPercent = 0;
				int alertDuration = 1440;
				if (isTarget)
				{
					alertPrice = Convert.ToDouble(alertDetails[0]);
					alertRepeat = Convert.ToBoolean(alertDetails[1]);
				}
				else
				{
					alertPercent = Convert.ToInt32(alertDetails[0]);
					alertDuration = Convert.ToInt32(alertDetails[1]);
				}

				returnAlerts.Add(new PriceAlertNotification { Symbol = symbol, AlertPercent = alertPercent, AlertPrice = alertPrice, Duration = alertDuration, IsActive = Convert.ToBoolean(alertDetails[2]), RepeatAlert = alertRepeat });
			}

			return returnAlerts;
		}

		private static async Task SendChangePriceAlert(INotificationManager notificationManager, BinanceTickerDataModel data, string targetAlerts)
		{
			await Task.Factory.StartNew(() =>
			{
				return;
			});
		}

		private static void SendNotification(INotificationManager notificationManager, string symbol, string currentPrice, string alertPrice, char priceChangeSymbol)
		{
			notificationManager.SendNotification(symbol.Replace("USDT", string.Empty), $"Price alert: {currentPrice} {priceChangeSymbol} {alertPrice}");
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
				for (int alertItem = 0; alertItem < alerts.Length; alertItem++)
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
					bool repeatAlert = Convert.ToBoolean(alertDetails[1]);

					if (previousPrice < alertPrice && data.LastPrice >= alertPrice)
					{
						SendNotification(notificationManager, data.SymbolString, data.CurrentPrice, alertDetails[0], '≥');
						changed = true;
						alertDetails[2] = false.ToString();
						if (!repeatAlert)
						{
							alerts[alertItem] = string.Join('|', alertDetails); // Set the alert IsActive to FALSE
						}
					}

					if (previousPrice > alertPrice && data.LastPrice <= alertPrice)
					{
						SendNotification(notificationManager, data.SymbolString, data.CurrentPrice, alertDetails[0], '≤');
						changed = true;
						alertDetails[2] = false.ToString();
						if (!repeatAlert)
						{
							alerts[alertItem] = string.Join('|', alertDetails); // Set the alert IsActive to FALSE
						}
					}
				}

				if (changed)
				{
					Preferences.Set($"TargetAlert{data.SymbolString}", string.Join(';', alerts)); // Update the alerts to signify we made one or more alert(s) inactive
				}

				return;
			});
		}
	}
}