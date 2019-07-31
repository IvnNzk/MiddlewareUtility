namespace MiddlewareUtility.Tools
{
    public class RestrictionCheckResult
    {
        public RestrictionCheckResult(string messageIfNot)
        {
            IsGood = false;
            Message = messageIfNot;
        }

        public RestrictionCheckResult()
        {
            IsGood = true;
            Message = string.Empty;
        }

        public bool IsGood { get; }
        public string Message { get; }
    }
}