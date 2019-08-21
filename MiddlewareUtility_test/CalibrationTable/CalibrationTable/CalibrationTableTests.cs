using System;
using System.Security.Policy;

namespace MiddlewareUtility_test.CalibrationTable.CalibrationTable
{
    using NUnit.Framework;
    using MiddlewareUtility.Tools;
    using System.Collections.Generic;

    public class CalibrationTableTests
    {
        private CalibrationTable<TableRow> _table;
        private double _rightBoundValue;
        private double _rightBoundIndex;
        private double _leftBoundValue;
        private double _leftBoundIndex;
        private int _count;

        // init CalibrationTable for test;
        [SetUp]
        public void CreateCalibrationTableForTest()
        {
            var rowsList = new List<TableRow>();
            double curValue = 0;
            _leftBoundValue = curValue;
            _leftBoundIndex = 0;
            for (var i = _leftBoundIndex ; i<10; i++) {
                rowsList.Add(new TableRow(i,curValue));
                curValue += 0.4;
                _rightBoundIndex = i;
            }

            _rightBoundValue = curValue;
            _count = rowsList.Count;
            _table = new CalibrationTable<TableRow>(rowsList);
        }

        [Test]
        public void ConstructorTest()
        {
            var rowsList = new List<TableRow>();
            rowsList.Add(new TableRow(0,0));
            rowsList.Add(new TableRow(1,1.2));
            rowsList.Add(new TableRow(1,4.2));
            var table = new CalibrationTable<TableRow>(rowsList);
            
            Assert.IsNotNull(table);
        }

        [Test]
        public void PropertyCountTest()
        {
            Assert.That(_table.Count == _count);
        }

        [Test]
        public void PropertyLeftBoundIndexTest()
        {
            Assert.AreEqual(_leftBoundIndex,_table.LeftBoundIndex);
        }

        [Test]
        public void PropertyLeftBoundValueTest()
        {
            Assert.AreEqual(_leftBoundValue, _table.LeftBoundValue);
        }

        [Test]
        public void PropertyRightBoundIndexTest()
        {
            Assert.AreEqual(_rightBoundIndex,_table.RightBoundIndex);
        }

        [Test]
        public void PropertyRightBoundValueTest()
        {
            Assert.AreEqual(_rightBoundValue,_table.RightBoundValue,0.0001);
        }
    }
}