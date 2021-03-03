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
		/// <summary>Gets or sets the label style Property, and it is a bindable property.</summary>
		public static readonly BindableProperty LabelStyleProperty = BindableProperty.Create(nameof(LabelStyle), typeof(Style), typeof(TitleBar), null, BindingMode.TwoWay, null, LabelStylePropertyChanged);

		/// <summary>Gets or sets the title Property, and it is a bindable property.</summary>
		public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(TitleBar), string.Empty, BindingMode.Default, null, OnTextChanged);

		/// <summary>Gets or sets the home is visible Property, and it is a bindable property.</summary>
		public static readonly BindableProperty HomeVisibleProperty = BindableProperty.Create(nameof(HomeVisible), typeof(bool), typeof(TitleBar), true, BindingMode.Default, null, OnHomeVisible);

		/// <summary>Initialises a new instance of the <see cref="TitleBar"/> class.</summary>
		public TitleBar()
		{
			this.InitializeComponent();
		}

		/// <summary>Gets or sets the label style.</summary>
		public Style LabelStyle { get; set; }

		/// <summary>Gets or sets the Text.</summary>
		public string Text
		{
			get => (string)this.GetValue(TextProperty);
			set => this.SetValue(TextProperty, value);
		}

		/// <summary>Gets or sets a value indicating whether home is visible.</summary>
		public bool HomeVisible { get; set; }

		/// <summary>Label style changed.</summary>
		/// <param name="bindable">Bindable object.</param>
		/// <param name="oldValue">Old value.</param>
		/// <param name="newValue">New value.</param>
		private static void LabelStylePropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			TitleBar tb = (TitleBar)bindable;
			tb.Title.Style = (Style)newValue;
		}

		/// <summary>Home visible.</summary>
		/// <param name="bindable">Bindable object.</param>
		/// <param name="oldValue">Old value.</param>
		/// <param name="newValue">New value.</param>
		private static void OnHomeVisible(BindableObject bindable, object oldValue, object newValue)
		{
			TitleBar tb = (TitleBar)bindable;
			tb.HomeImage.IsVisible = (bool)newValue;
		}

		/// <summary>Change the title bar heading.</summary>
		/// <param name="bindable">Bindable object.</param>
		/// <param name="oldValue">Old value.</param>
		/// <param name="newValue">New value.</param>
		private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
		{
			TitleBar tb = (TitleBar)bindable;
			string newValueString = (string)newValue;
			if (string.IsNullOrEmpty(newValueString))
			{
				tb.Title.IsVisible = false;
				tb.Title.Text = newValueString;
				return;
			}

			tb.Title.IsVisible = true;
			tb.Title.Text = newValueString;
		}

		/// <summary>Change the application theme.</summary>
		/// <param name="sender">Object sender.</param>
		/// <param name="e">Event arguments.</param>
		private void SettingsTapped(object sender, EventArgs e)
		{
			Application.Current.UserAppTheme = Application.Current.RequestedTheme == OSAppTheme.Light ? OSAppTheme.Dark : OSAppTheme.Light;
		}

		private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync("//Home");
		}
	}
}