using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using ProjectODataServer.Json;

namespace ProjectODataServer
{
	public class CoreInstaller : IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(
				Component.For<IDateTimeService>().ImplementedBy<DateTimeService>().LifestyleSingleton().IsFallback(),
				Component.For<IJsonSerializer>().ImplementedBy<MessagePackJsonSerializer>().LifestyleSingleton().IsFallback()
				);
		}
	}
}