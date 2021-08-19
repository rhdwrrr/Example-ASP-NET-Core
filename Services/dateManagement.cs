using System;
using System.Globalization;
using NodaTime;
using NodaTime.Extensions;
using NodaTime.Text;

namespace OrigamiEdu.Services
{
    public class dateManagement
    {
        public DateTime getUTCTime(DateTime d)    
        {
            return DateTime.Now.AddHours(-7);
        }
    }
}