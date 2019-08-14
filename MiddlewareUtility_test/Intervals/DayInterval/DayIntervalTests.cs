namespace MiddlewareUtility_test.intervals.DayInterval
{
    using System;
    using System.Dynamic;
    using System.Globalization;
    using NUnit.Framework;
    using MiddlewareUtility.Tools;

    public class DayIntervalTest
    {
        // Both DateTime in Utc kind
        [Test]
        public void Constructor_DataTime_BothUtc_KindMustUtc()
        {
            var startTime = new DateTime(2019, 10, 19, 3, 10, 55, 0, DateTimeKind.Utc);
            var endTime = startTime.AddDays(1);

            var dayInterval = new DayInterval(startTime, endTime, 0);

            Assert.That(dayInterval.Kind == DateTimeKind.Utc);
            Assert.That(dayInterval.DateTimeStart.Kind == DateTimeKind.Utc);
            Assert.That(dayInterval.DateTimeEnd.Kind == DateTimeKind.Utc);
        }

        // Both DateTime in Local kind
        [Test]
        public void Constructor_DataTime_BothLocal_KindMustLocal()
        {
            var startTime = new DateTime(2019, 10, 19, 3, 10, 55, 0, DateTimeKind.Local);
            var endTime = startTime.AddDays(1);

            var dayInterval = new DayInterval(startTime, endTime, 0);

            Assert.That(dayInterval.Kind == DateTimeKind.Local);
            Assert.That(dayInterval.DateTimeStart.Kind == DateTimeKind.Local);
            Assert.That(dayInterval.DateTimeEnd.Kind == DateTimeKind.Local);
        }

        //Both DateTime in Unspecific kind
        [Test]
        public void Constructor_DataTime_BothUnspecific_ReturnArgumentException()
        {
            var startTime = new DateTime(2019, 10, 19, 3, 10, 55, 0, DateTimeKind.Unspecified);
            var endTime = startTime.AddDays(1);
            Assert.Throws<ArgumentException>(() => new DayInterval(startTime, endTime, 0));
        }

        // DateTime in Utc and Local kind
        [Test]
        public void Constructor_WithDifferentDataTimeKind_Utc_Local_ReturnArgumentException()
        {
            var startTime = new DateTime(2019, 10, 19, 3, 10, 55, 0, DateTimeKind.Utc);
            var endTime = new DateTime(2019, 10, 20, 3, 10, 55, 0, DateTimeKind.Local);
            Assert.Throws<ArgumentException>(() => new DayInterval(startTime, endTime, 0));
        }
        [Test]
        public void Constructor_WithDifferentDataTimeKind_Local_Utc_ReturnArgumentException()
        {
            var startTime = new DateTime(2019, 10, 19, 3, 10, 55, 0, DateTimeKind.Local);
            var endTime = new DateTime(2019, 10, 20, 3, 10, 55, 0, DateTimeKind.Utc);
            Assert.Throws<ArgumentException>(() => new DayInterval(startTime, endTime, 0));
        }
        
        // DateTime in Utc and Unspecific kind
        [Test]
        public void Constructor_WithDifferentDataTimeKind_Utc_Unspecific_ReturnArgumentException()
        {
            var startTime = new DateTime(2019, 10, 19, 3, 10, 55, 0, DateTimeKind.Utc);
            var endTime = new DateTime(2019, 10, 20, 3, 10, 55, 0, DateTimeKind.Unspecified);
            Assert.Throws<ArgumentException>(() => new DayInterval(startTime, endTime, 0));
        }
        [Test]
        public void Constructor_WithDifferentDataTimeKind_Unspecific_Utc_ReturnArgumentException()
        {
            var startTime = new DateTime(2019, 10, 19, 3, 10, 55, 0, DateTimeKind.Unspecified);
            var endTime = new DateTime(2019, 10, 20, 3, 10, 55, 0, DateTimeKind.Utc);
            Assert.Throws<ArgumentException>(() => new DayInterval(startTime, endTime, 0));
        }

        // DateTime in Local and Unspecific kind
        [Test]
        public void Constructor_WithDifferentDataTimeKind_Local_Unspecific_ReturnArgumentException()
        {
            var startTime = new DateTime(2019, 10, 19, 3, 10, 55, 0, DateTimeKind.Local);
            var endTime = new DateTime(2019, 10, 20, 3, 10, 55, 0, DateTimeKind.Unspecified);
            Assert.Throws<ArgumentException>(() => new DayInterval(startTime, endTime, 0));
        }
        [Test]
        public void Constructor_WithDifferentDataTimeKind_Unspecific_Local_ReturnArgumentException()
        {
            var startTime = new DateTime(2019, 10, 19, 3, 10, 55, 0, DateTimeKind.Unspecified);
            var endTime = new DateTime(2019, 10, 20, 3, 10, 55, 0, DateTimeKind.Local);
            Assert.Throws<ArgumentException>(() => new DayInterval(startTime, endTime, 0));
        }
        
        // Check Offset
        [Test]
        public void Constructor_CheckOffset()
        {
            var startTime = new DateTime(2019, 10, 19, 3, 10, 55, 0, DateTimeKind.Utc);
            var endTime = new DateTime(2019, 10, 20, 3, 10, 55, 0, DateTimeKind.Utc);
            var dayInterval = new DayInterval(startTime, endTime, 127);
            
            Assert.That(dayInterval.Offset == 127);
        }

        [Test]
        public void Constructor_OffsetMoreThanMaxValue_ReturnArgumentException()
        {
            var startTime = new DateTime(2019, 10, 19, 3, 10, 55, 0, DateTimeKind.Utc);
            var endTime = new DateTime(2019, 10, 20, 3, 10, 55, 0, DateTimeKind.Utc);
            Assert.Throws<ArgumentException>(()=>new DayInterval(startTime, endTime, 86399001));
        }
        
        [Test]
        public void Constructor_OffsetLessThanMinValue_RetrunArgumentException()
        {
            var startTime = new DateTime(2019, 10, 19, 3, 10, 55, 0, DateTimeKind.Utc);
            var endTime = new DateTime(2019, 10, 20, 3, 10, 55, 0, DateTimeKind.Utc);
            Assert.Throws<ArgumentException>(()=>new DayInterval(startTime, endTime, -1));
        }
    }
}