// <copyright file="SettingsViewModel.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>

namespace LiLo.Lite.ViewModels
{
	using LiLo.Lite.ViewModels.Base;

	/// <summary>Settings view model.</summary>
	public class SettingsViewModel : ViewModelBase
	{
		/// <summary>Initialises a new instance of the <see cref="SettingsViewModel"/> class.</summary>
		public SettingsViewModel()
		{
			this.IsBusy = true;
			this.Title = "Settings";
			this.IsBusy = false;
		}
	}
}