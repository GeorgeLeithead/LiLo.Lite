// <copyright file="PriceAlertNotification.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Models.Notifications
{
	/// <summary>Price alert model.</summary>
	public class PriceAlertNotification
	{
		/// <summary>Gets or sets the alert percentage.</summary>
		public int AlertPercent { get; set; }

		/// <summary>Gets or sets the alert price.</summary>
		public double AlertPrice { get; set; }

		/// <summary>Gets or sets the alert description.</summary>
		public string Description { get; set; }

		/// <summary>Gets or sets the alert duration period.</summary>
		public int Duration { get; set; }

		/// <summary>Gets or sets a value indicating whether the alert is active.</summary>
		public bool IsActive { get; set; }

		/// <summary>Gets or sets a value indicating whether the target price event every time (true) or one-time (false).</summary>
		public bool RepeatAlert { get; set; }

		/// <summary>Gets or sets the alert symbol.</summary>
		public string Symbol { get; set; }
	}
}