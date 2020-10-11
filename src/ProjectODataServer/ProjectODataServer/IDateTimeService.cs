using System;

namespace ProjectODataServer
{
	public interface IDateTimeService
	{
		DateTime Now();
		DateTimeOffset NowOffset();
	}
}