namespace MiddlewareUtility.Factories
{
    using MiddlewareUtility.Types;

    public interface IPointFactory
    {
        IPoint GetPoint(string name);
    }
}