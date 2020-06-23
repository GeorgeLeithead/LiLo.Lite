//-----------------------------------------------------------------------
// <copyright file="StatusTemplateSelector.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Data template selector for the status bound item.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Controls
{
	using Xamarin.Forms;

	/// <summary>Data template selector for the status bound item.</summary>
	public class StatusTemplateSelector : DataTemplateSelector
	{
		/// <summary>Cancelled order status data template.</summary>
		public DataTemplate Cancelled { get; set; }

		/// <summary>Created order status data template.</summary>
		public DataTemplate Created { get; set; }

		/// <summary>Deactivated order status data template.</summary>
		public DataTemplate Deactivated { get; set; }

		/// <summary>Filled order status data template.</summary>
		public DataTemplate Filled { get; set; }

		/// <summary>In progress order status data template.</summary>
		public DataTemplate InProgress { get; set; }

		/// <summary>New order status data template.</summary>
		public DataTemplate New { get; set; }

		/// <summary>Partially filled oder status data template.</summary>
		public DataTemplate PartiallyFilled { get; set; }

		/// <summary>Pending order status data template.</summary>
		public DataTemplate Pending { get; set; }

		/// <summary>Pending cancel order status data template.</summary>
		public DataTemplate PendingCancel { get; set; }

		/// <summary>Rejected order status data template.</summary>
		public DataTemplate Rejected { get; set; }

		/// <summary>Selection template matcher.</summary>
		/// <param name="item">Bound item.</param>
		/// <param name="container">Bound item container.</param>
		/// <returns>Data Template.</returns>
		protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
		{
			if (item is null)
			{
				throw new System.ArgumentNullException(nameof(item));
			}

			if (container is null)
			{
				throw new System.ArgumentNullException(nameof(container));
			}

			string value = item as string;
			return value switch
			{
				"Created" => Created,
				"New" => New,
				"PartiallyFilled" => PartiallyFilled,
				"Filled" => Filled,
				"Cancelled" => Cancelled,
				"Rejected" => Rejected,
				"PendingCancel" => PendingCancel,
				"Deactivated" => Deactivated,
				"InProgress" => InProgress,
				_ => Pending,
			};
		}
	}
}
