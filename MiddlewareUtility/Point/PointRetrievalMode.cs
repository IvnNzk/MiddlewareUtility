namespace MiddlewareUtility.Types
{
    /// <summary>
    /// Defines the possible options for retrieving recorded values from an attribute.
    /// </summary>
    public enum PointRetrievalMode
    {
        /// <summary>
        /// Return the first recorded value after the passed time.
        /// </summary>
        Auto = 0,

        /// <summary>
        /// Return a recorded value at the passed time or if no value exists at that time, the
        /// previous recorded value.
        /// </summary>
        AtOrBefore = 1,

        /// <summary>
        /// Return a recorded value at the passed time or if no value exists at that time, the next
        /// recorded value.
        /// </summary>
        AtOrAfter = 2,

        /// <summary>
        /// Return a recorded value at the passed time or return an error if none exists.
        /// </summary>
        Exact = 4,

        /// <summary>
        /// Return the first recorded value before the passed time.
        /// </summary>
        Before = 6,

        /// <summary>
        /// Return the first recorded value after the passed time.
        /// </summary>
        After = 7
    }
}