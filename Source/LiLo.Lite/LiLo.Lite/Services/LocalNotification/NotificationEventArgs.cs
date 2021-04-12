// <copyright file="NotificationEventArgs.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
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