// <auto-generated>
//   This code file has automatically been added by the "System.Runtime.CompilerServices.RuntimeHelpers.GetSubArray" NuGet package (https://www.nuget.org/packages/System.Runtime.CompilerServices.RuntimeHelpers.GetSubArray).
//
//   IMPORTANT:
//   DO NOT DELETE THIS FILE if you are using a "packages.config" file to manage your NuGet references.
//   Consider migrating to PackageReferences instead:
//   https://docs.microsoft.com/en-us/nuget/consume-packages/migrate-packages-config-to-package-reference
//   Migrating brings the following benefits:
//   * The "System.Runtime.CompilerServices.RuntimeHelpers" folder and the "GetSubArray.cs" file doesn't appear in your project.
//   * The added files are immutable and can therefore not be modified by coincidence.
//   * Updating/Uninstalling the package will work flawlessly.
// </auto-generated>

#region License
// MIT License
// 
// Copyright (c) Manuel Römer
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
#endregion

namespace System.Runtime.CompilerServices
{
	public static class RuntimeHelpers
	{
		public static T[] GetSubArray<T>(T[] array, Range range)
		{
			var (offset, length) = range.GetOffsetAndLength(array.Length);
			if (length == 0)
				return Array.Empty<T>();
			T[] dest;
			if (typeof(T).IsValueType || typeof(T[]) == array.GetType())
			{
				// We know the type of the array to be exactly T[] or an array variance
				// compatible value type substitution like int[] <-> uint[].

				if (length == 0)
				{
					return Array.Empty<T>();
				}

				dest = new T[length];
			}
			else
			{
				// The array is actually a U[] where U:T. We'll make sure to create
				// an array of the exact same backing type. The cast to T[] will
				// never fail.

				dest = (T[])(Array.CreateInstance(array.GetType().GetElementType()!, length));
			}
			Array.Copy(array, offset, dest, 0, length);
			return dest;
		}
	}
}
