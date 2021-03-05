//-----------------------------------------------------------------------
// <copyright file="HomeView.xaml.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Home page view.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Views
{
	using System.Linq;
	using System.Threading.Tasks;
	using LiLo.Lite.Models.Markets;
	using LiLo.Lite.ViewModels;
	using Xamarin.Forms;
	using Xamarin.Forms.Internals;
	using Xamarin.Forms.Xaml;

	/// <summary>Home page view.</summary>
	[Preserve(AllMembers = true)]
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeView : ContentPage
	{
		private HomeViewModel vm;

		/// <summary>Initialises a new instance of the <see cref="HomeView" /> class.</summary>
		public HomeView() => this.InitializeComponent();

		private HomeViewModel VM => this.vm ??= (HomeViewModel)this.BindingContext;

		/// <inheritdoc/>
		protected override void OnAppearing()
		{
			base.OnAppearing();
			this.searchBar.Unfocus();
			if (!string.IsNullOrEmpty(this.VM.Symbol))
			{
				Task.Factory.StartNew(() =>
				{
					// await Task.Delay(500); // This causes a real problem with the app performance!
					MarketModel matchingItem = this.VM.MarketsList.Where(m => m.SymbolString == this.VM.Symbol).FirstOrDefault();
					if (matchingItem != null)
					{
						this.CollectionViewmarketsList.ScrollTo(item: matchingItem, group: null, position: ScrollToPosition.Start, animate: true);
					}
				});
			}
		}

		/// <inheritdoc/>
		protected override void OnSizeAllocated(double width, double height)
		{
			base.OnSizeAllocated(width, height);
			if (width > height)
			{
				// Landscape mode
				this.VM.GridItemsLayoutSpan = 2;
			}
			else
			{
				// Portrait mode
				this.VM.GridItemsLayoutSpan = 1;
			}
		}

		/// <summary>Search Bar text changed.</summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Text changed event arguments.</param>
		private void SearchBarTextChanged(object sender, TextChangedEventArgs e)
		{
			if (!string.IsNullOrEmpty(e.NewTextValue))
			{
				MarketModel matchingItem = this.VM.MarketsList.Where(m => m.SymbolString.StartsWith(e.NewTextValue.ToUpperInvariant())).FirstOrDefault();
				if (matchingItem != null)
				{
					this.CollectionViewmarketsList.ScrollTo(item: matchingItem, group: null, position: ScrollToPosition.Start, animate: true);
				}
			}
		}
	}
}