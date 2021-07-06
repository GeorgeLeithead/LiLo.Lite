// <copyright file="ViewExtensions.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Extensions
{
	using System;
	using System.Threading.Tasks;
	using Xamarin.Forms;

	/// <summary>View animation extensions.</summary>
	public static class ViewExtensions
	{
		/// <summary>Cancel any existing animation.</summary>
		/// <param name="self">The visual element being animated.</param>
		public static void CancelAnimation(this VisualElement self)
		{
			if (self is null)
			{
				throw new ArgumentNullException(nameof(self));
			}

			_ = self.AbortAnimation("ColorTo");
		}

		/// <summary>Add Colour animation to element.</summary>
		/// <param name="self">The visual element being animated.</param>
		/// <param name="fromColor">Colour to start from.</param>
		/// <param name="toColor">Colour to end at.</param>
		/// <param name="callback">Action to call back.</param>
		/// <param name="length">Duration of animation.</param>
		/// <param name="easing">Non-linear easing of animation.</param>
		/// <returns>A <see cref="Task{Boolean}"/> representing the asynchronous operation.</returns>
		public static Task<bool> ColorTo(this VisualElement self, Color fromColor, Color toColor, Action<Color> callback, uint length = 250, Easing easing = null)
		{
			if (self is null)
			{
				throw new ArgumentNullException(nameof(self));
			}

			if (callback is null)
			{
				throw new ArgumentNullException(nameof(callback));
			}

			Color Transform(double t)
			{
				return Color.FromRgba(
fromColor.R + (t * (toColor.R - fromColor.R)),
fromColor.G + (t * (toColor.G - fromColor.G)),
fromColor.B + (t * (toColor.B - fromColor.B)),
fromColor.A + (t * (toColor.A - fromColor.A)));
			}

			return ColorAnimation(self, "ColorTo", Transform, callback, length, easing);
		}

		/// <summary>Add animation to visual element.</summary>
		/// <param name="element">The visual element being animated.</param>
		/// <param name="name">Name of animation.</param>
		/// <param name="transform">Transformation for animation.</param>
		/// <param name="callback">Action to call back.</param>
		/// <param name="length">Duration of animation.</param>
		/// <param name="easing">Non-linear easing of animation.</param>
		/// <returns>A <see cref="Task{Boolean}"/> representing the asynchronous operation.</returns>
		private static Task<bool> ColorAnimation(VisualElement element, string name, Func<double, Color> transform, Action<Color> callback, uint length, Easing easing)
		{
			if (element is null)
			{
				throw new ArgumentNullException(nameof(element));
			}

			if (string.IsNullOrEmpty(name))
			{
				throw new ArgumentException("message", nameof(name));
			}

			if (transform is null)
			{
				throw new ArgumentNullException(nameof(transform));
			}

			if (callback is null)
			{
				throw new ArgumentNullException(nameof(callback));
			}

			easing ??= Easing.Linear;
			TaskCompletionSource<bool> taskCompletionSource = new TaskCompletionSource<bool>();
			element.Animate(name, transform, callback, 16, length, easing, (v, c) => taskCompletionSource.SetResult(c));
			return taskCompletionSource.Task;
		}
	}
}