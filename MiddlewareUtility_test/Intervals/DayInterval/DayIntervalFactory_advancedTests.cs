namespace MiddlewareUtility_test.Intervals.DayInterval
{
    using System;
    using System.Collections;
    using NUnit.Framework;
    using MiddlewareUtility.Factories;
    using MiddlewareUtility.Tools;


    public class DayIntervalFactoryAdvancedTestsIntervalInLocals
    {
        [TestCaseSource(typeof(OneCase))]
        public void GetDayIntervalByDate_recivedIntervalCheck(OneCase someCase)
        {
            var factory = new DayIntervalFactory();
            var returnedInterval = factory.GetDayIntervalByDate(someCase.Time, someCase.Offset);
            Assert.AreEqual( someCase.DayInterval,returnedInterval);
            Assert.AreEqual( someCase.DayInterval.Kind,returnedInterval.Kind);
        }
    }

    public class OneCase : IEnumerable
    {
        public DateTime Time { get; set; }
        public int Offset { get; set; }
        public TimeInterval DayInterval { get; set; }

        public IEnumerator GetEnumerator()
        {
            /*
             * 05:00:01 in milleseconds
             */
            int offset = 18001000;

            DateTime timeIntervalTimeStart = new DateTime(2019, 10, 13, 5, 0, 1, DateTimeKind.Local);
            var dayInterval =
                new TimeInterval(timeIntervalTimeStart, timeIntervalTimeStart.AddDays(1).AddSeconds(-1));

            var stepSecods = 1000;

            var time = timeIntervalTimeStart;

            while (true)
            {
                if (time >= dayInterval.DateTimeEnd)
                {
                    break;
                }

                var newCase = new OneCase()
                {
                    Time = time,
                    Offset = offset,
                    DayInterval = dayInterval
                };

                time = time.AddSeconds(stepSecods);

                yield return newCase;
            }

            yield return (object)new OneCase()
            {
                Time = timeIntervalTimeStart.AddDays(1).AddSeconds(-1),
                Offset = offset,
                DayInterval = dayInterval,
            };
        }
    }
}