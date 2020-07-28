//-----------------------------------------------------------------------
// <copyright file="ViewModelBase.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   View model base class.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.ViewModels.Base
{
	using System.Runtime.Serialization;
	using System.Threading.Tasks;
	using LiLo.Lite.Services.Dialog;
	using LiLo.Lite.Services.Markets;
	using LiLo.Lite.Services.Navigation;
	using LiLo.Lite.Services.Settings;
	using LiLo.Lite.Services.Sockets;
	using Xamarin.Forms.Internals;

	/// <summary>View model base class.</summary>
	[Preserve(AllMembers = true)]
	[DataContract]
	public abstract class ViewModelBase : ExtendedBindableObject
	{
		/// <summary>Dialog service.</summary>
		protected readonly IDialogService DialogService;

		/// <summary>Markets service.</summary>
		protected readonly IMarketsHelperService MarketsHelperService;

		/// <summary>Navigation service.</summary>
		protected readonly INavigationService NavigationService;

		/// <summary>Settings service.</summary>
		protected readonly ISettingsService SettingsService;

		/// <summary>Sockets service.</summary>
		protected readonly ISocketsService SocketsService;

		/// <summary>View is busy.</summary>
		private bool isBusy;

		/// <summary>Initialises a new instance of the <see cref="ViewModelBase" /> class.</summary>
		public ViewModelBase()
		{
			NavigationService = ViewModelLocator.Resolve<INavigationService>();
			SocketsService = ViewModelLocator.Resolve<ISocketsService>();
			MarketsHelperService = ViewModelLocator.Resolve<IMarketsHelperService>();
			SettingsService = ViewModelLocator.Resolve<ISettingsService>();
			DialogService = ViewModelLocator.Resolve<IDialogService>();
		}

		/// <summary>Gets or sets a value indicating whether the view is busy.</summary>
		public bool IsBusy
		{
			get => isBusy;
			set
			{
				isBusy = value;
				NotifyPropertyChanged(() => IsBusy);
			}
		}

		/// <summary>Initialises the view model.</summary>
		/// <returns>Task result</returns>
		public virtual Task InitializeAsync(object parameter)
		{
			return Task.FromResult(false);
		}
	}
}