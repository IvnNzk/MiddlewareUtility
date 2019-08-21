namespace MiddlewareUtility.Tools
{
    using System.ComponentModel;
    
    [ImmutableObject(true)]
    public class TableRow
    {
        public readonly double Index;
        public readonly double Value;

        public TableRow(double index, double value)
        {
            this.Index = index;
            this.Value = value;
        }
    }
}