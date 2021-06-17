// <copyright file="FavouritesViewModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>

namespace LiLo.Lite.ViewModels
{
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Windows.Input;
	using LiLo.Lite.Helpers;
	using LiLo.Lite.Models.Markets;
	using LiLo.Lite.Services;
	using Xamarin.CommunityToolkit.ObjectModel;
	using Xamarin.Essentials;
	using Xamarin.Forms;
	using Xamarin.Forms.Internals;

	/// <summary>Favourites view model.</summary>
	public class FavouritesViewModel : ObservableObject
	{
		private ObservableCollection<ItemsGroupViewModel> favouriteItems = new ObservableCollection<ItemsGroupViewModel>();

		/// <summary>View is busy.</summary>
		private bool isBusy;

		private ObservableCollection<ItemViewModel> marketItems = new ObservableCollection<ItemViewModel>();

		/// <summary>View title.</summary>
		private string title;

		/// <summary>Initialises a new instance of the <see cref="FavouritesViewModel"/> class.</summary>
		public FavouritesViewModel()
		{
			this.IsBusy = true;
			this.Title = "Manage Favourites";
			this.ItemDragged = new Command<ItemViewModel>(this.OnItemDragged);
			this.ItemDraggedOver = new Command<ItemViewModel>(this.OnItemDraggedOver);
			this.ItemDragLeave = new Command<ItemViewModel>(this.OnItemDragLeave);
			this.ItemDropped = new Command<ItemViewModel>((i) => this.OnItemDropped(i));
			this.ResetItemsState();
			this.IsBusy = false;
		}

		/// <summary>Gets or sets a collection of favourite markets.</summary>
		public ObservableCollection<ItemsGroupViewModel> FavouriteItems
		{
			get => this.favouriteItems;
			set => this.SetProperty(ref this.favouriteItems, value);
		}

		/// <summary>Gets or sets a value indicating whether the view is busy.</summary>
		public bool IsBusy
		{
			get => this.isBusy;
			set => this.SetProperty(ref this.isBusy, value);
		}

		/// <summary>Gets an item dragged command.</summary>
		public ICommand ItemDragged { get; }

		/// <summary>Gets an item dragged complete command.</summary>
		public ICommand ItemDraggedOver { get; }

		/// <summary>Gets an item dragged left command.</summary>
		public ICommand ItemDragLeave { get; }

		/// <summary>Gets an item dropped command.</summary>
		public ICommand ItemDropped { get; }

		/// <summary>Gets or sets a collection of markets.</summary>
		public ObservableCollection<ItemViewModel> MarketItems
		{
			get => this.marketItems;
			set => this.SetProperty(ref this.marketItems, value);
		}

		/// <summary>gets or sets a value for the view title.</summary>
		public string Title
		{
			get => this.title;
			set => this.SetProperty(ref this.title, value);
		}

		private void OnItemDragged(ItemViewModel item)
		{
			this.MarketItems.ForEach(i => i.IsBeingDragged = item == i);
		}

		private void OnItemDraggedOver(ItemViewModel item)
		{
			ItemViewModel itemBeingDragged = this.marketItems.FirstOrDefault(i => i.IsBeingDragged);
			this.MarketItems.ForEach(i => i.IsBeingDraggedOver = item == i && item != itemBeingDragged);
		}

		private void OnItemDragLeave(ItemViewModel item)
		{
			this.MarketItems.ForEach(i => i.IsBeingDraggedOver = false);
		}

		private void OnItemDropped(ItemViewModel item)
		{
			ItemViewModel itemToMove = this.marketItems.First(i => i.IsBeingDragged);
			ItemViewModel itemToInsertBefore = item;

			if (itemToMove == null || itemToInsertBefore == null || itemToMove == itemToInsertBefore)
			{
				return;
			}

			ItemsGroupViewModel categoryToMoveFrom = this.FavouriteItems.First(g => g.Contains(itemToMove));

			// Wait for remove animation to be completed
			// https://github.com/xamarin/Xamarin.Forms/issues/13791
			//// await Task.Delay(1000);

			ItemsGroupViewModel categoryToMoveTo = this.FavouriteItems.First(g => g.Contains(itemToInsertBefore));

			if (this.MarketItems.Count(m => m.Category == App.FavouritesCategory) <= 1 && categoryToMoveFrom.Name == App.FavouritesCategory && categoryToMoveFrom.Name == categoryToMoveTo.Name)
			{
				return; // Must have at least 1 in the favourites category!
			}

			_ = categoryToMoveFrom.Remove(itemToMove);
			int insertAtIndex = categoryToMoveTo.IndexOf(itemToInsertBefore);
			itemToMove.Category = categoryToMoveFrom.Name;
			categoryToMoveTo.Insert(insertAtIndex, itemToMove);
			itemToMove.IsBeingDragged = false;
			itemToInsertBefore.IsBeingDraggedOver = false;
			List<string> favouritesList = new List<string>();
			ItemsGroupViewModel favouriteCategory = this.FavouriteItems.First(fi => fi.Name == App.FavouritesCategory);
			foreach (ItemViewModel fi in favouriteCategory)
			{
				favouritesList.Add(fi.Symbol);
			}

			if (favouritesList.Count > 0)
			{
				Preferences.Set(App.FavouritesCategory, string.Join(",", favouritesList));
			}
		}

		private void ResetItemsState()
		{
			this.MarketItems.Clear();
			this.MarketItems = new ObservableCollection<ItemViewModel>(DataStore.GetMarketsGroupedByFavourites());
			this.FavouriteItems = this.MarketItems.GroupBy(i => i.Category).Select(g => new ItemsGroupViewModel(g.Key, g)).ToObservableCollection();
		}
	}
}