namespace MiddlewareUtility.Tools
{
    using MiddlewareUtility.Exceptions;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Globalization;

    public class CalibrationTable
    {
        private readonly string _separator = "\r\n";
        private readonly string _terminator = "";
        private List<TableRow> _table;

        public CalibrationTable(List<TableRow> table)
        {
            _table = table;
        }

        public double LeftBound
        {
            get
            {
                return _table[0].Index;
            }
        }

        public double LeftBoundValue
        {
            get
            {
                return _table[0].Value;
            }
        }

        public double RightBound
        {
            get
            {
                return _table[_table.Count - 1].Index;
            }
        }

        public double RightBoundValue
        {
            get
            {
                return _table[_table.Count - 1].Value;
            }
        }

        public double GetValue(double index)
        {
            if ((index > RightBound) || (index < LeftBound))
            {
                throw new CalibrationTableException(string.Format(CultureInfo.CurrentCulture, "Can not get value from table. Index => {0} out of table bounds.", index));
            }

            var indexFinded = _table.FindIndex((x) => x.Index == index);

            if (indexFinded != -1)
            {
                return _table[indexFinded].Value;
            }

            for (var i = 1; i < _table.Count; i++)
            {
                if ((_table[i - 1].Index < index) && (_table[i].Index > index))
                {
                    return Interpolate(_table[i - 1].Index, _table[i - 1].Value, _table[i].Index, _table[i].Value, index);
                }
            }

            throw new CalibrationTableException(String.Format("Can not find value => {0} in a table", index));
        }

        public override string ToString()
        {
            string result = string.Empty;

            foreach (var row in this._table)
            {
                result = result + (row.Index >= 1 ? _separator : string.Empty) + row.Index + "=" + row.Value.ToString(CultureInfo.CurrentCulture).Replace(",", ".");
            }

            return result;
        }

        public string ToString(double index)
        {
            string result = this.GetString(index);

            if (string.IsNullOrEmpty(result))
            {
                return string.Empty;
            }
            else
            {
                return result + _terminator;
            }
        }

        public string ToString(double firstIndex, double secondIndex)
        {
            if (secondIndex < firstIndex)
            {
                var swap = secondIndex;
                secondIndex = firstIndex;
                firstIndex = swap;
            }

            return this.GetString(firstIndex) + _separator + this.GetString(secondIndex) + _terminator;
        }

        private string GetString(double index)
        {
            int i;

            if (index < LeftBound)
            {
                return string.Empty;
            }

            if (index > RightBound)
            {
                throw new CalibrationTableException(string.Format(CultureInfo.CurrentCulture, "Can not get value from table. Index => {0} out of table bounds.", index));
            }
            else if (index == RightBound)
            {
                return TablePartToString(_table[_table.Count - 2].Index, index);
            }
            else
            {
                int indexFinded = _table.FindIndex((x) => x.Index == index);
                if (indexFinded == -1)
                {
                    for (i = 0; i < _table.Count; i++)
                    {
                        if (_table[i].Index >= index)
                        {
                            indexFinded = i;
                            break;
                        }
                    }

                    if (indexFinded == -1)
                    {
                        throw new CalibrationTableException(string.Format(CultureInfo.CurrentCulture, "Can not get value from table. Index => {0} out of table bounds.", index));
                    }
                }
                return TablePartToString(index, _table[indexFinded + 1].Index);
            }
        }

        private double Interpolate(double prevKey, double prevVal, double nextKey, double nextVal, double thisKey)
        {
            return prevVal + ((thisKey - prevKey) / (nextKey - prevKey)) * (nextVal - prevVal);
        }

        private string TablePartToString(double from, double to)
        {
            int i;
            string result = string.Empty;

            if (to < from)
            {
                var swap = to;
                to = from;
                from = swap;
            }

            if (to > RightBound)
            {
                throw new CalibrationTableException(string.Format(CultureInfo.CurrentCulture, "Can not get value from table. Index => {0} out of table bounds.", to));
            }

            if (from < LeftBound)
            {
                from = LeftBound;
            }

            int fromIndex = -1;
            int toIndex = -1;

            fromIndex = _table.FindIndex((x) => x.Index == from);

            if (fromIndex == -1)
            {
                for (i = 0; i < _table.Count; i++)
                {
                    if (_table[i].Index >= from)
                    {
                        fromIndex = i;
                        break;
                    }
                }

                if (fromIndex == -1)
                {
                    throw new CalibrationTableException(string.Format(CultureInfo.CurrentCulture, "Can not get value from table. Index => {0} out of table bounds.", from));
                }
            }

            toIndex = _table.FindIndex((x) => x.Index == to);

            if (toIndex == -1)
            {
                for (i = _table.Count - 1; i > 0; i--)
                {
                    if (_table[i].Index <= to)
                    {
                        toIndex = i;
                        break;
                    }
                }

                if (toIndex == -1)
                {
                    throw new CalibrationTableException(string.Format(CultureInfo.CurrentCulture, "Can not get value from table. Index => {0} out of table bounds.", to));
                }
            }

            for (i = fromIndex; i <= toIndex; i++)
            {
                result = result + ((result != null && string.IsNullOrEmpty(result)) ? string.Empty : _separator) + i + "=" + _table[i].Value.ToString(CultureInfo.CurrentCulture).Replace(",", ".");
            }

            return result;
        }
    }
}