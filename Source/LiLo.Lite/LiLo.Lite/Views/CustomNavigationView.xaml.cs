//-----------------------------------------------------------------------
// <copyright file="CustomNavigationView.xaml.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Custom navigation view.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Views
{
	using Xamarin.Forms;
	using Xamarin.Forms.Xaml;

	/// <summary>Custom navigation view.</summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CustomNavigationView : NavigationPage
	{
		/// <summary>Initialises a new instance of the <see cref="CustomNavigationView"/> class.</summary>
		public CustomNavigationView() : base()
		{
			InitializeComponent();
			SetDynamicResource(BarBackgroundColorProperty, "PrimaryColor");
		}

		/// <summary>Initialises a new instance of the <see cref="CustomNavigationView"/> class.</summary>
		/// <param name="root">Root page.</param>
		public CustomNavigationView(Page root) : base(root)
		{
			InitializeComponent();
			SetDynamicResource(BarBackgroundColorProperty, "PrimaryColor");
		}
	}
}