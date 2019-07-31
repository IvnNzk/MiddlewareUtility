using System;

namespace MiddlewareUtility.Types
{
    public interface IStringPoint : IPoint
    {
        DateTime ExecutionTime { get; set; }
        EnterprisePropertyType Type { get; }
        string Value { get; set; }

        bool IsBadState();
    }
}