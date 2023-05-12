namespace WebEnabled.Tv.EitherOr;

public class Success<TResult> : Try<TResult>
{
    public override TResult Result { get; }
   
    public Success(TResult result)
    {
        Result = result;
    }

    public override bool IsSuccessful() => true;

    public override bool IsFailure() => false;
}