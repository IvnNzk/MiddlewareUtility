namespace MiddlewareUtility.Exceptions
{
    using System;

    [Serializable]
    public class EngUnitNotFoundException : Exception
    {
        public EngUnitNotFoundException() : base("Единица измерения не найдена")
        {
        }

        public EngUnitNotFoundException(string Message) : base(Message)
        {
        }
    }
}