using System;

namespace LoggerLib.logging.implementation
{
    public class ConsoleLogger : IUtilityLogger
    {
        public void Info(string message) =>
            Console.WriteLine("INFO:: {0}", message);

        public void Info(string format, params object[] args) =>
            Console.WriteLine("INFO:: " + String.Format(format, args));

        public void Warn(string message) =>
            Console.WriteLine("WARN:: {0}", message);

        public void Warn(string format, params object[] args) =>
            Console.WriteLine("WARN:: " + String.Format(format, args));

        public void Error(string message) =>
            Console.WriteLine("ERROR:: {0}", message);

        public void Error(string format, params object[] args) =>
            Console.WriteLine("ERROR:: " + String.Format(format, args));

    }
}