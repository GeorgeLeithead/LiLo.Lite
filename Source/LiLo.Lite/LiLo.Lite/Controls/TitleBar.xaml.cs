//-----------------------------------------------------------------------
// <copyright file="TitleBar.xaml.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Custom TitleBar content view.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Controls
{
	using System;
	using Xamarin.Forms;
	using Xamarin.Forms.Xaml;

	/// <summary>Custom TitleBar content view.</summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TitleBar : ContentView
	{
		public TitleBar()
		{
			InitializeComponent();
		}

		private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			await Navigation.PopAsync();
		}

		private void SettingsTapped(object sender, EventArgs e)
		{
			Application.Current.UserAppTheme = Application.Current.RequestedTheme == OSAppTheme.Light ? OSAppTheme.Dark : OSAppTheme.Light;
		}
	}
}