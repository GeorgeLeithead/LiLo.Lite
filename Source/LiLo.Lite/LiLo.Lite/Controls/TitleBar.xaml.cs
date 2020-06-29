namespace LiLo.Lite.Controls
{
	using System;
	using Xamarin.Forms;
	using Xamarin.Forms.Xaml;

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