using log4net.Repository;
using Microsoft.Extensions.Logging;

namespace ProjectODataServer.Logging
{
	public interface ILogManager
	{
		Log4NetProvider Log4NetProvider { get; }
		LoggerFactory LoggerFactory { get; }
		ILoggerRepository LoggerRepository { get; }

		void ConfigureLoggingBuilder(ILoggingBuilder l);
	}
}