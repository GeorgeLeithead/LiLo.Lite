// <copyright file="AlertsViewModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>

namespace LiLo.Lite.ViewModels
{
	using System;
	using LiLo.Lite.Models.Notifications;
	using LiLo.Lite.ViewModels.Base;
	using Xamarin.CommunityToolkit.ObjectModel;
	using Xamarin.Essentials;
	using Xamarin.Forms;

	/// <summary>Alerts view model.</summary>
	[QueryProperty("Symbol", "symbol")]
	public class AlertsViewModel : ViewModelBase
	{
		private string symbol;

		/// <summary>Observable list of markets.</summary>
		private ObservableRangeCollection<PriceAlertNotification> alertsList;

		/// <summary>Initialises a new instance of the <see cref="AlertsViewModel"/> class.</summary>
		public AlertsViewModel()
		{
			this.IsBusy = true;
			this.Title = "Alerts";

#if DEBUG
			// TODO: FOR TEST ONLY
			Preferences.Set("TargetAlertXRPUSDT", "1.35|true|true;1.355|true|true;1.365|true|true;1.368|true|true;1.372|true|true;1.373|true|true");
#endif

			this.IsBusy = false;
		}

		/// <summary>Gets or sets the market symbol.</summary>
		public string Symbol
		{
			get => this.symbol;
			set
			{
				if (!string.IsNullOrEmpty(value))
				{
					this.symbol = Uri.UnescapeDataString(value);
				}
			}
		}

		/// <summary>Gets or sets a collection of values to be displayed in the markets view.</summary>
		public ObservableRangeCollection<PriceAlertNotification> AlertsList
		{
			get => this.alertsList;
			set
			{
				if (this.alertsList != value)
				{
					this.alertsList = value;
					this.NotifyPropertyChanged(() => this.AlertsList);
				}
			}
		}

		/// <summary>Gets or sets the selected item.</summary>
		public PriceAlertNotification SelectedItem
		{
			get => null;
			set
			{
				if (value != null)
				{
					PriceAlertNotification item = value;
					this.NotifyPropertyChanged(() => this.SelectedItem);
				}
			}
		}
	}
}