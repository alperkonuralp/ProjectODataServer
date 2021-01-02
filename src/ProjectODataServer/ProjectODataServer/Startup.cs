using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using MessagePack.AspNetCoreMvcFormatter;
using MessagePack.Resolvers;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNet.OData.Routing.Conventions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OData.Edm;
using ProjectODataServer.Services;
using ProjectODataServer.WebApi;
using Sample.Data.DbContexts;
using Sample.Data.Entities;
using System.Linq;

namespace ProjectODataServer
{
	public class Startup
	{
		public IWindsorContainer Container { get; }

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
			Container = Program.Server.Container;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton(Container);

			services.AddOptions();
			services.AddControllers()
				.AddMvcOptions(option =>
				{
					option.OutputFormatters.Clear();
					option.OutputFormatters.Add(new MessagePackOutputFormatter(ContractlessStandardResolver.Options));
					option.InputFormatters.Clear();
					option.InputFormatters.Add(new MessagePackInputFormatter(ContractlessStandardResolver.Options));
				})
				;

			services.AddOData();

			services.AddDbContext<DbContext, SampleDataDbContext>(c =>
				c
				.EnableSensitiveDataLogging()
				.EnableDetailedErrors()
				.UseLoggerFactory(Program.LogManager.LoggerFactory)
				.UseSqlite("Data Source=SampleData.db")
				);

			Container.Register(
				Component
					.For<IConfiguration>()
					.Instance(Configuration)
				);

			var installAssemblies = Configuration
				.GetSection("InstallAssemblies")
				.Get<string[]>();
			if (installAssemblies != null && installAssemblies.Length > 0)
				foreach (var item in installAssemblies)
				{
					Container.Install(FromAssembly.Named(item));
				}
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			app.Use(async (context, next) =>
			{
				using (Container.BeginScope())
				{
					await next();
				}
			});

			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();

				endpoints.Select().Filter().OrderBy().Count().MaxTop(100).Expand();

				// Create the default collection of built-in conventions.
				var conventions = ODataRoutingConventions.CreateDefault();

				// Insert the custom convention at the start of the collection.
				conventions.Insert(0, new NavigationIndexRoutingConvention());

				endpoints.MapODataRoute("odata", "odata", GetEdmModel(), new DefaultODataPathHandler(), conventions);
			});
		}

		private IEdmModel GetEdmModel()
		{
			var odataBuilder = new ODataConventionModelBuilder
			{
				Namespace = "Sample"
			};
			odataBuilder.EntitySet<Vendor>("Vendor");
			odataBuilder.EntitySet<Category>("Category");
			odataBuilder.EntitySet<Product>("Product");

			return odataBuilder.GetEdmModel();
		}
	}

}