// <copyright file="AlertsViewModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.ViewModels
{
	using LiLo.Lite.Models.Notifications;
	using LiLo.Lite.Resources;
	using LiLo.Lite.Services.LocalNotification;
	using LiLo.Lite.ViewModels.Base;
	using System;
	using System.Collections.Generic;
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
			IsBusy = true;
			Title = AppResources.ViewTitleAlerts;

#if DEBUG
			// TODO: FOR TEST ONLY
			Preferences.Remove("TargetAlertXRPUSDT");
			Preferences.Set("TargetAlertXRPUSDT", "1.35|true|true;1.355|true|true;1.365|true|true;1.368|true|true;1.372|true|true;1.373|true|true");
#endif
		}

		/// <summary>Gets or sets a collection of values to be displayed in the markets view.</summary>
		public ObservableRangeCollection<PriceAlertNotification> AlertsList
		{
			get => alertsList;
			set
			{
				if (alertsList != value)
				{
					alertsList = value;
					OnPropertyChanged(nameof(AlertsList));
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
					OnPropertyChanged(nameof(SelectedItem));
				}
			}
		}

		/// <summary>Sets the market symbol.</summary>
		public string Symbol
		{
			set
			{
				symbol = Uri.UnescapeDataString(value);
				List<PriceAlertNotification> alerts = PriceNotifications.GetPriceAlertNotificationList(symbol + "USDT");
				alertsList = new ObservableRangeCollection<PriceAlertNotification>(alerts);
				Title = $"{symbol} {Title}";
				OnPropertyChanged(nameof(Title));
				OnPropertyChanged(nameof(AlertsList));
				IsBusy = false;
			}
		}
	}
}