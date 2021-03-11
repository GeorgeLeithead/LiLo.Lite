// <copyright file="SettingsView.xaml.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>

namespace LiLo.Lite.Views
{
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
		/// <remarks>As this is the root page, we have to prevent the back button otherwise it will exit the application.</remarks>
		/// <returns>true; cancellation of back button.</returns>
		protected override bool OnBackButtonPressed()
		{
			Shell.Current.GoToAsync("///Home").ConfigureAwait(true);
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
		}
	}
}