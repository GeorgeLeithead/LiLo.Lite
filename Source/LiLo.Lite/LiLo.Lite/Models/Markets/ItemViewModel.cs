// <copyright file="ItemViewModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>

namespace LiLo.Lite.Models.Markets
{
	using Xamarin.CommunityToolkit.ObjectModel;

	/// <summary>Favourite market model.</summary>
	public class ItemViewModel : ObservableObject
	{
		private bool isBeingDragged;
		private bool isBeingDraggedOver;

		/// <summary>Gets or sets the category.</summary>
		public string Category { get; set; }

		/// <summary>Gets or sets a value indicating whether item is being dragged.</summary>
		public bool IsBeingDragged
		{
			get => this.isBeingDragged;
			set => this.SetProperty(ref this.isBeingDragged, value);
		}

		/// <summary>Gets or sets a value indicating whether item being dragged is over.</summary>
		public bool IsBeingDraggedOver
		{
			get => this.isBeingDraggedOver;
			set => this.SetProperty(ref this.isBeingDraggedOver, value);
		}

		/// <summary>Gets or sets the symbol.</summary>
		public string Symbol { get; set; }
	}
}