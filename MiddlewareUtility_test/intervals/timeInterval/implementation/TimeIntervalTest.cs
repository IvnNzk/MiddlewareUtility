namespace MiddlewareUtility_test.intervals.timeInterval.implementation
{
    using System;
    using MiddlewareUtility.intervals.timeInterval.implementation;
    using NUnit.Framework;

    public class TimeIntervalTest
    {
        [Test]
        public void DayIntervalEmptyConstructor_ShouldReturnException()
        {
            Assert.Catch<ArgumentException>(() => new TimeInterval());
        }
    }
}