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
	using LiLo.Lite.Controls;
	using System;
	using Xamarin.Forms;
	using Xamarin.Forms.Internals;
	using Xamarin.Forms.Xaml;

	/// <summary>Home page view.</summary>
	[Preserve(AllMembers = true)]
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomeView : ContentPage
	{
		/// <summary>Initialises a new instance of the <see cref="HomeView" /> class.</summary>
		public HomeView()
		{
			InitializeComponent();
		}

		private void SelectProvider(object sender, EventArgs args)
		{
			View view = sender as View;
			StackLayout parent = view.Parent as StackLayout;
			StackLayout parentParentParent = view.Parent.Parent.Parent as StackLayout;
			Label providerName = parentParentParent.Children[0] as Label;
			foreach (View child in parent.Children)
			{
				CustomPancakeView pancakeView = child as CustomPancakeView;
				if (pancakeView.IsSelected)
				{
					pancakeView.IsSelected = false;
					break;
				}
			}

			CustomPancakeView selectedProvider = sender as CustomPancakeView;
			selectedProvider.IsSelected = true;
			providerName.Text = selectedProvider.AutomationId;
		}
	}
}