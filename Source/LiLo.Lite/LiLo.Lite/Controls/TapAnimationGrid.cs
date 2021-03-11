// <copyright file="TapAnimationGrid.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>

namespace LiLo.Lite.Controls
{
	using System.Threading.Tasks;
	using System.Windows.Input;
	using Xamarin.Forms;
	using Xamarin.Forms.Internals;

	/// <summary>Customizes the tap animation effects of the grid control.</summary>
	[Preserve(AllMembers = true)]
	public class TapAnimationGrid : Grid
	{
		/// <summary>Gets or sets the CommandParameterProperty, and it is a bindable property.</summary>
		public static readonly BindableProperty CommandParameterProperty = BindableProperty.Create(nameof(CommandParameter), typeof(object), typeof(TapAnimationGrid), null);

		/// <summary>Gets or sets the CommandProperty, and it is a bindable property.</summary>
		public static readonly BindableProperty CommandProperty = BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(TapAnimationGrid), null);

		/// <summary>Gets or sets the TappedProperty, and it is a bindable property.</summary>
		public static readonly BindableProperty TappedProperty = BindableProperty.Create(nameof(Tapped), typeof(bool), typeof(TapAnimationGrid), false, BindingMode.TwoWay, null, propertyChanged: OnTapped);

		/// <summary>Tapped command.</summary>
		private ICommand tappedCommand;

		/// <summary>Initialises a new instance of the <see cref="TapAnimationGrid" /> class.</summary>
		public TapAnimationGrid() => this.Initialize();

		/// <summary>Gets or sets the command value.</summary>
		public ICommand Command
		{
			get => (ICommand)this.GetValue(CommandProperty);
			set => this.SetValue(CommandProperty, value);
		}

		/// <summary>Gets or sets the command parameter value.</summary>
		public object CommandParameter
		{
			get => this.GetValue(CommandParameterProperty);
			set => this.SetValue(CommandParameterProperty, value);
		}

		/// <summary>Gets or sets a value indicating whether the control is tapped.</summary>
		public bool Tapped
		{
			get => (bool)this.GetValue(TappedProperty);
			set => this.SetValue(TappedProperty, value);
		}

		/// <summary>Gets the tapped command.</summary>
		public ICommand TappedCommand => this.tappedCommand ??= new Command(() =>
		{
			if (this.Tapped)
			{
				this.Tapped = false;
			}
			else
			{
				this.Tapped = true;
			}

			if (this.Command != null)
			{
				this.Command.Execute(this.CommandParameter);
			}
		});

		/// <summary>Invoked when tap on the item.</summary>
		/// <param name="bindable">Bindable object.</param>
		/// <param name="oldValue">Old value object.</param>
		/// <param name="newValue">New value object.</param>
		private static async void OnTapped(BindableObject bindable, object oldValue, object newValue)
		{
			var grid = (TapAnimationGrid)bindable;
			Application.Current.Resources.TryGetValue("Gray-300", out var retVal);
			grid.BackgroundColor = (Color)retVal;

			// To make the selected item colour changes for 100 milliseconds.
			await Task.Delay(100);
			Application.Current.Resources.TryGetValue("Gray-700", out var retValue);
			grid.BackgroundColor = (Color)retValue;
		}

		/// <summary>Invoked when control is initialised.</summary>
		private void Initialize()
		{
			this.GestureRecognizers.Add(new TapGestureRecognizer
			{
				Command = this.TappedCommand,
			});
		}
	}
}