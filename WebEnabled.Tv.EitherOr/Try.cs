namespace WebEnabled.Tv.EitherOr;

using Void;

public abstract class Try<TResult> : ITry<TResult>
{
    public abstract TResult Result { get; }
    
    public abstract bool IsSuccessful();
    
    public abstract bool IsFailure();
    
    public Exception? Exp { get; protected init; }

    public static ITry<TResult> Of(Func<TResult> func)
    {
        try
        {
            var result = func.Invoke();
            return new Success<TResult>(result);
        }
        catch (Exception e)
        {
            return new Failure<TResult>(e);
        }
    }

    public static ITry<TResult> Of(object[] param, Delegate func)
    {
        try
        {
            var result = (TResult) func.DynamicInvoke(param);
            return new Success<TResult>(result);
        }
        catch (Exception e)
        {
            return new Failure<TResult>(e);
        }
    }

    public new Either<Exception, TResult> ToEither()
    {
        return IsSuccessful() ? Either<Exception, TResult>.Right(Result) : Either<Exception, TResult>.Left(Exp);
    }
}

public abstract class Try : Try<Unit>
{
    public static ITry<Unit> Run(Action action)
    {
        return Of(() =>
        {
            action.Invoke();
            return new Unit();
        });
    }
} 

