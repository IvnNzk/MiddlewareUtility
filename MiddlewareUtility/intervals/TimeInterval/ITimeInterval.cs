namespace MiddlewareUtility.Types
{
    using System;

    /// <summary>
    /// Represent interface for time interval
    /// </summary>
    public interface ITimeInterval
    {
        /// <summary>
        /// Return end of time interval
        /// </summary>
        DateTime DateTimeEnd { get; }

        /// <summary>
        /// Return start of time interval
        /// </summary>
        DateTime DateTimeStart { get; }

        DateTimeKind Kind { get; }

        ITimeInterval ToLocalTimeInterval();

        ITimeInterval ToUtcTimeInterval();
    }
}