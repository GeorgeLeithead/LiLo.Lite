//-----------------------------------------------------------------------
// <copyright file="MarketsListTemplate.xaml.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Markets list template.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Views.Templates
{
	using Xamarin.Forms;
	using Xamarin.Forms.Internals;
	using Xamarin.Forms.Xaml;

	/// <summary>Markets list template.</summary>
	[Preserve(AllMembers = true)]
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MarketsListTemplate : Grid
	{
		/// <summary>Initialises a new instance of the <see cref="MarketsListTemplate"/> class.</summary>
		public MarketsListTemplate() => InitializeComponent();
	}
}
