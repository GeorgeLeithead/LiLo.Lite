// <copyright file="PriceAlertNotification.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>

namespace LiLo.Lite.Models.Notifications
{
	/// <summary>Price alert model.</summary>
	public class PriceAlertNotification
	{
		/// <summary>Gets or sets the alert price.</summary>
		public double AlertPrice { get; set; }

		/// <summary>Gets or sets a value indicating whether the target price event is one time or every time.</summary>
		public bool TargetEvent { get; set; }

		/// <summary>Gets or sets a value indicating whether the alert is active.</summary>
		public bool IsActive { get; set; }

		/// <summary>Gets or sets the alert percentage.</summary>
		public int AlertPercent { get; set; }

		/// <summary>Gets or sets the alert duration period.</summary>
		public int Duration { get; set; }
	}
}