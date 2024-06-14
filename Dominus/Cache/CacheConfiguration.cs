using System;
namespace Dominus.Cache
{
	public class CacheConfiguration
	{
        public int AbsoluteExpirationInHours { get; set; }

        public int SlidingExpirationInMinutes { get; set; }
    }
}

