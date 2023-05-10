namespace WebEnabled.Tv.EitherOr;

public class Right<TLeft, TRight>: Either<TLeft, TRight>
{
    private TRight _right;

    public Right(TRight right)
    {
        _right = right;
    }

    public override TRight Get()
    {
        return _right;
    }

    public override TLeft GetLeft()
    {
        throw new NotImplementedException("Your in the right");
    }
}