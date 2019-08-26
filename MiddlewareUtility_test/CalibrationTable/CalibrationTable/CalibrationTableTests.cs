using System;
using System.Security.Permissions;

namespace MiddlewareUtility_test.CalibrationTable.CalibrationTable
{
    using System.Collections.Generic;
    using NUnit.Framework;
    using MiddlewareUtility.Tools;

    public class CalibrationTableTests
    {
        private CalibrationTable<TableRow> _table;

        private TableRow _leftBoundValue;
        private TableRow _rightBoundValue;


        private int _count;

        [SetUp]
        public void CreateCalibrationTableForTest()
        {
            var rowsList = new List<TableRow>();
            double curValue = 0;

            for (var i = 0; i < 10; i++)
            {
                var row = new TableRow(i * 100, curValue);
                rowsList.Add(row);

                if (i == 0)
                    _leftBoundValue = row;
                else if (i == 9) _rightBoundValue = row;

                curValue += 0.4;
            }

            _count = rowsList.Count;
            _table = new CalibrationTable<TableRow>(rowsList);
        }

        [Test]
        public void ConstructorTest()
        {
            var rowsList = new List<TableRow>();
            rowsList.Add(new TableRow(0, 0));
            rowsList.Add(new TableRow(1, 1.2));
            rowsList.Add(new TableRow(2, 4.2));
            var table = new CalibrationTable<TableRow>(rowsList);

            Assert.IsNotNull(table);
        }

        [Test]
        public void PropertyCountTest()
        {
            Assert.That(_table.Count == _count);
        }

        [Test]
        public void PropertyLeftBoundValueTest()
        {
            Assert.AreEqual(_leftBoundValue, _table.LeftBoundValue);
        }

        [Test]
        public void PropertyRightBoundValueTest()
        {
            Assert.AreEqual(_rightBoundValue, _table.RightBoundValue);
        }


        /*
         * GetInterpolatedValue tests
         */
        [Test]
        public void GetInterpolatedValueTest()
        {
            throw new NotImplementedException("How to check returned values?");
        }

        [Test]
        public void GetInterpolatedValueTest_IndexMoreThanTableIndex_returnArgumentOutOfRangeException()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void GetInterpolatedValueTest_IndexLessThanTableIndex_returnArgumentOutOfRangeException()
        {
            throw new NotImplementedException();
        }

        /*
         * GetValue Test
         */
        [Test]
        public void GetValueTest_modeAtOrBefore_checkReturnedValues()
        {
            throw new NotImplementedException();
        }
        
        [Test]
        public void GetValueTest_modeAtOrAfter_checkReturnedValues()
        {
            throw new NotImplementedException();
        }
        
        [Test]
        public void GetValueTest_modeBefore_checkReturnedValues()
        {
            throw new NotImplementedException();
        }
        
        [Test]
        public void GetValueTest_modeAfter_checkReturnedValues()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void GetValueTest_modeAtOrBefore_returnArgumentOutOfRangeException()
        {
            throw new NotImplementedException();
        }


        [Test]
        public void GetValueTest_modeBefore_returnArgumentOutOfRangeException()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void GetValueTest_modeAtOrAfter_returnArgumentOutOfRangeException()
        {
            throw new NotImplementedException();
        }

        [Test]
        public void GetValueTest_modeAfter_returnArgumentOutOfRangeException()
        {
            throw new NotImplementedException();
        }
    }
}