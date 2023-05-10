namespace WebEnabled.Tv.EitherOr;

public abstract class Either<TLeft, TRight>
{
    // ReSharper disable once InconsistentNaming
    protected TLeft? _left;
    // ReSharper disable once InconsistentNaming
    protected TRight? _right;
    
    public abstract bool IsRight { get; }
    
    public abstract bool IsLeft { get; }

    public abstract TRight Get();

    public abstract TLeft GetLeft();

    public static Either<TLeft, TRight> Right(TRight right) => new Right<TLeft, TRight>(right);

    public static Either<TLeft, TRight> Left(TLeft left) => new Left<TLeft, TRight>(left);
}