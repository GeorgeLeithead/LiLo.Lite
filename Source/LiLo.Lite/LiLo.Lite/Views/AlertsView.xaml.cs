// <copyright file="AlertsView.xaml.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Views
{
	using Xamarin.Forms;
	using Xamarin.Forms.Internals;
	using Xamarin.Forms.Xaml;

	/// <summary>Alerts view.</summary>
	[Preserve(AllMembers = true)]
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AlertsView : ContentPage
	{
		/// <summary>Initialises a new instance of the <see cref="AlertsView"/> class.</summary>
		public AlertsView()
		{
			this.InitializeComponent();
		}

		/// <summary>Handle the device back button being pressed.</summary>
		/// <returns>true; cancellation of back button.</returns>
		protected override bool OnBackButtonPressed()
		{
			_ = Shell.Current.GoToAsync("..");
			return true; // prevent users from clicking the back button and exiting the application from the root page.
		}
	}
}