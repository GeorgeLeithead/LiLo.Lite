//-----------------------------------------------------------------------
// <copyright file="ChartView.xaml.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Chart View class.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Views
{
	using Xamarin.Forms;
	using Xamarin.Forms.Internals;
	using Xamarin.Forms.Xaml;

	/// <summary>Chart View class.</summary>
	[Preserve(AllMembers = true)]
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ChartView : ContentPage
	{
		/// <summary>Initialises a new instance of the <see cref="ChartView" /> class.</summary>
		public ChartView()
		{
			this.InitializeComponent();
		}

		/// <summary>Handle the device back button being pressed.</summary>
		/// <remarks>As this is the root page, we have to prevent the back button otherwise it will exit the application.</remarks>
		/// <returns>true; cancellation of back button.</returns>
		protected override bool OnBackButtonPressed()
		{
			base.OnBackButtonPressed();
			Shell.Current.GoToAsync("///Home").ConfigureAwait(true);
			return true; // prevent users from clicking the back button and exiting the application from the root page.
		}

		/// <summary>Navigating in the Web view</summary>
		/// <param name="sender">Sender object</param>
		/// <param name="e">Web navigation Event arguments.</param>
		/// <remarks>Prevent users from navigating to anywhere else other than where we want.</remarks>
		private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
		{
			e.Cancel = true;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			MessagingCenter.Send(this, "preventLandscape");
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			MessagingCenter.Send(this, "allowLandscapePortrait");
		}
	}
}