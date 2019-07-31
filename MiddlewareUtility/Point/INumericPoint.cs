using System;

namespace MiddlewareUtility.Types
{
    public interface INumericPoint : IPoint
    {
        DateTime ExecutionTime { get; set; }
        EnterprisePropertyType Type { get; }
        double Value { get; set; }
    }
}