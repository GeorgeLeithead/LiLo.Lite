// <copyright file="CustomLabel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Controls
{
	using Xamarin.Forms;
	using Xamarin.Forms.Internals;

	/// <summary>Customised label with IsSelected property.</summary>
	[Preserve(AllMembers = true)]
	public class CustomLabel : Label
	{
		/// <summary>Gets or sets the IsSelected Property, and it is a bindable property.</summary>
		public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(CustomLabel), false, BindingMode.Default);

		/// <summary>Gets or sets a value indicating whether is selected.</summary>
		public bool IsSelected
		{
			get => (bool)this.GetValue(IsSelectedProperty);
			set => this.SetValue(IsSelectedProperty, value);
		}
	}
}