﻿//-----------------------------------------------------------------------
// <copyright file="AndroidNotificationManager.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Main Activity.
// </summary>
//-----------------------------------------------------------------------

[assembly: Xamarin.Forms.Dependency(typeof(LiLo.Lite.Droid.Services.AndroidNotificationManager))]

namespace LiLo.Lite.Droid.Services
{
	using Android.App;
	using Android.Content;
	using Android.Graphics;
	using Android.OS;
	using AndroidX.Core.App;
	using LiLo.Lite.Services.LocalNotification;
	using System;
	using AndroidApp = Android.App.Application;

	/// <summary>Notification handler.</summary>
	public class AndroidNotificationManager : INotificationManager
	{
		/// <summary>Message key.</summary>
		public const string MessageKey = "message";

		/// <summary>Title key.</summary>
		public const string TitleKey = "title";

		private const string channelDescription = "The default channel for notifications.";
		private const string channelId = "default";
		private const string channelName = "Default";
		private bool channelInitialized = false;
		private NotificationManager manager;
		private int messageId = 0;
		private int pendingIntentId = 0;

		/// <summary>Initialises a new instance of the<see cref="AndroidNotificationManager" /> class.</summary>
		public AndroidNotificationManager()
		{
			Initialize();
		}

		/// <summary>Notification received event handler.</summary>
		public event EventHandler NotificationReceived;

		/// <summary>Notification manager instance.</summary>
		public static AndroidNotificationManager Instance { get; private set; }

		/// <summary>Initialise notification manager.</summary>
		public void Initialize()
		{
			if (Instance == null)
			{
				CreateNotificationChannel();
				Instance = this;
			}
		}

		/// <summary>Receive notification method.</summary>
		/// <param name="title">Notification title.</param>
		/// <param name="message">Notification message.</param>
		public void ReceiveNotification(string title, string message)
		{
			NotificationEventArgs args = new NotificationEventArgs()
			{
				Title = title,
				Message = message,
			};
			NotificationReceived?.Invoke(null, args);
		}

		/// <summary>Send notification method.</summary>
		/// <param name="title">Notification title.</param>
		/// <param name="message">Notification message.</param>
		/// <param name="notifyTime">Notification time.</param>
		public void SendNotification(string title, string message, DateTime? notifyTime = null)
		{
			if (!channelInitialized)
			{
				CreateNotificationChannel();
			}

			if (notifyTime != null)
			{
				Intent intent = new Intent(AndroidApp.Context, typeof(AlarmHandler));
				_ = intent.PutExtra(TitleKey, title);
				_ = intent.PutExtra(MessageKey, message);
				PendingIntent pendingIntent = PendingIntent.GetBroadcast(AndroidApp.Context, pendingIntentId++, intent, PendingIntentFlags.CancelCurrent);
				long triggerTime = GetNotifyTime(notifyTime.Value);
				AlarmManager alarmManager = AndroidApp.Context.GetSystemService(Context.AlarmService) as AlarmManager;
				alarmManager.Set(AlarmType.RtcWakeup, triggerTime, pendingIntent);
			}
			else
			{
				Show(title, message);
			}
		}

		/// <summary>Show notification.</summary>
		/// <param name="title">Notification title.</param>
		/// <param name="message">Notification message.</param>
		public void Show(string title, string message)
		{
			Intent intent = new Intent(AndroidApp.Context, typeof(MainActivity));
			_ = intent.PutExtra(TitleKey, title);
			_ = intent.PutExtra(MessageKey, message);
			PendingIntent pendingIntent = PendingIntent.GetActivity(AndroidApp.Context, pendingIntentId++, intent, PendingIntentFlags.UpdateCurrent);
			NotificationCompat.Builder builder = new NotificationCompat.Builder(AndroidApp.Context, channelId)
				.SetContentIntent(pendingIntent)
				.SetContentTitle(title)
				.SetContentText(message)
				.SetLargeIcon(BitmapFactory.DecodeResource(AndroidApp.Context.Resources, Resource.Drawable.ic_notification))
				.SetSmallIcon(Resource.Drawable.ic_notification)
				.SetDefaults((int)NotificationDefaults.Sound | (int)NotificationDefaults.Vibrate);

			Notification notification = builder.Build();
			manager.Notify(messageId++, notification);
		}

		private void CreateNotificationChannel()
		{
			manager = (NotificationManager)AndroidApp.Context.GetSystemService(Context.NotificationService);
			if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
			{
				Java.Lang.String channelNameJava = new Java.Lang.String(channelName);
				NotificationChannel channel = new NotificationChannel(channelId, channelNameJava, NotificationImportance.Default)
				{
					Description = channelDescription
				};
				manager.CreateNotificationChannel(channel);
			}

			channelInitialized = true;
		}

		private long GetNotifyTime(DateTime notifyTime)
		{
			DateTime utcTime = TimeZoneInfo.ConvertTimeToUtc(notifyTime);
			double epochDiff = (new DateTime(1970, 1, 1) - DateTime.MinValue).TotalSeconds;
			long utcAlarmTime = utcTime.AddSeconds(-epochDiff).Ticks / 10000;
			return utcAlarmTime; // milliseconds
		}
	}
}