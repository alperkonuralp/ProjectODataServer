using log4net.Config;
using log4net.Repository;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ProjectODataServer.Logging
{
	public class LogManager : ILogManager
	{
		public ILoggerRepository LoggerRepository { get; private set; }
		public LoggerFactory LoggerFactory { get; private set; }
		public Log4NetProvider Log4NetProvider { get; private set; }

		public LogManager(string path = null, string configFileName = null, Assembly repositoryAssembly = null)
		{
			if (string.IsNullOrWhiteSpace(path)) path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

			var fns = string.IsNullOrWhiteSpace(configFileName)
				? new[]{
					Path.Combine(path, "config", "log4net.config.xml"),
					Path.Combine(path, "log4net.config.xml"),
					Path.Combine(path, "config", "log4net.config"),
					Path.Combine(path, "log4net.config"),
				}
				: new[]{
					Path.Combine(path, "config", configFileName),
					Path.Combine(path, configFileName),
				};

			var fn = fns.FirstOrDefault(x => File.Exists(x));

			if (!string.IsNullOrWhiteSpace(fn))
			{
				LoggerRepository = log4net.LogManager.CreateRepository(repositoryAssembly ?? Assembly.GetEntryAssembly() ?? Assembly.GetExecutingAssembly(),
								 typeof(log4net.Repository.Hierarchy.Hierarchy));
				XmlConfigurator.ConfigureAndWatch(LoggerRepository, new FileInfo(fn));

				Log4NetProvider = new Log4NetProvider(new Log4NetProviderOptions { ExternalConfigurationSetup = true });
				LoggerFactory = new LoggerFactory(new[] { Log4NetProvider });
			}
		}

		public void ConfigureLoggingBuilder(ILoggingBuilder l)
		{
			l.ClearProviders();
			l.AddProvider(Log4NetProvider);
		}
	}
}