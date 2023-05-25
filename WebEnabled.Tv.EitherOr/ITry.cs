namespace WebEnabled.Tv.EitherOr;

using Void;

public interface ITry<TResult> : ITry
{
    TResult Result { get; }

    new ITry<TResult> Finally(Action action)
    {
        try
        {
            action.Invoke();
            return this;
        }
        catch (Exception? e)
        {
            return new Failure<TResult>(e);
        }
    }
    
    new Either<Exception, TResult> ToEither();
    
}

public interface ITry
{
    bool IsSuccessful();

    bool IsFailure();
    
    Exception? Exp { get; }

    ITry Finally(Action action)
    {
        try
        {
            action.Invoke();
            return this;
        }
        catch (Exception? e)
        {
            return new Failure<Unit>(e);
        }
    }
    
    Either<Exception, Unit> ToEither();
}