// <copyright file="NotificationEventArgs.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Services.LocalNotification
{
	using System;

	/// <summary>Notification event arguments.</summary>
	public class NotificationEventArgs : EventArgs
	{
		/// <summary>Gets or sets the notification message.</summary>
		public string Message { get; set; }

		/// <summary>Gets or sets the notification title.</summary>
		public string Title { get; set; }
	}
}