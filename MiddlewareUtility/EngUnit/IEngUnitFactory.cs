namespace MiddlewareUtility.Factories
{
    using MiddlewareUtility.Tools;

    internal interface IEngUnitFactory
    {
        EngUnit GetEngUnit(string engUnitName);
    }
}