namespace MiddlewareUtility_test.intervals.dayIntervals.implementation
{
    using System;
    using MiddlewareUtility.intervals.dayIntervals.implementation;
    using NUnit.Framework;

    [TestFixture]
    public class DayIntervalTest
    {
        [Test]
        public void DayIntervalEmptyConstructor_ShouldReturnException()
        {
            Assert.Catch<ArgumentException>(() => new DayInterval());
        }
        
        
    }
}