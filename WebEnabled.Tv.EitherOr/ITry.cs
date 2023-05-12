namespace WebEnabled.Tv.EitherOr;

using Void;

public interface ITry<TResult> : ITry
{
    TResult Result { get; }    
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
            return new Failure(e);
        }
    }
    
    Either<Exception, Unit> ToEither();
}