using System;

namespace MiddlewareUtility_test.intervals.DayInterval
{
    using System.Dynamic;
    using NUnit.Framework;
    using MiddlewareUtility.Tools;

    public class DayIntervalTest
    {
        [Test]
        public void CreateInstanceDayIntervalByDateTimeOffset()
        {
            var dayInterval = new DayInterval(DateTime.Now, DateTime.Now);
            Assert.IsNotNull(dayInterval);
        }

        // DateTime in Utc and Local format
        [Test]
        public void CreateDayIntervalWithDifferentDataTime_Utc_Local_ReturnExceptionIllegalArgument()
        {
            throw new NotImplementedException();
        }

        // DateTime in Utc and Unspecific format
        [Test]
        public void CreateDayIntervalWithDifferentDataTime_Utc_Unspecific_ReturnExceptionIllegalArgument()
        {
            throw new NotImplementedException();
        }

        // DateTime in Local and Unspecific format
        [Test]
        public void CreateDayIntervalWithDifferentDataTime_Local_Unspecific_ReturnExceptionIllegalArgument()
        {
            throw new NotImplementedException();
        }
        
        // DateTime in Utc
        [Test]
        public void CreateDayIntervalWithDifferentDataTime_BothUtc_KindMustUtc()
        {
            throw new NotImplementedException();
        }

        // DateTime in Local
        [Test]
        public void CreateDayIntervalWithDifferentDataTime_BothLocal_KindMustLocal()
        {
            throw new NotImplementedException();
        }
    }
}