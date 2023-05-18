namespace WebEnabled.Tv.EitherOr.Void;

public record Unit : IComparable<Unit>
{
    private int voided = 0;

    public virtual bool Equals(Unit? other)
    {
        if (ReferenceEquals(null, other)) return false;
        if (ReferenceEquals(this, other)) return true;
        return voided == other.voided;
    }

    public override int GetHashCode()
    {
        return voided;
    }

    private sealed class VoidedEqualityComparer : IEqualityComparer<Unit>
    {
        public bool Equals(Unit? x, Unit? y)
        {
            if (ReferenceEquals(x, y)) return true;
            if (ReferenceEquals(x, null)) return false;
            if (ReferenceEquals(y, null)) return false;
            if (x.GetType() != y.GetType()) return false;
            return x.voided == y.voided;
        }

        public int GetHashCode(Unit obj)
        {
            return obj.voided;
        }
    }

    public static IEqualityComparer<Unit> VoidedComparer { get; } = new VoidedEqualityComparer();

    public int CompareTo(Unit? other)
    {
        if (ReferenceEquals(this, other)) return 0;
        if (ReferenceEquals(null, other)) return 1;
        return voided.CompareTo(other.voided);
    }
}