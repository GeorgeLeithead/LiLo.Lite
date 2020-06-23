//-----------------------------------------------------------------------
// <copyright file="CustomShadowFrame.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Customizes the shadow effects of the Frame control in iOS to make the shadow effects looks similar to Android.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Controls
{
	using Xamarin.Forms;
	using Xamarin.Forms.Internals;

	/// <summary>Customizes the shadow effects of the Frame control in iOS to make the shadow effects looks similar to Android.</summary>
	[Preserve(AllMembers = true)]
	public class CustomShadowFrame : Frame
	{
		/// <summary>Gets or sets the Border Width Property, and it is a bindable property.</summary>
		public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(nameof(BorderWidth), typeof(int), typeof(CustomShadowFrame), default(int), BindingMode.Default);

		/// <summary>Gets or sets the Custom Border Colour Property, and it is a bindable property.</summary>
		public static readonly BindableProperty CustomBorderColorProperty = BindableProperty.Create(nameof(CustomBorderColor), typeof(Color), typeof(CustomShadowFrame), default(Color), BindingMode.Default);

		/// <summary>Gets or sets the Radius Property, and it is a bindable property.</summary>
		public static readonly BindableProperty RadiusProperty = BindableProperty.Create(nameof(Radius), typeof(float), typeof(CustomShadowFrame), 0f, BindingMode.Default);

		/// <summary>Gets or sets the Shadow Offset Height Property, and it is a bindable property.</summary>
		public static readonly BindableProperty ShadowOffSetHeightProperty = BindableProperty.Create(nameof(ShadowOffSetHeight), typeof(float), typeof(CustomShadowFrame), 4f, BindingMode.Default);

		/// <summary>Gets or sets the Shadow Offset Width Property, and it is a bindable property.</summary>
		public static readonly BindableProperty ShadowOffsetWidthProperty = BindableProperty.Create(nameof(ShadowOffsetWidth), typeof(float), typeof(CustomShadowFrame), 0f, BindingMode.Default);

		/// <summary>Gets or sets the Shadow Opacity Property, and it is a bindable property.</summary>
		public static readonly BindableProperty ShadowOpacityProperty = BindableProperty.Create(nameof(ShadowOpacity), typeof(float), typeof(CustomShadowFrame), 0.12F, BindingMode.Default);

		/// <summary>Gets or sets the border width of the Frame.</summary>
		public int BorderWidth
		{
			get => (int)GetValue(BorderWidthProperty);
			set => SetValue(BorderWidthProperty, value);
		}

		/// <summary>Gets or sets the border colour of the Frame.</summary>
		public Color CustomBorderColor
		{
			get => (Color)GetValue(CustomBorderColorProperty);
			set => SetValue(CustomBorderColorProperty, value);
		}

		/// <summary>Gets or sets the radius of the Frame corners.</summary>
		public float Radius
		{
			get => (float)GetValue(RadiusProperty);
			set => SetValue(RadiusProperty, value);
		}

		/// <summary>Gets or sets the shadow offset height of the Frame.</summary>
		public float ShadowOffSetHeight
		{
			get => (float)GetValue(ShadowOffSetHeightProperty);
			set => SetValue(ShadowOffSetHeightProperty, value);
		}

		/// <summary>Gets or sets the shadow offset width of the Frame.</summary>
		public float ShadowOffsetWidth
		{
			get => (float)GetValue(ShadowOffsetWidthProperty);
			set => SetValue(ShadowOffsetWidthProperty, value);
		}

		/// <summary>Gets or sets the shadow opacity of the Frame.</summary>
		public float ShadowOpacity
		{
			get => (float)GetValue(ShadowOpacityProperty);
			set => SetValue(ShadowOpacityProperty, value);
		}
	}
}
