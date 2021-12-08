// <copyright file="AssemblyInfo.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.com
// </copyright>

using System.Resources;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
[assembly: NeutralResourcesLanguage("en-GB")]

namespace System.Runtime.CompilerServices
{
	/// <summary>Fix for C#9 quirk in non-.NET 5 project and when using a record.</summary>

	public class IsExternalInit
	{
	}
}