//-----------------------------------------------------------------------
// <copyright file="CustomPancakeView.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Customised Pancake view with IsSelected property.
// </summary>
//-----------------------------------------------------------------------


namespace LiLo.Lite.Controls
{
	using Xamarin.Forms;
	using Xamarin.Forms.Internals;
	using Xamarin.Forms.PancakeView;

	/// <summary>Customised Pancake view with IsSelected property.</summary>
	[Preserve(AllMembers = true)]
	public class CustomPancakeView : PancakeView
	{
		/// <summary>Gets or sets the IsSelected Property, and it is a bindable property.</summary>
		public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(PancakeView), false, BindingMode.Default);

		public bool IsSelected
		{
			get => (bool)GetValue(IsSelectedProperty);
			set => SetValue(IsSelectedProperty, value);
		}
	}
}
