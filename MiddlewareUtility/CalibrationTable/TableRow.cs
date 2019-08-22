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

        protected bool Equals(TableRow other)
        {
            return Index.Equals(other.Index) && Value.Equals(other.Value);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((TableRow) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Index.GetHashCode() * 397) ^ Value.GetHashCode();
            }
        }
    }
}