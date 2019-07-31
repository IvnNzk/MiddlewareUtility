namespace MiddlewareUtility.CalibrationTable
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using MiddlewareUtility.Exceptions;
    using MiddlewareUtility.Tools;

    public static class CalibrationTableFactory
    {
        public static CalibrationTable GetCalibrationTable(string SQLConnectionString, string CommandText)
        {
            SqlConnection connection = null;
            SqlCommand command;
            SqlDataReader reader = null;

            try
            {
                connection = new SqlConnection(SQLConnectionString);
                command = connection.CreateCommand();
                command.CommandText = CommandText;
                connection.Open();

                var table = new List<TableRow>();

                reader = command.ExecuteReader();

                while (reader.Read())
                {
                    table.Add(new TableRow(reader.GetDouble(0), reader.GetDouble(1)));
                }

                reader.Close();
                connection.Close();

                reader = null;
                connection = null;

                return new CalibrationTable(table);
            }
            catch (Exception ex)
            {
                if (reader != null)
                {
                    reader.Close();
                    reader = null;
                }
                if (connection != null)
                {
                    connection.Close();
                    connection = null;
                }

                throw new CalibrationTableException(ex.Message);
            }
        }

        public static CalibrationTable GetCalibrationTable(double[] calibratingArray)
        {
            if (calibratingArray.Length == 0)
            {
                throw new CalibrationTableException(string.Format(CultureInfo.CurrentCulture, "Initialization array is empty"));
            }

            int i;

            var table = new List<TableRow>();

            for (i = 0; i < calibratingArray.Length; i++)
            {
                table.Add(new TableRow(i, calibratingArray[i]));
            }

            return new CalibrationTable(table);
        }
    }
}