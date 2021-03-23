// <copyright file="AssemblyInfo.cs" company="InternetWideWorld.com">
// Copyright (c) George Leithead, InternetWideWorld.  All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY
// OF ANY KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT
// LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND
// FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>

using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace System.Runtime.CompilerServices
{
	/// <summary>Fix for C#9 quirk in non-.NET 5 project and when using a record.</summary>
#pragma warning disable SA1649 // File name should match first type name
	public class IsExternalInit
	{
	}
#pragma warning restore SA1649 // File name should match first type name
}