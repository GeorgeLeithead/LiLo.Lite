//-----------------------------------------------------------------------
// <copyright file="CustomFrameButton.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Customizes a frame control to provide a button like effect.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Controls
{
	using Xamarin.Forms;
	using Xamarin.Forms.Internals;

	/// <summary>Customizes a frame control to provide a button like effect.</summary>
	[Preserve(AllMembers = true)]
	public class CustomFrameButton : CustomShadowFrame
	{
		/// <summary>Gets or sets the IsSelected Property, and it is a bindable property.</summary>
		public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(CustomFrameButton), false, BindingMode.Default);

		/// <summary>Gets or sets a value indicating whether the item is selected.</summary>
		public bool IsSelected
		{
			get => (bool)GetValue(IsSelectedProperty);
			set => SetValue(IsSelectedProperty, value);
		}
	}
}
