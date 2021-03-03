//-----------------------------------------------------------------------
// <copyright file="MainActivity.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Main Activity.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Droid
{
	using Acr.UserDialogs;
	using Android.App;
	using Android.Content.PM;
	using Android.OS;
	using Android.Runtime;
	using LiLo.Lite.Interfaces;
	using LiLo.Lite.Views;
	using Plugin.CurrentActivity;
	using Xamarin.Forms;

	/// <inheritdoc/>
	[Activity(Label = "LiLo.Lite", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		private ScreenOrientation previousOrientation = ScreenOrientation.Unspecified;

		/// <inheritdoc/>
		public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
		{
			Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

			base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
		}

		/// <inheritdoc/>
		protected override void OnCreate(Bundle savedInstanceState)
		{
			CrossCurrentActivity.Current.Init(this, savedInstanceState);
			DependencyService.Register<IParentWindowLocatorService, AndroidParentWindowLocatorService>();

			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(savedInstanceState);

			Xamarin.Essentials.Platform.Init(this, savedInstanceState);
			Forms.Init(this, savedInstanceState);
			CrossCurrentActivity.Current.Init(this, savedInstanceState);
			UserDialogs.Init(this);
			this.LoadApplication(new App());

			MessagingCenter.Subscribe<ChartView>(this, "preventLandscape", sender =>
			{
				this.previousOrientation = this.RequestedOrientation;
				this.RequestedOrientation = ScreenOrientation.Portrait;
			});

			MessagingCenter.Subscribe<ChartView>(this, "allowLandscapePortrait", sender =>
			{
				this.RequestedOrientation = this.previousOrientation;
			});
		}
	}
}