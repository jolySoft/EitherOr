namespace WebEnabled.Tv.EitherOr;

public class Left<TLeft, TRight> : Either<TLeft, TRight>
{
    internal Left(TLeft left)
    {
        _left = left;
    }

    public override bool IsRight => false;
    public override bool IsLeft => true;

    public override TRight Get()
    {
        throw new NotImplementedException("Your in the left");
    }

    public override TLeft GetLeft()
    {
        return _left;
    }
}