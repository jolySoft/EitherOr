namespace WenEnabled.Tv.NVar.Tests;

public class LeftStub
{
    private readonly int _i;

    public LeftStub(int i)
    {
        _i = i;
    }

    protected bool Equals(LeftStub other)
    {
        return _i == other._i;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(null, obj)) return false;
        if (ReferenceEquals(this, obj)) return true;
        if (obj.GetType() != this.GetType()) return false;
        return Equals((LeftStub)obj);
    }

    public override int GetHashCode()
    {
        return _i;
    }
}

