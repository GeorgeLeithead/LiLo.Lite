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

		private HomeViewModel VM
		{
			get => this.vm ??= (HomeViewModel)this.BindingContext;
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
	}
}