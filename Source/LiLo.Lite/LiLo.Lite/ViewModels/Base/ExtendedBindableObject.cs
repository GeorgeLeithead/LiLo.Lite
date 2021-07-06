// <copyright file="ExtendedBindableObject.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.ViewModels.Base
{
	using System;
	using System.Linq.Expressions;
	using System.Reflection;
	using Xamarin.Forms;

	/// <summary>Extended bindable object class.</summary>
	public abstract class ExtendedBindableObject : BindableObject
	{
		/// <summary>Notify property has changed.</summary>
		/// <typeparam name="T">Property type.</typeparam>
		/// <param name="property">Property changed.</param>
		public void NotifyPropertyChanged<T>(Expression<Func<T>> property)
		{
			string name = this.GetMemberInfo(property).Name;
			this.OnPropertyChanged(name);
		}

		/// <summary>Get member information.</summary>
		/// <param name="expression">Expression member.</param>
		/// <returns>Operand member.</returns>
		private MemberInfo GetMemberInfo(Expression expression)
		{
			MemberExpression operand;
			LambdaExpression lambdaExpression = (LambdaExpression)expression;
			if (lambdaExpression.Body as UnaryExpression != null)
			{
				UnaryExpression body = (UnaryExpression)lambdaExpression.Body;
				operand = (MemberExpression)body.Operand;
			}
			else
			{
				operand = (MemberExpression)lambdaExpression.Body;
			}

			return operand.Member;
		}
	}
}