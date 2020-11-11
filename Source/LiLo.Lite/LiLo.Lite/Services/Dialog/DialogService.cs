//-----------------------------------------------------------------------
// <copyright file="DialogService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Dialog service.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Services.Dialog
{
	using Acr.UserDialogs;
	using System.Threading.Tasks;

	/// <summary>Dialog service.</summary>
	public class DialogService : IDialogService
	{
		/// <summary>Show a cross-platform alert.</summary>
		/// <param name="message">Alert message</param>
		/// <param name="title">Alert title</param>
		/// <param name="buttonLabel">Alert button label text.</param>
		/// <returns>Alert task</returns>
		public Task ShowAlertAsync(string message, string title, string buttonLabel)
		{
			return UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
		}

		/// <summary>Show a cross-platform prompt.</summary>
		/// <param name="message">prompt message</param>
		/// <param name="title">prompt title</param>
		/// <param name="okText">OK button label text.</param>
		/// <param name="cancelText">Cancel button label text.</param>
		/// <returns>Prompt result task</returns>
		public Task<PromptResult> ShowPromptAsync(string title, string message, string okText, string cancelText)
		{
			return UserDialogs.Instance.PromptAsync(message, title, okText, cancelText);
		}

		/// <summary>Show a cross-platform Toast.</summary>
		/// <param name="message">Toast message</param>
		public Task ShowToastAsync(string message)
		{
			return (Task)UserDialogs.Instance.Toast(message);
		}
	}
}
