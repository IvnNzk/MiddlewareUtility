namespace MiddlewareUtility.Exceptions
{
    using System;

    [Serializable]
    public class EngUnitRestrictionException : Exception
    {
        public EngUnitRestrictionException() : base("Значение не может быть получено, т.к. не пройдена проверка корректности")
        {
        }

        public EngUnitRestrictionException(string message) : base(message)
        {
        }
    }
}