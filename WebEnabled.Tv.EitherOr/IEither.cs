namespace WebEnabled.Tv.EitherOr;

public interface IEither<out TLeft, out TRight>
{
    bool IsRight { get; }
    bool IsLeft { get; }
    TRight Get();
    TLeft GetLeft();
}

public interface IEitherMaps<out TLeft, out TRight> 
{
    IEither<TLeftResponse, TRightResponse> BiMap<TLeftResponse, TRightResponse>(Func<TLeft, TLeftResponse> leftFunc, Func<TRight, TRightResponse> rightFunc);
    IEither<TLeft, TRightResponse> Map<TRightResponse>(Func<TRight, TRightResponse> rightFunc);
    IEither<TLeftResponse, TRight> MapLeft<TLeftResponse>(Func<TLeft, TLeftResponse> leftFunc);
    
} 