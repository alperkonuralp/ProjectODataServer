using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Sample.Data.DbContexts;
using Sample.Data.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;

namespace ProjectODataServer
{
	public class GenericTypeControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
	{
		public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
		{
			var types = new[] { typeof(Product), typeof(Category) };

			var sb = new StringBuilder();

			sb.AppendLine(@"using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Sample.Data.DbContexts;
using Sample.Data.Entities;
using System.Linq;

namespace ProjectODataServer.Controllers.OData
{");

			foreach (var type in types)
			{
				sb.AppendLine($@"public class {type.Name}Controller : ControllerBase
	{{
		private readonly SampleDataDbContext _db;

		public {type.Name}Controller(SampleDataDbContext db)
		{{
			_db = db;
		}}

		[EnableQuery]
		public IQueryable<{type.Name}> Get()
		{{
			return _db.Set<{type.Name}>();
		}}
	}}
");
			}

			sb.AppendLine("}");

			var dynamicAssembly = BuildCode(sb.ToString());

			foreach(var type in types)
			{
				var t = dynamicAssembly.GetExportedTypes().First(x => x.Name == type.Name + "Controller");

				feature.Controllers.Add(t.GetTypeInfo());
			}
		}

		private Assembly BuildCode(string sourceCode)
		{
			var codeString = SourceText.From(sourceCode);
			var options = CSharpParseOptions.Default.WithLanguageVersion(LanguageVersion.CSharp7_3);

			var parsedSyntaxTree = SyntaxFactory.ParseSyntaxTree(codeString, options);

			var references = new List<string>
			{
								typeof(object).Assembly.Location,
								typeof(Console).Assembly.Location,
								typeof(System.Runtime.AssemblyTargetedPatchBandAttribute).Assembly.Location,
								typeof(Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo).Assembly.Location,
								typeof(SampleDataDbContext).Assembly.Location,
								typeof(ControllerBase).Assembly.Location,
								typeof(IQueryable).Assembly.Location,
								typeof(IQueryable<>).Assembly.Location,
								typeof(DbContext).Assembly.Location,
								typeof(EnableQueryAttribute).Assembly.Location,
								Path.Combine(Path.GetDirectoryName(typeof(System.Runtime.GCSettings).GetTypeInfo().Assembly.Location), "mscorlib.dll"),
								Path.Combine(Path.GetDirectoryName(typeof(System.Runtime.GCSettings).GetTypeInfo().Assembly.Location), "netstandard.dll"),
								Path.Combine(Path.GetDirectoryName(typeof(System.Runtime.GCSettings).GetTypeInfo().Assembly.Location), "System.Runtime.dll"),
								typeof(IAsyncEnumerable<>).Assembly.Location,
								typeof(System.ComponentModel.TypeConverter.StandardValuesCollection).Assembly.Location,
								Path.Combine(Path.GetDirectoryName(this.GetType().Assembly.Location), "Microsoft.Bcl.AsyncInterfaces.dll"),
			};



			var cc = CSharpCompilation.Create("DynamicODataControllers.dll",
					new[] { parsedSyntaxTree },
					references: references.Distinct().Select(x=> MetadataReference.CreateFromFile(x)).AsEnumerable(),
					options: new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary,
							optimizationLevel: OptimizationLevel.Release,
							assemblyIdentityComparer: DesktopAssemblyIdentityComparer.Default));

			using (var peStream = new MemoryStream())
			{
				var result = cc.Emit(peStream);

				if (!result.Success)
				{
					Console.WriteLine("Compilation done with error.");

					var failures = result.Diagnostics.Where(diagnostic => diagnostic.IsWarningAsError || diagnostic.Severity == DiagnosticSeverity.Error);

					foreach (var diagnostic in failures)
					{
						Console.Error.WriteLine("{0}: {1}", diagnostic.Id, diagnostic.GetMessage());
					}

					return null;
				}
				else
				{
					peStream.Seek(0, SeekOrigin.Begin);
					var assembly = AssemblyLoadContext.Default.LoadFromStream(peStream);
					return assembly;
				}
			}
		}
	}
}