//-----------------------------------------------------------------------
// <copyright file="AlarmHandler.cs" company="InternetWideWorld.com">
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

namespace LiLo.Lite.Droid.Services
{
	using Android.Content;

	/// <summary>Local notifications broadcast receiver alarm handler.</summary>
	[BroadcastReceiver(Enabled = true, Label = "Local Notifications Broadcast Receiver")]
	public class AlarmHandler : BroadcastReceiver
	{
		/// <summary>On Receive alarm.</summary>
		/// <param name="context">Alarm context.</param>
		/// <param name="intent">Alarm intent.</param>
		public override void OnReceive(Context context, Intent intent)
		{
			if (intent?.Extras != null)
			{
				string title = intent.GetStringExtra(AndroidNotificationManager.TitleKey);
				string message = intent.GetStringExtra(AndroidNotificationManager.MessageKey);

				AndroidNotificationManager manager = AndroidNotificationManager.Instance ?? new AndroidNotificationManager();
				manager.Show(title, message);
			}
		}
	}
}