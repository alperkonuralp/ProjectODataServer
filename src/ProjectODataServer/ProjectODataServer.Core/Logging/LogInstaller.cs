using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Services.Logging.Log4netIntegration;
using Castle.Windsor;

namespace ProjectODataServer.Logging
{
	public class LogInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.AddFacility<LoggingFacility>(c => c.LogUsing<Log4netFactory>().ConfiguredExternally().ToLog(string.Empty));
		}
	}
}