// <copyright file="FavouritesViewModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.ViewModels
{
	using LiLo.Lite.Helpers;
	using LiLo.Lite.Models.Markets;
	using LiLo.Lite.Resources;
	using LiLo.Lite.Services;
	using LiLo.Lite.ViewModels.Base;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Windows.Input;
	using Xamarin.Essentials;
	using Xamarin.Forms;
	using Xamarin.Forms.Internals;

	/// <summary>Favourites view model.</summary>
	public class FavouritesViewModel : ViewModelBase
	{
		private ObservableCollection<ItemsGroupViewModel> favouriteItems = new();
		private ObservableCollection<ItemViewModel> marketItems = new();

		/// <summary>Initialises a new instance of the <see cref="FavouritesViewModel"/> class.</summary>
		public FavouritesViewModel()
		{
			IsBusy = true;
			Title = AppResources.ViewTitleFavourites;
			ItemDragged = new Command<ItemViewModel>(OnItemDragged);
			ItemDraggedOver = new Command<ItemViewModel>(OnItemDraggedOver);
			ItemDragLeave = new Command<ItemViewModel>(OnItemDragLeave);
			ItemDropped = new Command<ItemViewModel>((i) => OnItemDropped(i));
			ResetItemsState();
			IsBusy = false;
		}

		/// <summary>Gets or sets a collection of favourite markets.</summary>
		public ObservableCollection<ItemsGroupViewModel> FavouriteItems
		{
			get => favouriteItems;
			set
			{
				favouriteItems = value;
				OnPropertyChanged(nameof(FavouriteItems));
			}
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
			get => marketItems;
			set
			{
				marketItems = value;
				OnPropertyChanged(nameof(MarketItems));
			}
		}

		private void OnItemDragged(ItemViewModel item)
		{
			MarketItems.ForEach(i => i.IsBeingDragged = item == i);
		}

		private void OnItemDraggedOver(ItemViewModel item)
		{
			ItemViewModel itemBeingDragged = marketItems.FirstOrDefault(i => i.IsBeingDragged);
			MarketItems.ForEach(i => i.IsBeingDraggedOver = item == i && item != itemBeingDragged);
		}

		private void OnItemDragLeave(ItemViewModel item)
		{
			MarketItems.ForEach(i => i.IsBeingDraggedOver = false);
		}

		private void OnItemDropped(ItemViewModel item)
		{
			ItemViewModel itemToMove = marketItems.First(i => i.IsBeingDragged);
			ItemViewModel itemToInsertBefore = item;

			if (itemToMove == null || itemToInsertBefore == null || itemToMove == itemToInsertBefore)
			{
				return;
			}

			ItemsGroupViewModel categoryToMoveFrom = FavouriteItems.First(g => g.Contains(itemToMove));

			// Wait for remove animation to be completed
			// https://github.com/xamarin/Xamarin.Forms/issues/13791
			//// await Task.Delay(1000);

			ItemsGroupViewModel categoryToMoveTo = FavouriteItems.First(g => g.Contains(itemToInsertBefore));

			if (MarketItems.Count(m => m.Category == Constants.Preferences.Favourites.FavouritesCategory) <= 1 && categoryToMoveFrom.Name == Constants.Preferences.Favourites.FavouritesCategory && categoryToMoveFrom.Name == categoryToMoveTo.Name)
			{
				return; // Must have at least 1 in the favourites category!
			}

			_ = categoryToMoveFrom.Remove(itemToMove);
			int insertAtIndex = categoryToMoveTo.IndexOf(itemToInsertBefore);
			itemToMove.Category = categoryToMoveFrom.Name;
			categoryToMoveTo.Insert(insertAtIndex, itemToMove);
			itemToMove.IsBeingDragged = false;
			itemToInsertBefore.IsBeingDraggedOver = false;
			List<string> favouritesList = new();
			ItemsGroupViewModel favouriteCategory = FavouriteItems.First(fi => fi.Name == Constants.Preferences.Favourites.FavouritesCategory);
			foreach (ItemViewModel fi in favouriteCategory)
			{
				favouritesList.Add(fi.Symbol);
			}

			if (favouritesList.Count > 0)
			{
				Preferences.Set(Constants.Preferences.Favourites.FavouritesCategory, string.Join(",", favouritesList));
			}
		}

		private void ResetItemsState()
		{
			MarketItems.Clear();
			MarketItems = new ObservableCollection<ItemViewModel>(DataStore.GetMarketsGroupedByFavourites());
			FavouriteItems = MarketItems.GroupBy(i => i.Category).Select(g => new ItemsGroupViewModel(g.Key, g)).ToObservableCollection();
		}
	}
}