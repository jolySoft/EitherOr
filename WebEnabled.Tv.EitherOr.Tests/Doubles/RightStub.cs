namespace WenEnabled.Tv.NVar.Tests;

public class RightStub
{
    private readonly string _s;

    public RightStub(string s)
    {
        _s = s;
    }

    protected bool Equals(RightStub other)
    {
        return _s == other._s;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((RightStub)obj);
    }

    public override int GetHashCode()
    {
        return _s.GetHashCode();
    }
}

