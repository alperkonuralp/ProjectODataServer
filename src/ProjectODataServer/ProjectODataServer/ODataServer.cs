using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Castle.Windsor.Installer;
using ProjectODataServer.Logging;

namespace ProjectODataServer
{
	public class ODataServer
	{
		public readonly ILogManager LogManager;
		public readonly IWindsorContainer Container = new WindsorContainer();

		public ODataServer(ILogManager logManager)
		{
			LogManager = logManager;

			Container.Register(
				Component.For<ILogManager>().Instance(LogManager),
				Component.For<ODataServer>().Instance(this),
				Component.For<IWindsorContainer>().Instance(Container),
				Component.For<IDateTimeService>().ImplementedBy<DateTimeService>().LifestyleSingleton()
				);

			Container.Install(FromAssembly.Containing<ODataServer>());
		}
	}
}