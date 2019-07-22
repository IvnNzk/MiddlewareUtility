namespace MiddlewareUtility.Tools
{
    using System;

    public class DefaultLogger : IUtilityLogger
    {
        public void Error(string message) =>
            Console.WriteLine($"ERROR:: {message}");

        public void Error(string format, params object[] args) =>
            Console.WriteLine($"ERROR:: {String.Format(format, args)}");

        public void Info(string message) =>
            Console.WriteLine($"INFO:: {message}");

        public void Info(string format, params object[] args) =>
            Console.WriteLine($"INFO:: {String.Format(format, args)}");

        public void Warn(string message) =>
            Console.WriteLine($"WARN:: {message}");

        public void Warn(string format, params object[] args) =>
            Console.WriteLine($"WARN:: {String.Format(format, args)}");
    }
}