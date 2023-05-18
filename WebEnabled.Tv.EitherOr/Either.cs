namespace WebEnabled.Tv.EitherOr;

using System.Diagnostics.CodeAnalysis;
using Void;

public abstract class Either<TLeft, TRight>  //: IEnumerable<TRight>
{
    // ReSharper disable once InconsistentNaming
    protected TLeft _left;
    // ReSharper disable once InconsistentNaming
    protected TRight _right;
    
    public abstract bool IsRight { get; }
    
    public abstract bool IsLeft { get; }

    public abstract TRight Get();

    public abstract TLeft GetLeft();

    public static Either<TLeft, TRight> Right(TRight right) => new Right<TLeft, TRight>(right);

    public static Either<TLeft, TRight> Left(TLeft left) => new Left<TLeft, TRight>(left);

    public Either<TLeftResponse, TRightResponse> BiMap<TLeftResponse, TRightResponse>(Func<TLeft, TLeftResponse> leftFunc, Func<TRight, TRightResponse> rightFunc)
    {
        if (IsRight) return new Right<TLeftResponse, TRightResponse>(rightFunc.Invoke(Get()));

        return new Left<TLeftResponse, TRightResponse>(leftFunc.Invoke(GetLeft()));
    }

    public Either<TLeft, TRightResponse> Map<TRightResponse>(Func<TRight, TRightResponse> rightFunc)
    {
        return IsRight
            ? Either<TLeft, TRightResponse>.Right(rightFunc.Invoke(Get()))
            : Either<TLeft, TRightResponse>.Left(GetLeft());
    }

    public Either<TLeftResponse, TRight> MapLeft<TLeftResponse>(Func<TLeft, TLeftResponse> leftFunc)
    {
        return IsLeft
            ? Either<TLeftResponse, TRight>.Left(leftFunc.Invoke(GetLeft()))
            : Either<TLeftResponse, TRight>.Right(Get());
    }

    public Either<TLeft, TRightResponse> FlatMap<TRightResponse>(Func<TRight, Either<TLeft, TRightResponse>> rightFunc)
    {
        return IsRight
            ? rightFunc.Invoke(Get())
            : Either<TLeft, TRightResponse>.Left(GetLeft());
    }

    public Unitable<Either<TLeft, TRight>> Filter(Predicate<TRight> predicate)
    {
        return IsLeft || predicate.Invoke(Get()) ? Unitable<Either<TLeft,TRight>>.Some(this) : Unitable<Either<TLeft, TRight>>.Unit();
    }

    public Either<TLeft, TRight> FilterOrElse(Predicate<TRight> predicate, Func<TRight, TLeft> elseFunc)
    {
        return IsLeft || predicate.Invoke(Get()) ? this : Either<TLeft, TRight>.Left(elseFunc.Invoke(Get()));
    }
}