namespace MiddlewareUtility.Tools
{
    using System.ComponentModel;
    
    [ImmutableObject(true)]
    public class TableRow
    {
        public readonly double Index;
        public readonly double Value;

        public TableRow(double Index, double Value)
        {
            this.Index = Index;
            this.Value = Value;
        }
    }
}