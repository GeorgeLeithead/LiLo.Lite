// <copyright file="ItemViewModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Models.Markets
{
	using Xamarin.CommunityToolkit.ObjectModel;
	using Xamarin.Forms;

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
			get => isBeingDragged;
			set => SetProperty(ref isBeingDragged, value);
		}

		/// <summary>Gets or sets a value indicating whether item being dragged is over.</summary>
		public bool IsBeingDraggedOver
		{
			get => isBeingDraggedOver;
			set => SetProperty(ref isBeingDraggedOver, value);
		}

		/// <summary>Gets or sets the symbol.</summary>
		public string Symbol { get; set; }

		/// <summary>Gets or sets the symbol image.</summary>
		public UriImageSource SymbolImage { get; set; }
	}
}