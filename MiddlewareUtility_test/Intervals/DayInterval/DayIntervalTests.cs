using System;

namespace MiddlewareUtility_test.intervals.DayInterval
{
    using System.Dynamic;
    using NUnit.Framework;
    using MiddlewareUtility.Tools;

    public class DayIntervalTest
    {
        // Both DateTime in Utc
        [Test]
        public void Constructor_DataTime_BothUtc_KindMustUtc()
        {
            throw new NotImplementedException();
        }

        // Both DateTime in Local
        [Test]
        public void Constructor_DataTime_BothLocal_KindMustLocal()
        {
            throw new NotImplementedException();
        }

        //DateTime in Unspecific
        [Test]
        public void Constructor_DataTime_BothLocal_ReturnExceptionIllegalArgument()
        {
            throw new NotImplementedException();
        }

        // DateTime in Utc and Local format
        [Test]
        public void Constructor_WithDifferentDataTime_Utc_Local_ReturnExceptionIllegalArgument()
        {
            throw new NotImplementedException();
        }

        // DateTime in Utc and Unspecific format
        [Test]
        public void Constructor_WithDifferentDataTime_Utc_Unspecific_ReturnExceptionIllegalArgument()
        {
            throw new NotImplementedException();
        }

        // DateTime in Local and Unspecific format
        [Test]
        public void Constructor_WithDifferentDataTime_Local_Unspecific_ReturnExceptionIllegalArgument()
        {
            throw  new NotImplementedException();
        }
    }
}