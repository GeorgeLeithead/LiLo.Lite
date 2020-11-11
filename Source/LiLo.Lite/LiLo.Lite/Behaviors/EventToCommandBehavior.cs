//-----------------------------------------------------------------------
// <copyright file="EventToCommandBehavior.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Event to command behavior class.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Behaviors
{
	using LiLo.Lite.Behaviors.Base;
	using System;
	using System.Globalization;
	using System.Linq;
	using System.Linq.Expressions;
	using System.Reflection;
	using System.Windows.Input;
	using Xamarin.Forms;

	/// <summary>Event to command behaviour class.</summary>
	public class EventToCommandBehavior : BindableBehavior<View>
	{
		/// <summary>Gets or sets the Command Parameter Property, and it is a bindable property.</summary>
		public static readonly BindableProperty CommandParameterProperty = BindableProperty.CreateAttached(nameof(CommandParameter), typeof(object), typeof(EventToCommandBehavior), null, BindingMode.OneWay);

		/// <summary>Gets or sets the Command Property, and it is a bindable property.</summary>
		public static readonly BindableProperty CommandProperty = BindableProperty.CreateAttached(nameof(Command), typeof(ICommand), typeof(EventToCommandBehavior), null, BindingMode.OneWay);

		/// <summary>Gets or sets the Event Arguments Converter Parameter Property, and it is a bindable property.</summary>
		public static readonly BindableProperty EventArgsConverterParameterProperty = BindableProperty.CreateAttached(nameof(EventArgsConverterParameter), typeof(object), typeof(EventToCommandBehavior), null, BindingMode.OneWay);

		/// <summary>Gets or sets the Event Arguments Converter Property, and it is a bindable property.</summary>
		public static readonly BindableProperty EventArgsConverterProperty = BindableProperty.CreateAttached(nameof(EventArgsConverter), typeof(IValueConverter), typeof(EventToCommandBehavior), null, BindingMode.OneWay);

		/// <summary>Gets or sets the Event Name Property, and it is a bindable property.</summary>
		public static readonly BindableProperty EventNameProperty = BindableProperty.CreateAttached(nameof(EventName), typeof(string), typeof(EventToCommandBehavior), null, BindingMode.OneWay);

		/// <summary>Delegate handler.</summary>
		private Delegate delegateHandler;

		/// <summary>Event information.</summary>
		private EventInfo eventInfo;

		/// <summary>Gets or sets the bound command.</summary>
		public ICommand Command
		{
			get => (ICommand)GetValue(CommandProperty);
			set => SetValue(CommandProperty, value);
		}

		/// <summary>Gets or sets the command parameter.</summary>
		public object CommandParameter
		{
			get => GetValue(CommandParameterProperty);
			set => SetValue(CommandParameterProperty, value);
		}

		/// <summary>Gets or sets the event arguments value converter.</summary>
		public IValueConverter EventArgsConverter
		{
			get => (IValueConverter)GetValue(EventArgsConverterProperty);
			set => SetValue(EventArgsConverterProperty, value);
		}

		/// <summary>Gets or sets the event arguments value converter parameter.</summary>
		public object EventArgsConverterParameter
		{
			get => GetValue(EventArgsConverterParameterProperty);
			set => SetValue(EventArgsConverterParameterProperty, value);
		}

		/// <summary>Gets or sets the bound event name.</summary>
		public string EventName
		{
			get => (string)GetValue(EventNameProperty);
			set => SetValue(EventNameProperty, value);
		}

		/// <summary>Attached to event handler</summary>
		/// <param name="visualElement">Visual Element</param>
		protected override void OnAttachedTo(View visualElement)
		{
			base.OnAttachedTo(visualElement);
			EventInfo[] events = AssociatedObject.GetType().GetRuntimeEvents().ToArray();
			if (events.Any())
			{
				eventInfo = events.FirstOrDefault(e => e.Name == EventName);
				if (eventInfo == null)
				{
					throw new ArgumentException(string.Format("EventToCommand: Can't find any event named '{0}' on attached type", EventName));
				}

				AddEventHandler(eventInfo, AssociatedObject, OnFired);
			}
		}

		/// <summary>Detaching from event handler.</summary>
		/// <param name="view">View element.</param>
		protected override void OnDetachingFrom(View view)
		{
			if (delegateHandler != null)
			{
				eventInfo.RemoveEventHandler(AssociatedObject, delegateHandler);
			}

			base.OnDetachingFrom(view);
		}

		/// <summary>Attaches the event handler to the delegate.</summary>
		/// <param name="eventInfo">Event information.</param>
		/// <param name="item">Item to add event handler to.</param>
		/// <param name="action">Event handler action.</param>
		private void AddEventHandler(EventInfo eventInfo, object item, Action<object, EventArgs> action)
		{
			ParameterExpression[] eventParameters = eventInfo.EventHandlerType
				.GetRuntimeMethods().First(m => m.Name == "Invoke")
				.GetParameters()
				.Select(p => Expression.Parameter(p.ParameterType))
				.ToArray();

			MethodInfo actionInvoke = action.GetType().GetRuntimeMethods().First(m => m.Name == "Invoke");

			delegateHandler = Expression.Lambda(
				eventInfo.EventHandlerType,
				Expression.Call(Expression.Constant(action), actionInvoke, eventParameters[0], eventParameters[1]),
				eventParameters).Compile();

			eventInfo.AddEventHandler(item, delegateHandler);
		}

		/// <summary>Command fired</summary>
		/// <param name="sender">Event sender</param>
		/// <param name="eventArgs">Event arguments</param>
		private void OnFired(object sender, EventArgs eventArgs)
		{
			if (Command == null)
			{
				return;
			}

			object parameter = CommandParameter;
			if (eventArgs != null && eventArgs != EventArgs.Empty)
			{
				parameter = eventArgs;
				if (EventArgsConverter != null)
				{
					parameter = EventArgsConverter.Convert(eventArgs, typeof(object), EventArgsConverterParameter, CultureInfo.CurrentUICulture);
				}
			}

			if (Command.CanExecute(parameter))
			{
				Command.Execute(parameter);
			}
		}
	}
}
