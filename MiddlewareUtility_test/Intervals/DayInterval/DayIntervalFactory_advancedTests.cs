namespace MiddlewareUtility_test.Intervals.DayInterval
{
    using System;
    using System.Collections;
    using NUnit.Framework;
    using MiddlewareUtility.Factories;
    using MiddlewareUtility.Tools;


    public class DayIntervalFactory_advancedTests_IntervalInLocals
    {
        
        [TestCaseSource(typeof(OneCase))]
        public void GetDayIntervalByDate_recivedIntervalCheck(DateTime inputTime, int offset, TimeInterval shouldReturn)
        {
            var factory = new DayIntervalFactory();
            var returnedInterval = factory.GetDayIntervalByDate(inputTime, offset);
            Assert.Equals(returnedInterval, shouldReturn);
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

            DateTime timeIntervalTimeStart = new DateTime(2019, 10, 13, 5, 0, 0, DateTimeKind.Local);
            var dayInterval =
                new TimeInterval(timeIntervalTimeStart, timeIntervalTimeStart.AddDays(1).AddSeconds(-1));

            var stepSecods = 45;

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

                yield return (object)newCase;
            }

            yield return (object) new OneCase()
            {
                Time = timeIntervalTimeStart.AddDays(1).AddSeconds(-1),
                Offset = offset,
                DayInterval = dayInterval,
            };
        }
    }
}