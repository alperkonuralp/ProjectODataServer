using Castle.Core.Logging;
using System;

namespace ProjectODataServer
{
	public class DateTimeService : IDateTimeService
	{
		private readonly ILogger _logger;

		public DateTimeService(ILogger logger)
		{
			_logger = logger;
		}

		public DateTime Now()
		{
			_logger.Debug("DateTime.Now = " + DateTime.Now);
			return DateTime.Now;
		}

		public DateTimeOffset NowOffset()
		{
			_logger.Debug("DateTimeOffset.Now = " + DateTimeOffset.Now);
			return DateTimeOffset.Now;
		}
	}
}