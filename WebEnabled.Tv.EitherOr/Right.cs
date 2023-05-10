namespace WebEnabled.Tv.EitherOr;

public class Right<TLeft, TRight>: Either<TLeft, TRight>
{
    internal Right(TRight right)
    {
        _right = right;
    }

    public override bool IsRight => true;
    public override bool IsLeft => false;

    public override TRight Get()
    {
        return _right;
    }

    public override TLeft GetLeft()
    {
        throw new NotImplementedException("Your in the right");
    }
}