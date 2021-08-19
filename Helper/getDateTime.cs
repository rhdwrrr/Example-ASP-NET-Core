using System;
using NodaTime;
using NodaTime.Extensions;

namespace OrigamiEdu.Helper
{
    public class getDateTime
    {
        public static DateTime getUTCTime(DateTime d)
        {
            d = DateTime.UtcNow;

            var zone = DateTimeZoneProviders.Tzdb["Etc/UTC"];
            
            Instant instant = d.ToInstant();
            ZonedDateTime inZone = instant.InZone(zone);

            DateTime utc = inZone.ToDateTimeUnspecified();

            DateTime unspecified = inZone.ToDateTimeUnspecified();

            return unspecified;
        }
        public static DateTime getWIB7(DateTime d)
        {

            var zone = DateTimeZoneProviders.Tzdb["Asia/Jakarta"];
            Instant instant = d.ToInstant();
            ZonedDateTime inZone = instant.InZone(zone);

            DateTime utc = inZone.ToDateTimeUnspecified();

            DateTime unspecified = inZone.ToDateTimeUnspecified();

            return unspecified;
        }


    }
}