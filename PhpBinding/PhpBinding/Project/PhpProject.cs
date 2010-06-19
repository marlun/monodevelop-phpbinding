// 
// PhpProject.cs
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

using MonoDevelop.Projects;
using MonoDevelop.Core;
using MonoDevelop.Core.Execution;
using MonoDevelop.Core.ProgressMonitoring;
using System.Xml;
using System;

namespace MonoDevelop.PhpBinding
{
	class PhpProject : Project
	{
		public override string ProjectType {
			get { return PhpLanguageBinding.PhpLanguage; }
		}
		
		public override string[] SupportedLanguages {
			get { return new string[] { PhpLanguageBinding.PhpLanguage }; }
		}
		
		public PhpProject() {}

		public PhpProject (ProjectCreateInformation info, XmlElement projectOptions, string language)
		{
			if (info!=null) {
				Name = info.ProjectName;
			}
			
			Configurations.Add(CreateConfiguration("Default"));
		}
		
		public override SolutionItemConfiguration CreateConfiguration(string name)
		{
			PhpProjectConfiguration conf = new PhpProjectConfiguration();
			conf.Name = name;
			
			return conf;
		}

		public override bool IsCompileable (string fileName)
		{
			return false;
		}
		
		/*
		protected override bool OnGetCanExecute (ExecutionContext context, string solutionConfiguration)
		{
			return true;
		}
		
		protected override void DoExecute (IProgressMonitor monitor, ExecutionContext context, string itemConfiguration)
		{
			PhpProjectConfiguration conf = (PhpProjectConfiguration)GetConfiguration(itemConfiguration);
			bool pause = conf.PauseConsoleOutput;
			IConsole console = (conf.ExternalConsole ? context.ExternalConsoleFactory : context.ConsoleFactory).CreateConsole(pause);
			
			ExecutionCommand command = new NativeExecutionCommand(PhpLanguageBinding.PhpInterpreter, conf.MainFile);
			
			monitor.Log.WriteLine("Running {0} {1}", PhpLanguageBinding.PhpInterpreter, conf.MainFile);
			
			AggregatedOperationMonitor operationMonitor = new AggregatedOperationMonitor(monitor);
			
			try {
				if (!context.ExecutionHandler.CanExecute(command)) {
					monitor.ReportError(string.Format("Cannot execute {0}.", conf.MainFile), null);
					return;
				}
				
				IProcessAsyncOperation op = context.ExecutionHandler.Execute(command, console);
				
				operationMonitor.AddOperation(op);
				op.WaitForCompleted();
				
				monitor.Log.WriteLine("The operation exited with code: {0}", op.ExitCode);
			} catch (Exception ex) {
				monitor.ReportError(string.Format("Cannot execute {0}", conf.MainFile), ex);
			}
			finally {
				operationMonitor.Dispose();
				console.Dispose();
			}
		}
		*/
	}
}
