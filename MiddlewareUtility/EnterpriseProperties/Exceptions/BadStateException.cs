namespace MiddlewareUtility.Exceptions
{
    using System;

    [Serializable]
    public class BadStateException : Exception
    {
        public BadStateException() : base("Не корректное состояние")
        {
        }
    }
}