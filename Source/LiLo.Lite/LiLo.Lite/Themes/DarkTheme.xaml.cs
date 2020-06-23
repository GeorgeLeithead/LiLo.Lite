//-----------------------------------------------------------------------
// <copyright file="DarkTheme.xaml.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Dark theme class.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Themes
{
	using Xamarin.Forms;
	using Xamarin.Forms.Internals;
	using Xamarin.Forms.Xaml;

	/// <summary>Dark theme class.</summary>
	[Preserve(AllMembers = true)]
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DarkTheme : ResourceDictionary
	{
		/// <summary>Initialises a new instance of the <see cref="DarkTheme"/> class.</summary>
		public DarkTheme() => InitializeComponent();
	}
}
