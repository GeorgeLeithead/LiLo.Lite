//-----------------------------------------------------------------------
// <copyright file="CustomStackLayout.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Customised label with Price1hrPercentSupported property.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Controls
{
	using Xamarin.Forms;
	using Xamarin.Forms.Internals;

	/// <summary>Customised label with Price1hrPercentSupported property.</summary>
	[Preserve(AllMembers = true)]
	public class CustomStackLayout : StackLayout
	{
		/// <summary>Gets or sets the Price1hrPercentSupported Property, and it is a bindable property.</summary>
		public static readonly BindableProperty Price1hrPercentSupportedProperty = BindableProperty.Create(nameof(Price1hrPercentSupported), typeof(double), typeof(StackLayout), 0.0, BindingMode.Default);

		public double Price1hrPercentSupported
		{
			get => (double)GetValue(Price1hrPercentSupportedProperty);
			set => SetValue(Price1hrPercentSupportedProperty, value);
		}
	}
}
