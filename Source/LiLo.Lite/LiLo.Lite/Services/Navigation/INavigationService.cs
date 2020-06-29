//-----------------------------------------------------------------------
// <copyright file="INavigationService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Navigation service interface.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Services.Navigation
{
	using System.Threading.Tasks;
	using LiLo.Lite.ViewModels.Base;

	/// <summary>Navigation service interface.</summary>
	public interface INavigationService
	{
		/// <summary>Initialises navigation.</summary>
		/// <returns>Navigation task.</returns>
		Task InitializeAsync();

		/// <summary>Navigate to a generic viewModel type.</summary>
		/// <typeparam name="TViewModel">View Model</typeparam>
		/// <returns>Navigation task.</returns>
		Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase;

		/// <summary>Navigate to a generic viewModel type.</summary>
		/// <typeparam name="TViewModel">View Model</typeparam>
		/// <param name="parameter">Optional navigation parameter.</param>
		/// <returns>Navigation task.</returns>
		Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase;

	}
}