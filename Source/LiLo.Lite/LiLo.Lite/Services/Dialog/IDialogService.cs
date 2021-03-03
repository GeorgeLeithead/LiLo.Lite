//-----------------------------------------------------------------------
// <copyright file="IDialogService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
//   THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
//   OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
//   LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
//   FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
// <summary>
//   Dialogue service interface.
// </summary>
//-----------------------------------------------------------------------

namespace LiLo.Lite.Services.Dialog
{
	using System.Threading.Tasks;
	using Acr.UserDialogs;

	/// <summary>Dialogue service interface.</summary>
	public interface IDialogService
	{
		/// <summary>Show a cross-platform alert.</summary>
		/// <param name="message">Alert message.</param>
		/// <param name="title">Alert title.</param>
		/// <param name="buttonLabel">Alert button label text.</param>
		/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
		Task ShowAlertAsync(string message, string title, string buttonLabel);

		/// <summary>Show a cross-platform prompt.</summary>
		/// <param name="title">Prompt title.</param>
		/// <param name="message">Prompt message.</param>
		/// <param name="okText">OK button label text.</param>
		/// <param name="cancelText">Cancel button label text.</param>
		/// <returns>A <see cref="Task{PromptResult}"/> representing the asynchronous operation.</returns>
		Task<PromptResult> ShowPromptAsync(string title, string message, string okText, string cancelText);

		/// <summary>Show a cross-platform Toast.</summary>
		/// <param name="message">Toast message.</param>
		/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
		Task ShowToastAsync(string message);
	}
}