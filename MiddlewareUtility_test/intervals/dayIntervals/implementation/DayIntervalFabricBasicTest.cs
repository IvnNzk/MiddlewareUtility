namespace MiddlewareUtility_test.intervals.dayIntervals.implementation
{
    using NUnit.Framework;
    using MiddlewareUtility.intervals.dayIntervals.implementation;

    [TestFixture]
    public class DayIntervalFabricBasicTest
    {
        [Test]
        public void DayIntervalFabric_EmptyConstructorTest()
        {
            var interval = new DayIntervalFabric();
            Assert.True(interval.DayDiff == 0 );
        }

        [Test]
        public void DayIntervalFabric_ConstructorWithDayDiffMilliseconds()
        {
            var interval = new DayIntervalFabric(1234);
            Assert.True(interval.DayDiff == 1234);
        }
    }
}