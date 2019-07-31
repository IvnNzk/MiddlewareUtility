namespace MiddlewareUtility.Types
{
    /// <summary>
    /// Defines the behavior of data retrieval at the end points of a specified time range.
    /// </summary>
    public enum PointBoundaryType
    {
        /// <summary>
        /// Specifies to return the recorded values on the inside of the requested time range as the
        /// first and last values.
        /// </summary>
        Inside = 0,

        /// <summary>
        /// Specifies to return the recorded values on the outside of the requested time range as the
        /// first and last values.
        /// </summary>
        Outside = 1,

        /// <summary>
        /// Specifies to create an interpolated value at the end points of the requested time range
        /// if a recorded value does not exist at that time.
        /// </summary>
        Interpolated = 2
    }
}