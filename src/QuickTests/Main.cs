using System;
using System.IO;
using Boo.Lang.Compiler;
using Boo.Lang.Compiler.IO;

namespace QuickTests
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			BooCompiler compiler = new BooCompiler();
			
			
			var p = new Boo.Lang.Compiler.Pipelines.CompileToMemory();
			var xml_step = new Boo.Lang.Compiler.Steps.SerializeToXml();
			p.InsertBefore(typeof(Boo.Lang.Compiler.Steps.ExpandComplexSlicingExpressions),xml_step);
			p.InsertAfter(typeof(Boo.Lang.Compiler.Steps.ExpandComplexSlicingExpressions),xml_step);
			p.InsertBefore(typeof(Boo.Lang.Compiler.Steps.EmitAssembly),xml_step);
			//var p = new Boo.Lang.Compiler.Pipelines.ParseAndPrintXml();
			//compiler.Parameters.OutputWriter = new StreamW
			
			compiler.Parameters.Pipeline = p;
			compiler.Parameters.Input.Add(new FileInput("multi_dim_array_slice.boo"));
			CompilerContext context = compiler.Run();
			Console.WriteLine(context.Errors.Count);
			Console.Write(context.Warnings.Count);
			Console.WriteLine(context.Errors.ToString());
		}
	}
}
