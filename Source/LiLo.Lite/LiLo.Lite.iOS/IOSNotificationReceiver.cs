//-----------------------------------------------------------------------
// <copyright file="IOSNotificationReceiver.cs" company="InternetWideWorld.com">
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

namespace LiLo.Lite.iOS
{
	using System;
	using LiLo.Lite.Services.LocalNotification;
	using UserNotifications;
	using Xamarin.Forms;

	internal class IOSNotificationReceiver : UNUserNotificationCenterDelegate
	{
		public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
		{
			this.ProcessNotification(notification);
			completionHandler(UNNotificationPresentationOptions.Alert);
		}

		private void ProcessNotification(UNNotification notification)
		{
			string title = notification.Request.Content.Title;
			string message = notification.Request.Content.Body;

			DependencyService.Get<INotificationManager>().ReceiveNotification(title, message);
		}
	}
}