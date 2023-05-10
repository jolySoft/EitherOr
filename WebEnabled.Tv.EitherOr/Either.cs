namespace WebEnabled.Tv.EitherOr;

public abstract class Either<TLeft, TRight>
{
    protected TLeft? Left;
    protected TRight? Right;

    public abstract TRight Get();

    public abstract TLeft GetLeft();
}