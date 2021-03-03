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
	using LiLo.Lite.Services.Dialog;
	using LiLo.Lite.Services.Markets;
	using LiLo.Lite.Services.Sockets;
	using Xamarin.Forms;
	using Xamarin.Forms.Internals;

	/// <summary>View model base class.</summary>
	[Preserve(AllMembers = true)]
	[DataContract]
	public abstract class ViewModelBase : ExtendedBindableObject
	{
		private IDialogService dialogService;
		private MarketsHelperService marketsHelperService;
		private ISocketsService socketsService;

		/// <summary>View is busy.</summary>
		private bool isBusy;

		/// <summary>View title.</summary>
		private string title;

		/// <summary>Initialises a new instance of the <see cref="ViewModelBase" /> class.</summary>
		public ViewModelBase()
		{
		}

		/// <summary>Gets the markets helper service.</summary>
		public MarketsHelperService MarketsHelperService => this.marketsHelperService ??= DependencyService.Resolve<MarketsHelperService>();

		/// <summary>Gets the dialogue service.</summary>
		public IDialogService DialogService => this.dialogService ??= DependencyService.Resolve<DialogService>();

		/// <summary>Gets the sockets service.</summary>
		public ISocketsService SocketsService => this.socketsService ??= DependencyService.Resolve<SocketsService>();

		/// <summary>Gets or sets a value indicating whether the view is busy.</summary>
		public bool IsBusy
		{
			get => this.isBusy;
			set
			{
				this.isBusy = value;
				this.NotifyPropertyChanged(() => this.IsBusy);
			}
		}

		/// <summary>gets or sets a value for the view title.</summary>
		public string Title
		{
			get => this.title;
			set
			{
				this.title = value;
				this.NotifyPropertyChanged(() => this.Title);
			}
		}
	}
}