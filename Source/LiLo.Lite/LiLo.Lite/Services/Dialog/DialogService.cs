// <copyright file="DialogService.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

namespace LiLo.Lite.Services.Dialog
{
	using System.Threading.Tasks;
	using Acr.UserDialogs;
	using Xamarin.Forms;

	/// <summary>Dialogue service.</summary>
	public class DialogService : IDialogService
	{
		/// <summary>Initialises a new instance of the <see cref="DialogService"/> class.</summary>
		public DialogService()
		{
		}

		/// <summary>Show a cross-platform alert.</summary>
		/// <param name="message">Alert message.</param>
		/// <param name="title">Alert title.</param>
		/// <param name="buttonLabel">Alert button label text.</param>
		/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
		public Task ShowAlertAsync(string message, string title, string buttonLabel)
		{
			Page page = Application.Current.MainPage;
			return page == null ? Task.CompletedTask : UserDialogs.Instance.AlertAsync(message, title, buttonLabel);
		}

		/// <summary>Show a cross-platform prompt.</summary>
		/// <param name="title">Prompt title.</param>
		/// <param name="message">Prompt message.</param>
		/// <param name="okText">OK button label text.</param>
		/// <param name="cancelText">Cancel button label text.</param>
		/// <returns>A <see cref="Task{PromptResult}"/> representing the asynchronous operation.</returns>
		public Task<PromptResult> ShowPromptAsync(string title, string message, string okText, string cancelText)
		{
			Page page = Application.Current.MainPage;
			if (page == null)
			{
				PromptResult pr = null;
				return Task.FromResult(result: pr);
			}

			return UserDialogs.Instance.PromptAsync(message, title, okText, cancelText);
		}

		/// <summary>Show a cross-platform Toast.</summary>
		/// <param name="message">Toast message.</param>
		/// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
		public Task ShowToastAsync(string message)
		{
			Page page = Application.Current.MainPage;
			if (page == null)
			{
				return Task.CompletedTask;
			}

			_ = UserDialogs.Instance.Toast(message);
			return Task.CompletedTask;
		}
	}
}