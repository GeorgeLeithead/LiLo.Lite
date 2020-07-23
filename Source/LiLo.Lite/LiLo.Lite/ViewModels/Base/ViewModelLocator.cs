//-----------------------------------------------------------------------
// <copyright file="ViewModelLocator.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   ViewModel locater.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.ViewModels.Base
{
	using System;
	using System.Globalization;
	using System.Reflection;
	using LiLo.Lite.Services.Dependency;
	using LiLo.Lite.Services.Markets;
	using LiLo.Lite.Services.Navigation;
	using LiLo.Lite.Services.Settings;
	using LiLo.Lite.Services.Sockets;
	using TinyIoC;
	using Xamarin.Forms;

	/// <summary>ViewModel locater.</summary>
	public static class ViewModelLocator
	{
		/// <summary>Auto wire the view model extended property.</summary>
		public static readonly BindableProperty AutoWireViewModelProperty = BindableProperty.CreateAttached("AutoWireViewModel", typeof(bool), typeof(ViewModelLocator), default(bool), propertyChanged: OnAutoWireViewModelChanged);

		/// <summary>IOC container.</summary>
		private static readonly TinyIoCContainer IocContainer;

		/// <summary>Initialises static members of the <see cref="ViewModelLocator"/> class.</summary>
		static ViewModelLocator()
		{
			IocContainer = new TinyIoCContainer();

			// View models - by default, TinyIoC will register concrete classes as multi-instance.
			IocContainer.Register<HomeViewModel>();
			IocContainer.Register<ChartViewModel>();

			// Services - by default, TinyIoC will register interface registrations as singletons.
			IocContainer.Register<INavigationService, NavigationService>();
			IocContainer.Register<IDependencyService, Services.Dependency.DependencyService>();
			IocContainer.Register<IMarketsService, MarketsService>();
			IocContainer.Register<ISettingsService, SettingsService>();
			IocContainer.Register<ISocketsService, SocketsService>();
			IocContainer.Register<IMarketsHelperService, MarketsHelperService>();
		}

		/// <summary>Gets or sets a value indicating whether to use the mock service.</summary>
		public static bool UseMockService { get; set; }

		/// <summary>Get the auto wired viewModel bindable object.</summary>
		/// <param name="bindable">Bindable object</param>
		/// <returns>Bound value</returns>
		public static bool GetAutoWireViewModel(BindableObject bindable)
		{
			return (bool)bindable.GetValue(AutoWireViewModelProperty);
		}

		/// <summary>Registers a singleton</summary>
		/// <typeparam name="TInterface">Singleton interface.</typeparam>
		/// <typeparam name="T">Singleton to register</typeparam>
		public static void RegisterSingleton<TInterface, T>() where TInterface : class where T : class, TInterface
		{
			IocContainer.Register<TInterface, T>().AsSingleton();
		}

		/// <summary>Resolve a concrete class.</summary>
		/// <typeparam name="T">Singleton type.</typeparam>
		/// <returns>Resolved concrete class.</returns>
		public static T Resolve<T>() where T : class
		{
			return IocContainer.Resolve<T>();
		}

		/// <summary>Set the auto wired viewModel bindable object.</summary>
		/// <param name="bindable">Bindable object</param>
		/// <param name="value">Bound value</param>
		public static void SetAutoWireViewModel(BindableObject bindable, bool value)
		{
			bindable.SetValue(AutoWireViewModelProperty, value);
		}

		/// <summary>Update registered dependencies based on mock</summary>
		/// <param name="useMockServices">Use mock services.</param>
		public static void UpdateDependencies(bool useMockServices)
		{
			// Change injected dependencies
			if (useMockServices)
			{
				UseMockService = true;
				IocContainer.Register<IMarketsService, MarketsService>();
				IocContainer.Register<ISettingsService, SettingsService>();
			}
			else
			{
				IocContainer.Register<IMarketsService, MarketsService>();
				IocContainer.Register<ISettingsService, SettingsService>();
				UseMockService = false;
			}
		}

		/// <summary>Auto wired viewModel changed.</summary>
		/// <param name="bindable">Bindable object</param>
		/// <param name="oldValue">Old value</param>
		/// <param name="newValue">New value</param>
		private static void OnAutoWireViewModelChanged(BindableObject bindable, object oldValue, object newValue)
		{
			if (!(bindable is Element view))
			{
				return;
			}

			Type viewType = view.GetType();
			string viewName = viewType.FullName.Replace(".Views.", ".ViewModels.");
			string viewAssemblyName = viewType.GetTypeInfo().Assembly.FullName;
			string viewModelName = string.Format(CultureInfo.InvariantCulture, "{0}Model, {1}", viewName, viewAssemblyName);

			Type viewModelType = Type.GetType(viewModelName);
			if (viewModelType == null)
			{
				return;
			}

			object viewModel = IocContainer.Resolve(viewModelType);
			view.BindingContext = viewModel;
		}
	}
}