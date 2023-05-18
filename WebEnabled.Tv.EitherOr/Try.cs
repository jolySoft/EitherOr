namespace WebEnabled.Tv.EitherOr;

using Void;

public abstract class Try<TResult> : Try, ITry<TResult>
{
    public abstract TResult Result { get; }

    public static ITry<TResult> Of<TResult>(Func<TResult> func)
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
    
    public new Either<Exception, TResult> ToEither()
    {
        return IsSuccessful() ? Either<Exception, TResult>.Right(Result) : Either<Exception, TResult>.Left(Exp);
    }
}

public abstract class Try : ITry
{
    public abstract bool IsSuccessful();
    
    public abstract bool IsFailure();
    
    public Exception? Exp { get; protected init; }

    public static ITry Run(Action action)
    {
        try
        {
            action.Invoke();
            return new Success<Unit>(new Unit());
        }
        catch (Exception? e)
        {
            return new Failure(e);
        }
    }

    public ITry Finally(Action action)
    {
        try
        {
            action.Invoke();
            return this;
        }
        catch (Exception? e)
        {
            return new Failure(e);
        }
    }

    public Either<Exception, Unit> ToEither()
    {
        return IsSuccessful() ? Either<Exception, Unit>.Right(new Unit()) : Either<Exception, Unit>.Left(Exp ?? throw new InvalidOperationException());
    }
}