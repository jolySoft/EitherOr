namespace WebEnabled.Tv.EitherOr;

using Void;

public class Failure<TResult> : Try<TResult>
{
    public Failure(Exception exp)
    {
        Exp = exp;
    }
    
    public override bool IsSuccessful() => false;
    
    public override bool IsFailure() => true;


    public override TResult Result => throw new NotImplementedException("This is a failure");
    
}