namespace LoggerLib.logging
{
    public interface IUtilityLogger
    {
        void Info(string message);

        void Warn(string message);

        void Error(string message);

        void Info(string format, params object[] args);

        void Warn(string format, params object[] args);

        void Error(string format, params object[] args);
    }
}