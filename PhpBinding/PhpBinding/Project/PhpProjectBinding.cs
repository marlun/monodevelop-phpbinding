// 
// PhpProjectBinding.cs
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
using System.Xml;

namespace MonoDevelop.PhpBinding
{
	public class PhpProjectBinding : IProjectBinding
	{
		public PhpProjectBinding ()
		{
		}
		
		#region IProjectBinding implementation
		
		public Project CreateProject (ProjectCreateInformation info, XmlElement projectOptions)
		{
			return new PhpProject(info, projectOptions, PhpLanguageBinding.PhpLanguage);
		}
		
		public Project CreateSingleFileProject (string sourceFile)
		{
			ProjectCreateInformation info = new ProjectCreateInformation();
			info.ProjectName = Path.GetFileNameWithoutExtension(sourceFile);
			info.SolutionPath = Path.GetDirectoryName(sourceFile);
			info.ProjectBasePath = Path.GetDirectoryName(sourceFile);
			
			Project project = new PhpProject(info, null, PhpLanguageBinding.PhpLanguage);
			project.Files.Add(new ProjectFile(sourceFile));
			
			return project;
		}
		
		public bool CanCreateSingleFileProject (string sourceFile)
		{
			return PhpLanguageBinding.IsPhpFile(sourceFile);
		}
		
		public string Name {
			get { return PhpLanguageBinding.PhpLanguage; }
		}
		
		#endregion
	}
}
