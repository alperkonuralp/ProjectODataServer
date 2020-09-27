using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using Microsoft.AspNet.OData.Builder;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using Microsoft.OData.Edm;
using Sample.Data.DbContexts;
using Sample.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace ProjectODataServer
{
	public class Startup
	{
		//public static readonly ILoggerFactory loggerFactory = ;

		public static IWindsorContainer Container { get; } = new WindsorContainer();

		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			services.AddSingleton(Container);

			services.AddOptions();
			services.AddControllers();

			services.AddOData();

			services.AddDbContext<SampleDataDbContext>(c => 
				c
				.EnableSensitiveDataLogging()
				.EnableDetailedErrors()
				//.UseLoggerFactory(loggerFactory)
				.UseSqlite("Data Source=SampleData.db")
				);

			Container.Register(
				Component.For<IConfiguration>()
					.Instance(Configuration)
				);

			Container.Install(FromAssembly.Containing<Startup>());

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
				endpoints.MapODataRoute("odata", "odata", GetEdmModel());
			});
		}

		private IEdmModel GetEdmModel()
		{
			var odataBuilder = new ODataConventionModelBuilder();
			odataBuilder.EntitySet<Category>("Category");
			odataBuilder.EntitySet<Product>("Product");

			return odataBuilder.GetEdmModel();
		}
	}
}