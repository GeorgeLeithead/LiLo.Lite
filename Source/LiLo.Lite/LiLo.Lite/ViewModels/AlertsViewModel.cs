﻿// <copyright file="AlertsViewModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.ViewModels
{
	using System;
	using System.Collections.Generic;
	using LiLo.Lite.Models.Notifications;
	using LiLo.Lite.Resources;
	using LiLo.Lite.Services.LocalNotification;
	using LiLo.Lite.ViewModels.Base;
	using Xamarin.CommunityToolkit.ObjectModel;
	using Xamarin.Essentials;
	using Xamarin.Forms;

	/// <summary>Alerts view model.</summary>
	[QueryProperty(nameof(Symbol), "symbol")]
	public class AlertsViewModel : ViewModelBase
	{
		/// <summary>Observable list of markets.</summary>
		private ObservableRangeCollection<PriceAlertNotification> alertsList;

		private string symbol;

		/// <summary>Initialises a new instance of the <see cref="AlertsViewModel"/> class.</summary>
		public AlertsViewModel()
		{
			this.IsBusy = true;
			this.Title = AppResources.ViewTitleAlerts;

#if DEBUG
			// TODO: FOR TEST ONLY
			Preferences.Remove("TargetAlertXRPUSDT");
			Preferences.Set("TargetAlertXRPUSDT", "1.35|true|true;1.355|true|true;1.365|true|true;1.368|true|true;1.372|true|true;1.373|true|true");
#endif
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
					this.OnPropertyChanged(nameof(this.AlertsList));
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
					this.OnPropertyChanged(nameof(this.SelectedItem));
				}
			}
		}

		/// <summary>Sets the market symbol.</summary>
		public string Symbol
		{
			set
			{
				this.symbol = Uri.UnescapeDataString(value);
				List<PriceAlertNotification> alerts = PriceNotifications.GetPriceAlertNotificationList(this.symbol + "USDT");
				this.alertsList = new ObservableRangeCollection<PriceAlertNotification>(alerts);
				this.Title = $"{this.symbol} {this.Title}";
				this.OnPropertyChanged(nameof(this.Title));
				this.OnPropertyChanged(nameof(this.AlertsList));
				this.IsBusy = false;
			}
		}
	}
}