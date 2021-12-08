// <copyright file="ChartView.xaml.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

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
			InitializeComponent();
		}

		/// <inheritdoc/>
		protected override void OnAppearing()
		{
			base.OnAppearing();
			MessagingCenter.Send(this, "preventLandscape");
		}

		/// <summary>Handle the device back button being pressed.</summary>
		/// <returns>true; cancellation of back button.</returns>
		protected override bool OnBackButtonPressed()
		{
			_ = Shell.Current.GoToAsync("..");
			return true;
		}

		/// <inheritdoc/>
		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			MessagingCenter.Send(this, "allowLandscapePortrait");
		}

		/// <summary>Navigating in the Web view.</summary>
		/// <param name="sender">Sender object.</param>
		/// <param name="e">Web navigation Event arguments.</param>
		/// <remarks>Prevent users from navigating to anywhere else other than where we want.</remarks>
		private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
		{
			e.Cancel = true;
		}
	}
}