namespace WebEnabled.Tv.EitherOr.Void;

public abstract record Unitable<TSomething> : Unit where TSomething : class
{    
    public abstract bool IsEmpty { get; }

    public abstract TSomething Get();
    
    public static Unitable<TSomething> Some(TSomething value) => new Some<TSomething>(value);

    public static Unitable<TSomething> Unit() => Unit<TSomething>.Instance();
}

public record Some<TSomething> : Unitable<TSomething> where TSomething : class
{
    public override bool IsEmpty => false;

    private readonly TSomething _value;

    public Some(TSomething value)
    {
        _value = value;
    }

    public override TSomething Get()
    {
        return _value;
    }
}

public record Unit<TSomething> : Unitable<TSomething> where TSomething : class
{
    private static  Unitable<TSomething>? _unit;

    public override bool IsEmpty { get; }

    private Unit() { }

    public override TSomething Get()
    {
        return null;
    }

    public static Unitable<TSomething> Instance()
    {
        return _unit ??= new Unit<TSomething>();
    }
}