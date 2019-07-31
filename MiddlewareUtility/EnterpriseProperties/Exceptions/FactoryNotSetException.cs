namespace MiddlewareUtility.Exceptions
{
    using System;

    [Serializable]
    public class FactoryNotSetException : Exception
    {
        public FactoryNotSetException() : base("Не инициализированна фабрика")
        {
        }
    }
}