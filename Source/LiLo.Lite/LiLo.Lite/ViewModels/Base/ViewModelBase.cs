﻿// <copyright file="ViewModelBase.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.ViewModels.Base
{
	using LiLo.Lite.Services.Dialog;
	using LiLo.Lite.Services.Markets;
	using LiLo.Lite.Services.Sockets;
	using System.Runtime.Serialization;
	using Xamarin.Forms;
	using Xamarin.Forms.Internals;

	/// <summary>View model base class.</summary>
	[Preserve(AllMembers = true)]
	[DataContract]
	public abstract class ViewModelBase : BindableObject
	{
		private IDialogService dialogService;

		/// <summary>View is busy.</summary>
		private bool isBusy;

		private MarketsHelperService marketsHelperService;
		private ISocketsService socketsService;

		/// <summary>View title.</summary>
		private string title;

		/// <summary>Initialises a new instance of the <see cref="ViewModelBase" /> class.</summary>
		public ViewModelBase()
		{
		}

		/// <summary>Gets the dialogue service.</summary>
		public IDialogService DialogService => dialogService ??= DependencyService.Resolve<DialogService>();

		/// <summary>Gets or sets a value indicating whether the view is busy.</summary>
		public bool IsBusy
		{
			get => isBusy;
			set
			{
				isBusy = value;
				OnPropertyChanged(nameof(IsBusy));
			}
		}

		/// <summary>Gets the markets helper service.</summary>
		public MarketsHelperService MarketsHelperService => marketsHelperService ??= DependencyService.Resolve<MarketsHelperService>();

		/// <summary>Gets the sockets service.</summary>
		public ISocketsService SocketsService => socketsService ??= DependencyService.Resolve<SocketsService>();

		/// <summary>gets or sets a value for the view title.</summary>
		public string Title
		{
			get => title;
			set
			{
				title = value;
				OnPropertyChanged(nameof(Title));
			}
		}
	}
}