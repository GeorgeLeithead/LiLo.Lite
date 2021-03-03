//-----------------------------------------------------------------------
// <copyright file="BindableBehavior.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Bindable behavior class.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Behaviors.Base
{
	using System;
	using Xamarin.Forms;

	/// <summary>Bindable behaviour class.</summary>
	/// <typeparam name="T">Generic type.</typeparam>
	public class BindableBehavior<T> : Behavior<T>
		where T : BindableObject
	{
		/// <summary>Gets the Associated object.</summary>
		public T AssociatedObject { get; private set; }

		/// <summary>Attached to event handler.</summary>
		/// <param name="visualElement">Visual Element.</param>
		protected override void OnAttachedTo(T visualElement)
		{
			base.OnAttachedTo(visualElement);
			this.AssociatedObject = visualElement;
			if (visualElement.BindingContext != null)
			{
				this.BindingContext = visualElement.BindingContext;
			}

			visualElement.BindingContextChanged += this.OnBindingContextChanged;
		}

		/// <summary>Binding context changed event handler.</summary>
		protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
			this.BindingContext = this.AssociatedObject.BindingContext;
		}

		/// <summary>Detaching from event handler.</summary>
		/// <param name="view">View element.</param>
		protected override void OnDetachingFrom(T view)
		{
			view.BindingContextChanged -= this.OnBindingContextChanged;
		}

		/// <summary>Binding context changed event handler.</summary>
		/// <param name="sender">Sending object.</param>
		/// <param name="e">Event arguments.</param>
		private void OnBindingContextChanged(object sender, EventArgs e)
		{
			this.OnBindingContextChanged();
		}
	}
}