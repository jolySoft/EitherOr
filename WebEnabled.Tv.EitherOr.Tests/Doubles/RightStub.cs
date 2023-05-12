namespace WenEnabled.Tv.EitherOr.Tests.Doubles;

public class RightStub
{
    public string Stringly { get; set; }

    public RightStub(string s)
    {
        Stringly = s;
    }

    public RightStub Throwly()
    {
        throw new ApplicationException();
    }

    protected bool Equals(RightStub other)
    {
        return Stringly == other.Stringly;
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
        return Stringly.GetHashCode();
    }
}

