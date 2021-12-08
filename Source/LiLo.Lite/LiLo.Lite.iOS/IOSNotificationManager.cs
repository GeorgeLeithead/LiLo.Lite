//-----------------------------------------------------------------------
// <copyright file="IOSNotificationManager.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   App Delegate.
// </summary>
//-----------------------------------------------------------------------

using System;
using Foundation;
using LiLo.Lite.iOS;
using LiLo.Lite.Services.LocalNotification;
using UserNotifications;
using Xamarin.Forms;

[assembly: Dependency(typeof(IOSNotificationManager))]

namespace LiLo.Lite.iOS
{
	public class IOSNotificationManager : INotificationManager
	{
		private bool hasNotificationsPermission;
		private int messageId = 0;

		public event EventHandler NotificationReceived;

		public void Initialize()
		{
			// request the permission to use local notifications
			UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert, (approved, err) =>
			{
				hasNotificationsPermission = approved;
			});
		}

		public void ReceiveNotification(string title, string message)
		{
			NotificationEventArgs args = new NotificationEventArgs()
			{
				Title = title,
				Message = message
			};
			NotificationReceived?.Invoke(null, args);
		}

		public void SendNotification(string title, string message, DateTime? notifyTime = null)
		{
			// EARLY OUT: app doesn't have permissions
			if (!hasNotificationsPermission)
			{
				return;
			}

			messageId++;

			UNMutableNotificationContent content = new UNMutableNotificationContent()
			{
				Title = title,
				Subtitle = "",
				Body = message,
				Badge = 1
			};

			UNNotificationTrigger trigger;
			if (notifyTime != null)
			{
				// Create a calendar-based trigger.
				trigger = UNCalendarNotificationTrigger.CreateTrigger(GetNSDateComponents(notifyTime.Value), false);
			}
			else
			{
				// Create a time-based trigger, interval is in seconds and must be greater than 0.
				trigger = UNTimeIntervalNotificationTrigger.CreateTrigger(0.25, false);
			}

			UNNotificationRequest request = UNNotificationRequest.FromIdentifier(messageId.ToString(), content, trigger);
			UNUserNotificationCenter.Current.AddNotificationRequest(request, (err) =>
			{
				if (err != null)
				{
					throw new Exception($"Failed to schedule notification: {err}");
				}
			});
		}

		private NSDateComponents GetNSDateComponents(DateTime dateTime)
		{
			return new NSDateComponents
			{
				Month = dateTime.Month,
				Day = dateTime.Day,
				Year = dateTime.Year,
				Hour = dateTime.Hour,
				Minute = dateTime.Minute,
				Second = dateTime.Second
			};
		}
	}
}