namespace MiddlewareUtility_test.Intervals.timeInterval
{
    using System;
    using MiddlewareUtility.Tools;
    using NUnit.Framework;
    using MiddlewareUtility.intervals.Tools;

    public class TimeIntervalTests
    {
        // Both DateTime in Utc kind
        [Test]
        public void Constructor_DataTime_BothUtc_KindMustUtc()
        {
            var startTime = new DateTime(2019, 10, 19, 3, 10, 55, 0, DateTimeKind.Utc);
            var endTime = startTime.AddDays(1);

            var timeInterval = new TimeInterval(startTime, endTime);

            Assert.That(timeInterval.Kind == DateTimeKind.Utc);
            Assert.That(timeInterval.DateTimeStart.Kind == DateTimeKind.Utc);
            Assert.That(timeInterval.DateTimeEnd.Kind == DateTimeKind.Utc);
        }

        // Both DateTime in Local kind
        [Test]
        public void Constructor_DataTime_BothLocal_KindMustLocal()
        {
            var startTime = new DateTime(2019, 10, 19, 3, 10, 55, 0, DateTimeKind.Local);
            var endTime = startTime.AddDays(1);

            var timeInterval = new TimeInterval(startTime, endTime);

            Assert.That(timeInterval.Kind == DateTimeKind.Local);
            Assert.That(timeInterval.DateTimeStart.Kind == DateTimeKind.Local);
            Assert.That(timeInterval.DateTimeEnd.Kind == DateTimeKind.Local);
        }

        //Both DateTime in Unspecific kind
        [Test]
        public void Constructor_DataTime_BothUnspecific_ReturnArgumentException()
        {
            var startTime = new DateTime(2019, 10, 19, 3, 10, 55, 0, DateTimeKind.Unspecified);
            var endTime = startTime.AddDays(1);
            Assert.Throws<ArgumentException>(() => new TimeInterval(startTime, endTime));
        }

        // DateTime in Utc and Local kind
        [Test]
        public void Constructor_WithDifferentDataTimeKind_Utc_Local_ReturnArgumentException()
        {
            var startTime = new DateTime(2019, 10, 19, 3, 10, 55, 0, DateTimeKind.Utc);
            var endTime = new DateTime(2019, 10, 20, 3, 10, 55, 0, DateTimeKind.Local);
            Assert.Throws<ArgumentException>(() => new TimeInterval(startTime, endTime),
                TimeIntervalMessages.KINDS_MUST_BE_THE_SAME);
        }

        [Test]
        public void Constructor_WithDifferentDataTimeKind_Local_Utc_ReturnArgumentException()
        {
            var startTime = new DateTime(2019, 10, 19, 3, 10, 55, 0, DateTimeKind.Local);
            var endTime = new DateTime(2019, 10, 20, 3, 10, 55, 0, DateTimeKind.Utc);
            Assert.Throws<ArgumentException>(() => new TimeInterval(startTime, endTime),
                TimeIntervalMessages.KINDS_MUST_BE_THE_SAME);
        }

        // DateTime in Utc and Unspecific kind
        [Test]
        public void Constructor_WithDifferentDataTimeKind_Utc_Unspecific_ReturnArgumentException()
        {
            var startTime = new DateTime(2019, 10, 19, 3, 10, 55, 0, DateTimeKind.Utc);
            var endTime = new DateTime(2019, 10, 20, 3, 10, 55, 0, DateTimeKind.Unspecified);
            Assert.Throws<ArgumentException>(() => new TimeInterval(startTime, endTime),
                TimeIntervalMessages.STARTTIME_IN_UNSPECIFIED);
        }

        [Test]
        public void Constructor_WithDifferentDataTimeKind_Unspecific_Utc_ReturnArgumentException()
        {
            var startTime = new DateTime(2019, 10, 19, 3, 10, 55, 0, DateTimeKind.Unspecified);
            var endTime = new DateTime(2019, 10, 20, 3, 10, 55, 0, DateTimeKind.Utc);
            Assert.Throws<ArgumentException>(() => new TimeInterval(startTime, endTime),
                TimeIntervalMessages.ENDTIME_IN_UNSPECIFIED);
        }

        // DateTime in Local and Unspecific kind
        [Test]
        public void Constructor_WithDifferentDataTimeKind_Local_Unspecific_ReturnArgumentException()
        {
            var startTime = new DateTime(2019, 10, 19, 3, 10, 55, 0, DateTimeKind.Local);
            var endTime = new DateTime(2019, 10, 20, 3, 10, 55, 0, DateTimeKind.Unspecified);
            Assert.Throws<ArgumentException>(() => new TimeInterval(startTime, endTime),
                TimeIntervalMessages.ENDTIME_IN_UNSPECIFIED);
        }

        [Test]
        public void Constructor_WithDifferentDataTimeKind_Unspecific_Local_ReturnArgumentException()
        {
            var startTime = new DateTime(2019, 10, 19, 3, 10, 55, 0, DateTimeKind.Unspecified);
            var endTime = new DateTime(2019, 10, 20, 3, 10, 55, 0, DateTimeKind.Local);
            Assert.Throws<ArgumentException>(() => new TimeInterval(startTime, endTime),
                TimeIntervalMessages.STARTTIME_IN_UNSPECIFIED);
        }
    }
}