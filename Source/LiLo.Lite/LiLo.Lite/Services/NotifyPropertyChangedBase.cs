//-----------------------------------------------------------------------
// <copyright file="NotifyPropertyChangedBase.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Notify property changed base class.
// </summary>
//-----------------------------------------------------------------------

namespace Lilo.Lite.Services
{
	using System.ComponentModel;
	using System.Runtime.CompilerServices;

	/// <summary>Notify property changed base class.</summary>
	public abstract class NotifyPropertyChangedBase : INotifyPropertyChanged
	{
		/// <summary>Property changed event handler.</summary>
		public virtual event PropertyChangedEventHandler PropertyChanged;

		/// <summary>This method is called by the Set accessors of each property.</summary>
		/// <param name="propertyName">Optionally causes the property name of the caller to be substituted as an argument.</param>
		protected virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
	}
}