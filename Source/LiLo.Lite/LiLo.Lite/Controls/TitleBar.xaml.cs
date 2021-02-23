namespace LiLo.Lite.Controls
{
	using System;
	using Xamarin.Forms;
	using Xamarin.Forms.Xaml;

	/// <summary>Custom TitleBar content view.</summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class TitleBar : ContentView
	{
		public static readonly BindableProperty LabelStyleProperty = BindableProperty.Create(nameof(LabelStyle), typeof(Style), typeof(TitleBar), null, BindingMode.TwoWay, null, LabelStylePropertyChanged);

		/// <summary>Gets or sets the title Property, and it is a bindable property.</summary>
		public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(TitleBar), string.Empty, BindingMode.Default, null, OnTextChanged);

		public TitleBar()
		{
			InitializeComponent();
		}

		public Style LabelStyle { get; set; }

		/// <summary>Gets or sets the Text.</summary>
		public string Text
		{
			get => (string)GetValue(TextProperty);
			set => SetValue(TextProperty, value);
		}

		private static void LabelStylePropertyChanged(BindableObject bindable, object oldValue, object newValue)
		{
			TitleBar tb = (TitleBar)bindable;
			tb.Title.Style = (Style)newValue;
		}

		private static void OnTextChanged(BindableObject bindable, object oldValue, object newValue)
		{
			TitleBar tb = bindable as TitleBar;
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