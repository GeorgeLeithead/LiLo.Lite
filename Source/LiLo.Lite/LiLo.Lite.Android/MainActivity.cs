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

[assembly: Xamarin.Forms.Dependency(typeof(LiLo.Lite.Droid.Services.Environment))]

namespace LiLo.Lite.Droid
{
	using Acr.UserDialogs;
	using Android.App;
	using Android.Content;
	using Android.Content.PM;
	using Android.OS;
	using Android.Runtime;
	using LiLo.Lite.Droid.Services;
	using LiLo.Lite.Services.LocalNotification;
	using LiLo.Lite.Views;
	using Xamarin.Forms;

	/// <inheritdoc/>
	[Activity(Label = "LiLo.Lite", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	[Preserve(AllMembers = true)]
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
			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(savedInstanceState);

			Xamarin.Essentials.Platform.Init(this, savedInstanceState);
			Forms.Init(this, savedInstanceState);
			UserDialogs.Init(this);
			LoadApplication(new App());

			MessagingCenter.Subscribe<ChartView>(this, "preventLandscape", sender =>
			{
				previousOrientation = RequestedOrientation;
				RequestedOrientation = ScreenOrientation.Portrait;
			});

			MessagingCenter.Subscribe<ChartView>(this, "allowLandscapePortrait", sender =>
			{
				RequestedOrientation = previousOrientation;
			});
			CreateNotificationFromIntent(Intent);
		}

		/// <inheritdoc/>
		protected override void OnNewIntent(Intent intent)
		{
			CreateNotificationFromIntent(intent);
		}

		private void CreateNotificationFromIntent(Intent intent)
		{
			if (intent?.Extras != null)
			{
				string title = intent.GetStringExtra(AndroidNotificationManager.TitleKey);
				string message = intent.GetStringExtra(AndroidNotificationManager.MessageKey);
				DependencyService.Get<INotificationManager>().ReceiveNotification(title, message);
			}
		}
	}
}