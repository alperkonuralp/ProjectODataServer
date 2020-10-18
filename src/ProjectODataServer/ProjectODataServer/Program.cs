using Castle.Windsor.MsDependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ProjectODataServer.Logging;
using System.IO;

namespace ProjectODataServer
{
	public class Program
	{
		public static ILogManager LogManager { get; private set; }
		public static ODataServer Server { get; private set; }

		public static void Main(string[] args)
		{
			LogManager = new LogManager(Path.GetDirectoryName(typeof(Program).Assembly.Location));
			Server = new ODataServer(LogManager);
			Server.InstallFrom<Program>();

			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
				Host.CreateDefaultBuilder(args)
						.ConfigureLogging(LogManager.ConfigureLoggingBuilder)
						.ConfigureWebHostDefaults(webBuilder =>
						{
							webBuilder.UseStartup<Startup>();
						})
						.UseServiceProviderFactory(new WindsorServiceProviderFactory())
			;
	}
}