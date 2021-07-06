// <copyright file="SettingsView.xaml.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Views
{
	using LiLo.Lite.Helpers;
	using Xamarin.Essentials;
	using Xamarin.Forms;
	using Xamarin.Forms.Xaml;

	/// <summary>Settings view.</summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SettingsView : ContentPage
	{
		/// <summary>Initialises a new instance of the <see cref="SettingsView"/> class.</summary>
		public SettingsView()
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

		private void ThemeCheckedChanged(object sender, CheckedChangedEventArgs e)
		{
			RadioButton button = sender as RadioButton;
			Application.Current.UserAppTheme = button.Value switch
			{
				"1" => OSAppTheme.Light,
				"2" => OSAppTheme.Dark,
				_ => OSAppTheme.Unspecified,
			};

			IEnvironment env = DependencyService.Get<IEnvironment>();
			if (Application.Current.RequestedTheme == OSAppTheme.Dark)
			{
				env?.SetStatusBarColor(Color.Black, false);
			}
			else
			{
				env?.SetStatusBarColor(Color.White, true);
			}

			Preferences.Set("Theme", (int)Application.Current.UserAppTheme);
		}
	}
}