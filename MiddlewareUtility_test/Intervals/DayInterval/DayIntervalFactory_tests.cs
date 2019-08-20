using System;

namespace MiddlewareUtility_test.Intervals.DayInterval
{
    using NUnit.Framework;
    using MiddlewareUtility.Factories;

    // Need check message from Exceptions
    public class DayIntervalFactory_tests
    {
        // Constructor tests
        [Test]
        public void ConstructorTest_factoryIsExist()
        {
            Assert.NotNull(new DayIntervalFactory());
        }

        // Constants check
        [Test]
        public void MaxOffsetCheck()
        {
            var factory = new DayIntervalFactory();
            int MaxValueShouldBe = 86398000;
            Assert.True(DayIntervalFactory.MaxOffset == MaxValueShouldBe);
        }

        [Test]
        public void MinOffsetCheck()
        {
            var factory = new DayIntervalFactory();
            int MinValueShouldBe = 0;
            Assert.True(DayIntervalFactory.MinOffset == MinValueShouldBe);
        }

        // GetDayIntervalByDate Tests
        [Test]
        public void GetDayIntervalByDate_DateTime_Utc_returnDateTime()
        {
            var factory = new DayIntervalFactory();
            Assert.NotNull(factory.GetDayIntervalByDate(new DateTime(2019, 10, 10, 13, 56, 44, 123, DateTimeKind.Utc),
                0));
        }

        [Test]
        public void GetDayIntervalByDate_DateTime_Local_returnTimeInterval()
        {
            var factory = new DayIntervalFactory();
            Assert.NotNull(factory.GetDayIntervalByDate(new DateTime(2019, 10, 10, 13, 56, 44, 123, DateTimeKind.Utc),
                0));
        }

        [Test]
        public void GetDayIntervalByDate_DateTime_Unspecific_returnArgumentException()
        {
            var factory = new DayIntervalFactory();
            Assert.Throws<ArgumentException>(() =>
                factory.GetDayIntervalByDate(new DateTime(2019, 10, 10, 13, 56, 44, 123, DateTimeKind.Unspecified), 0));
        }

        [Test]
        public void GetDayIntervalByDate_DateTime_Utc_returnTimeInterval_Utc()
        {
            var factory = new DayIntervalFactory();
            var interval = factory.GetDayIntervalByDate(new DateTime(2019, 10, 10, 13, 56, 44, 123, DateTimeKind.Utc),
                0);
            Assert.That(interval.Kind == DateTimeKind.Utc);
            Assert.That(interval.DateTimeStart.Kind == DateTimeKind.Utc);
            Assert.That(interval.DateTimeEnd.Kind == DateTimeKind.Utc);
        }

        [Test]
        public void GetDayIntervalByDate_DateTime_Local_returnTimeInterval_Local()
        {
            var factory = new DayIntervalFactory();
            var interval = factory.GetDayIntervalByDate(new DateTime(2019, 10, 10, 13, 56, 44, 123, DateTimeKind.Local),
                0);
            Assert.That(interval.Kind == DateTimeKind.Local);
            Assert.That(interval.DateTimeStart.Kind == DateTimeKind.Local);
            Assert.That(interval.DateTimeEnd.Kind == DateTimeKind.Local);
        }

        [Test]
        public void GetDayIntervalByDate_checkConstant_offsetMoreThan_MaxOffset()
        {
            var factory = new DayIntervalFactory();

            Assert.Throws<ArgumentException>(() =>
                factory.GetDayIntervalByDate(new DateTime(2019, 10, 10, 13, 56, 44, 123, DateTimeKind.Utc), DayIntervalFactory.MaxOffset+1));
        }

        [Test]
        public void GetDayIntervalByDate_checkConstant_offsetLessThan_MinOffset()
        {
            var factory = new DayIntervalFactory();
            Assert.Throws<ArgumentException>(() =>
                factory.GetDayIntervalByDate(new DateTime(2019, 10, 10, 13, 56, 44, 123, DateTimeKind.Utc), DayIntervalFactory.MinOffset - 1));
        }
    }
}