// 
// PhpLanguageBinding.cs
//  
// Author:
//       Martin Lundberg <martin.lundberg@gmail.com>
// 
// Copyright (c) 2009 Martin Lundberg
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using MonoDevelop.Projects;
using System.IO;
using MonoDevelop.Projects.Dom.Parser;
using MonoDevelop.Projects.CodeGeneration;

namespace MonoDevelop.PhpBinding
{
	public class PhpLanguageBinding : ILanguageBinding
	{
		public static readonly string PhpLanguage = "PHP";
		public static readonly string PhpExtension = ".php";
		public static readonly string PhpInterpreter = "php";

		#region ILanguageBinding implementation
		
		public string SingleLineCommentTag {
			get { return "//"; }
		}
		
		public string BlockCommentStartTag {
			get { return "/*"; }
		}
		
		public string BlockCommentEndTag {
			get { return "*/"; }
		}
		
		public string Language {
			get { return PhpLanguage; }
		}
		
		public IParser Parser {
			get { return null; }
		}
		
		public IRefactorer Refactorer {
			get { return null; }
		}

		public string GetFileName (string fileNameWithoutExtension)
		{
			return string.Format("{0}{1}", fileNameWithoutExtension, PhpExtension);
		}
		
		public bool IsSourceCodeFile (string fileName)
		{
			return IsPhpFile(fileName);
		}

		public static bool IsPhpFile (string fileName)
		{
			return Path.GetExtension(fileName).Equals(PhpExtension, StringComparison.OrdinalIgnoreCase);
		}
				
		#endregion
		

	}
}
