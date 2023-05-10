namespace WebEnabled.Tv.EitherOr;

public class Left<TLeft, TRight> : Either<TLeft, TRight>
{
    private TLeft _left;

    public Left(TLeft left)
    {
        _left = left;
    }

    public override TRight Get()
    {
        throw new NotImplementedException("Your in the left");
    }

    public override TLeft GetLeft()
    {
        return _left;
    }
}