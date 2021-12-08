// <copyright file="ItemsGroupViewModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Models.Markets
{
	using System.Collections.Generic;
	using System.Collections.ObjectModel;

	/// <summary>Items group view model.</summary>
	public class ItemsGroupViewModel : ObservableCollection<ItemViewModel>
	{
		/// <summary>Initialises a new instance of the <see cref="ItemsGroupViewModel"/> class.</summary>
		/// <param name="name">Group name.</param>
		/// <param name="items">IEnumerable{ItemViewModel}.</param>
		public ItemsGroupViewModel(string name, IEnumerable<ItemViewModel> items)
			: base(items)
		{
			Name = name;
		}

		/// <summary>Gets or sets the item group name.</summary>
		public string Name { get; set; }
	}
}