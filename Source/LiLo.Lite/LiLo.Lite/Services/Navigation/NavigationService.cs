//-----------------------------------------------------------------------
// <copyright file="NavigationService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Navigation service.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Services.Navigation
{
	using LiLo.Lite.ViewModels;
	using LiLo.Lite.ViewModels.Base;
	using LiLo.Lite.Views;
	using Plugin.SharedTransitions;
	using System;
	using System.Globalization;
	using System.Reflection;
	using System.Threading.Tasks;
	using Xamarin.Forms;

	/// <summary>Navigation service.</summary>
	public class NavigationService : INavigationService
	{
		/// <summary>Initialises a new instance of the <see cref="NavigationService"/> class.</summary>
		public NavigationService()
		{
		}

		/// <summary>Initialises navigation.</summary>
		/// <returns>Navigation task.</returns>
		public Task InitializeAsync()
		{
			return NavigateToAsync<HomeViewModel>();
		}

		/// <summary>Navigate to a generic viewModel type.</summary>
		/// <typeparam name="TViewModel">View Model</typeparam>
		/// <returns>Navigation task.</returns>
		public Task NavigateToAsync<TViewModel>() where TViewModel : ViewModelBase
		{
			return InternalNavigateToAsync(typeof(TViewModel), null);
		}

		/// <summary>Navigate to a generic viewModel type.</summary>
		/// <typeparam name="TViewModel">View Model</typeparam>
		/// <returns>Navigation task.</returns>
		public Task NavigateToAsync<TViewModel>(object parameter) where TViewModel : ViewModelBase
		{
			return InternalNavigateToAsync(typeof(TViewModel), parameter);
		}

		/// <summary>creates a new page</summary>
		/// <param name="viewModelType">View Model type.</param>
		/// <returns>Created page instance.</returns>
		private Page CreatePage(Type viewModelType)
		{
			Type pageType = GetPageTypeForViewModel(viewModelType);
			if (pageType == null)
			{
				throw new Exception($"Cannot locate page type for {viewModelType}");
			}

			return Activator.CreateInstance(pageType) as Page;
		}

		/// <summary>Get the page type fro the view Model</summary>
		/// <param name="viewModelType">View model type.</param>
		/// <returns>View Type.</returns>
		private Type GetPageTypeForViewModel(Type viewModelType)
		{
			Type viewType = Type.GetType(string.Format(CultureInfo.InvariantCulture, "{0}, {1}", viewModelType.FullName.Replace("Model", string.Empty), viewModelType.GetTypeInfo().Assembly.FullName));
			return viewType;
		}

		/// <summary>Perform navigation.</summary>
		/// <param name="viewModelType">View model type.</param>
		/// <param name="parameter">Optional navigation parameter.</param>
		/// <returns>Navigation task.</returns>
		private async Task InternalNavigateToAsync(Type viewModelType, object parameter)
		{
			Page page = CreatePage(viewModelType);
			if (page is HomeView)
			{
				Application.Current.MainPage = new SharedTransitionNavigationPage(page);
			}
			else
			{
				SharedTransitionNavigationPage navigationPage = Application.Current.MainPage as SharedTransitionNavigationPage;
				SharedTransitionNavigationPage.SetTransitionSelectedGroup(navigationPage, parameter as string);
				await navigationPage.PushAsync(page);
			}

			await (page.BindingContext as ViewModelBase).InitializeAsync(parameter);
		}
	}
}